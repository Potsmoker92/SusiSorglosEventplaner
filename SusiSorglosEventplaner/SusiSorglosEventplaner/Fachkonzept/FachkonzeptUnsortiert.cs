using susisorglos_Datenbank;
using System.Collections.Generic;

namespace SusiSorglosEventplaner
{

    public class FachkonzeptUnsortiert : iFachkonzept {

        public IDataManagement Datenhaltung { get; set; }

        public FachkonzeptUnsortiert(IDataManagement datenhaltung) { Datenhaltung = datenhaltung; }

        public List<User> getAllusers() { return this.Datenhaltung.getAllusers(); }


        public List<Event> getAllEvents() { return this.Datenhaltung.getEvents(); }


        public List<User> getUserByEvent(int eventID) { this.Datenhaltung.getUserbyEvent(eventID); }


        public List<Event> getEventbyUser(int userID) { this.Datenhaltung.getUserbyEvent(eventid); }


        public User getUser(int userID) { return this.Datenhaltung.getUser(userID); }

        public void insertUser(User theUser) { this.Datenhaltung.insertUser(theUser); }
        public void updateUser(User theUser) { this.Datenhaltung.updateUser(theUser); }
        public void deleteUser(int userID) { this.Datenhaltung.deleteUser(userID); }

        public void addUserToEvent(int userID, int eventID) { this.Datenhaltung.addUserToEvent(userID, eventID); }
        public void removeUserToEvent(int userID, int eventID) { this.Datenhaltung.removeUserToEvent(userID, eventID); }

        public void insertEvent(Event theEvent) { this.Datenhaltung.insertEvent(theEvent); }
        public void deleteEvent(Event theEvent) { this.Datenhaltung.deleteEvent(theEvent); }
    }

}
