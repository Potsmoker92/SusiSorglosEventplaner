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

            ShowOption();
           
            FreeConsole();
        }

        private void ShowOption()
        {
            string[] options = actionOption;
            int selectedAction = 1;
            int selectedType = 1;
            Action action = new Action();

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

            if(selectedAction == 1 )
            {
                if (selectedType == 1)
                {
                    action.ListUser();
                }
                if (selectedType == 2)
                {
                    action.ListEvent();
                }
            }

            if (selectedAction == 2)
            {
                if (selectedType == 1)
                {
                    action.AddUser();
                }
                if (selectedType == 2)
                {
                    action.AddEvent();
                }
            }

            if (selectedAction == 3)
            {
                if (selectedType == 1)
                {
                    action.DeleteUser();
                }
                if (selectedType == 2)
                {
                    action.DeleteEvent();
                }
            }

            if (selectedAction == 4)
            {
                if (selectedType == 1)
                {
                    action.ChangeUser();
                }
                if (selectedType == 2)
                {
                    action.ChangeEvent();
                }
            }

            ShowOption();
            
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
