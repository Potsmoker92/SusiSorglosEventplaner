using susisorglos_Datenbank;
using System.Collections.Generic;

namespace SusiSorglosEventplaner {

    public class FachkonzeptSortiert : iFachkonzept {

        public IDataManagement Datenhaltung { get; set; }

        public FachkonzeptSortiert(IDataManagement datenhaltung) { Datenhaltung = datenhaltung; }

        public List<User> getAllusers()
        {
            List<User> tmp = this.Datenhaltung.getAllusers();
            tmp.Sort((x, y) => x.ID.CompareTo(y.ID));
            return tmp;
        }


        public List<Event> getAllEvents() { 
            List<Event> tmp = this.Datenhaltung.getEvents();
            tmp.Sort((x,y) => x.ID.CompareTo(y.ID)); 
            return tmp; 
        }

        public List<User> getUserByEvent(int eventID) {
            List<User> tmp = this.Datenhaltung.getUserbyEvent(eventID); 
            tmp.Sort((x, y) => x.ID.CompareTo(y.ID));
            return tmp; 
        }

        public List<User> getEventbyUser(int userID)
        {
            List<User> tmp = this.Datenhaltung.getUserbyEvent(eventid);
            tmp.Sort((x, y) => x.ID.CompareTo(y.ID));
            return tmp;
        }

        public User theUser getUser(int userID) { return this.Datenhaltung.getUser(userID); }

        public void insertUser(User theUser) { this.Datenhaltung.insertUser(theUser); }
        public void updateUser(User theUser) { this.Datenhaltung.updateUser(theUser); }
        public void deleteUser(int userID) { this.Datenhaltung.deleteUser(userID); }

        public void addUserToEvent(int userID, int eventID) { this.Datenhaltung.addUserToEvent(userID, eventID); }
        public void removeUserToEvent(int userID, int eventID) { this.Datenhaltung.removeUserToEvent(userID, eventID); }

        public void insertEvent(Event theEvent) { this.Datenhaltung.insertEvent(theEvent); }
        public void deleteEvent(Event theEvent) { this.Datenhaltung.deleteEvent(theEvent); }
        
    }

}
