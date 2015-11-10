using susisorglos_Datenbank;
using System.Collections.Generic;

namespace SusiSorglosEventplaner {

    public class FachkonzeptSortiert : iFachkonzept, IDataManagement
    {

        public DataManagement Datenhaltung;

        public FachkonzeptSortiert(DataManagement datenhaltung) { Datenhaltung = datenhaltung; }

        public List<User> getAllusers()
        {
            List<User> tmp = this.Datenhaltung.getAllusers();
            tmp.Sort((x, y) => x.userID.CompareTo(y.userID));
            return tmp;
        }


        public List<Event> getAllEvents() { 
            List<Event> tmp = this.Datenhaltung.getAllEvents();
            tmp.Sort((x,y) => x.eventID.CompareTo(y.eventID)); 
            return tmp; 
        }

        public List<User> getUserByEvent(int eventID) {
            List<User> tmp = this.Datenhaltung.getUsersByEvent(eventID); 
            tmp.Sort((x, y) => x.userID.CompareTo(y.userID));
            return tmp; 
        }

        public List<Event> getEventbyUser(int userID)
        {
            List<Event> tmp = this.Datenhaltung.getEventsByUser(userID);
            tmp.Sort((x, y) => x.eventID.CompareTo(y.eventID));
            return tmp;
        }

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
