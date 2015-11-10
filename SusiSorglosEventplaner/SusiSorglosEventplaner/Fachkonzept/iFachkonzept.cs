using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusiSorglosEventplaner
{
    interface iFachkonzept
    {
        List<User> getAllusers();
        List<Event> getAllEvents();
        List<User> getUserByEvent(int eventID);
        List<Event> getEventbyUser(int userID);


        User getUser(int userID);
        void insertUser(User theUser);
        void updateUser(User theUser);
        void deleteUser(int userID);

        void addUserToEvent(int userID, int eventID);
        void removeUserToEvent(int userID, int eventID);

        void insertEvent(Event theEvent);
        void deleteEvent(Event theEvent); 
    }
}
