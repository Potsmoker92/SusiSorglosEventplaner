using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusiSorglosEventplaner
{
    interface IDataManagement
    {
        List<User>getAllusers();
        User getUser(int userID);
        List<User> getUsersByEvent(int eventID);

        void insertUser(User theUser);
        void updateUser(User theUser);
        void delteUser(int userID);
        void addUserToEvent(int userID,int eventID);
        void removeUserFromEvent(int userID, int eventID);

        void insertEvent(Event theEvent);
        void deleteEvent(int eventID);
        List<Event> getAllEvents();
        List<Event> getEventsByUser(int userID);
    }
}
