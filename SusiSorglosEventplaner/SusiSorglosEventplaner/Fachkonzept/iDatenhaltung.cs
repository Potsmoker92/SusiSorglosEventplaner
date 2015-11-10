using susisorglos_Datenbank;
using System.Collections.Generic;

namespace SusiSorglosEventplaner
{

    public interface iDatenhaltung {

        List<User> getAllusers();
        List<Event> getAllEvents(); 
        List<User> getUserByEvent(int eventID); 
        List<Event> getEventbyUser(int userID); 
        

        User  getUser(int userID); 
        void insertUser(User theUser); 
        void updateUser(User theUser); 
        void deleteUser(int userID); 

        void addUserToEvent(int userID, int eventID); 
        void removeUserToEvent(int userID, int eventID); 
  
        void insertEvent(Event theEvent); 
        void deleteEvent(Event theEvent); 
    }
}
