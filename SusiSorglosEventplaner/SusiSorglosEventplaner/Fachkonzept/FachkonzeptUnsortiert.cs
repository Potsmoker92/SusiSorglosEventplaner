using susisorglos_Datenbank;
using System.Collections.Generic;

namespace SusiSorglosEventplaner
{

    public class FachkonzeptUnsortiert : iFachkonzept {

        public DataManagement Datenhaltung { get; set; }

        public FachkonzeptUnsortiert(DataManagement datenhaltung) { Datenhaltung = datenhaltung; }

        public List<User> getAllusers() { return this.Datenhaltung.getAllusers(); }


        public List<Event> getAllEvents() { return this.Datenhaltung.getAllEvents(); }


        public List<User> getUserByEvent(int eventID) { return this.Datenhaltung.getUsersByEvent(eventID); }


        public List<Event> getEventbyUser(int UserID) { return this.Datenhaltung.getEventsByUser(UserID); }


        public User getUser(int userID) { return this.Datenhaltung.getUser(userID); }

        public void insertUser(User theUser) { this.Datenhaltung.insertUser(theUser); }
        public void updateUser(User theUser) { this.Datenhaltung.updateUser(theUser); }
        public void deleteUser(int userID) { this.Datenhaltung.delteUser(userID); }

        public void addUserToEvent(int userID, int eventID) { this.Datenhaltung.addUserToEvent(userID, eventID); }
        public void removeUserToEvent(int userID, int eventID) { this.Datenhaltung.removeUserFromEvent(userID, eventID); }

        public void insertEvent(Event theEvent) { this.Datenhaltung.insertEvent(theEvent); }
        public void deleteEvent(Event theEvent) { this.Datenhaltung.deleteEvent(theEvent.eventID); }
    }

}
