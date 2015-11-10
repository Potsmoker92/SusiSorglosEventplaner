using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using susisorglos_Datenbank;
namespace SusiSorglosEventplaner
{
    class Action
    {
        public Action()
        {

        }

         public List<User> ListUser()
         {
             List<User> result  = new List<User>();
             result.Add(new User() { strNachname = "Shumway", strVorname = "Grodon", userID = 1 });
             return result;
         }
        
        public void AddUser()
        {

        }

        public void DeleteUser()
        {

        }
        
        public void ChangeUser()
        {

        }

        public List<Event> ListEvent()
         {
             List<Event> result = new List<Event>();
             result.Add(new Event() { strEventname="Cat-Candle-Light-Dinner", eventID=1 });
             return result;
         }
        
        public void AddEvent()
        {

        }

        public void DeleteEvent()
        {

        }
        
        public void ChangeEvent()
        {

        }
    }
}
