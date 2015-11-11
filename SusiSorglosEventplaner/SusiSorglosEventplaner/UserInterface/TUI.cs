using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SusiSorglosEventplaner
{
       

    class TUI
    {
        /*
         * [0]   = frage
         * [n>0] = auswahlmöglichkeiten
         * [n+1] = verlassen
         */
        private string[] actionOption = {"Was möchten Sie machen?\n", "anzeigen", "hinzufügen", "löschen", "bearbeiten" ,"verlassen" };
        private string[] typeOption = { "Was möchten Sie ", "Benutzer", "Events", "Verlasen" };

        private iFachkonzept fachkonzept;

        #region Import lib32
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(uint dwProcessId);
        #endregion
      
        public TUI ()
        {
            if (!AttachToConsole())
            {
                AllocConsole();
            }

            //fachkonzept = new FachkonzeptSortiert(new DataManagement());
            fachkonzept = new FachkonzeptUnsortiert(new DataManagement());

            ShowOption();
           
            FreeConsole();
        }

        private void ShowOption()
        {
            string[] options = actionOption;
            int selectedAction = 1;
            int selectedType = 1;

            MenuHandler  actionMenu = new MenuHandler(actionOption);
            MenuHandler typeMenu = new MenuHandler(typeOption);


            //choose an action
            do
            {
                selectedAction = actionMenu.showOptions();
                if (selectedAction < 0)
                    Thread.Sleep(2000); // sleep 2 secs   
            } while (selectedAction < 0);
            if (selectedAction == actionOption.Length - 1)
            {
                return; //quit 
            }
            //choose an type
            do
            {
                typeOption[0] = typeOption[0] + " " + actionOption[selectedAction];
                selectedType = typeMenu.showOptions();
                if (selectedType < 0)
                    Thread.Sleep(2000); // sleep 2 secs   
            } while (selectedType < 0);
            if (selectedType == typeOption.Length - 1)
            {
                return; //quit 
            }

            if(selectedAction == 1 ) //anzeigen 
            {
                if (selectedType == 1) //benutzer 
                {
                  foreach(User usr in  fachkonzept.getAllusers())
                  {
                      Console.WriteLine("ID: {0,4} | Vorname: {1,10} | Nachname: {2,10}", usr.userID, usr.strVorname, usr.strNachname);
                  }
                  Console.WriteLine("Drücken Sie irgend eine Taste um zum Anfangsmenu zurrückzukehren.");
                  Console.ReadKey();
                }
                if (selectedType == 2)//event
                {
                    foreach (Event ent in fachkonzept.getAllEvents())
                    {
                        Console.WriteLine("ID: {0,4} | Name: {1,10} | Ort: {2,10}", ent.eventID, ent.strEventname,ent.strEventLocation);
                    }
                    Console.WriteLine("Drücken Sie irgend eine Taste um zum Anfangsmenu zurrückzukehren.");
                    Console.ReadKey();
                }
            }

            if (selectedAction == 2)//hinzufuegen
            {
                if (selectedType == 1)//benutzer
                {

                    User newUser = requetsUser();
                    fachkonzept.insertUser(newUser);
                }
                if (selectedType == 2)//event
                {
                    Event newEvent = requetsEvent();
                    fachkonzept.insertEvent(newEvent);
                }
            }

            if (selectedAction == 3) //löschen
            {
                if (selectedType == 1)//benutzer
                {
                    int deletID = requestUserID();
                    fachkonzept.deleteUser(deletID);
                }
                if (selectedType == 2)//event
                {
                    Event deleteEvent = requestdeleteEvent();
                    fachkonzept.deleteEvent(deleteEvent);
                }
            }

            if (selectedAction == 4)//bearbeitern
            {
                if (selectedType == 1)//benutzer
                {
                    User changedUser = requestChangedUser();
                    fachkonzept.updateUser(changedUser);
                }
                if (selectedType == 2)//event
                {
                    // was not implemented by tim / tino
                }
            }

            ShowOption();
            
        }

        private User requetsUser()
        {
            User result = new User();
            do
            {
                Console.Clear();
                Console.Write("Geben Sie den Vornamen ein: ");
                result.strVorname = Console.ReadLine();
            } while (result.strVorname == "");

            do
            {
                Console.Clear();
                Console.Write("Geben Sie den Nachnamen ein:");
                result.strNachname = Console.ReadLine();
            } while (result.strNachname == "");

            return result;
        }

        private Event requetsEvent()
        {
            Event result = new Event();
            do
            {
                Console.Clear();
                Console.Write("Geben Sie den Namen des Events ein: ");
                result.strEventname= Console.ReadLine();
            } while (result.strEventname == "");

            do
            {
                Console.Clear();
                Console.Write("Geben Sie den Ort ein:");
                result.strEventLocation = Console.ReadLine();
            } while (result.strEventLocation == "");

            // fehlt noch datumseingabe
            return result;
        }

        private int requestUserID()
        {
            int id = -1;
            Console.Clear();
            Console.Write("Geben Sie die USer-ID ein:");
            string input = Console.ReadLine();
            Int32.TryParse(input, out id);
            return id;
        }
        private Event requestdeleteEvent()
        {
            Console.Clear();
            Console.Write("Geben Sie die Event-ID ein von dem Event das gelöscht werden soll: ");
            string input = Console.ReadLine();
            int id = -1;
            Int32.TryParse(input, out id);

            return new Event() {eventID=id };
        }

        private User requestChangedUser()
        {
            return requetsUser();
        }
     public static bool AttachToConsole()
        {
            const uint ParentProcess = 0xFFFFFFFF;
            if (!AttachConsole(ParentProcess))
                return false;

            Console.Clear();
            return true;
        }
    }
}
