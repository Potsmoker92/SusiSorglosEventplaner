using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SusiSorglosEventplaner

{
    class DataManagement : IDataManagement
    {
        private static string strConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True";
        private static SqlConnection conn = new SqlConnection(strConnection);
        public string strQuery = "";

        public void addUserToEvent(int userID, int eventID)
        {
            strQuery = "INSERT INTO T_teilnahmen (f_p_userID, f_p_eventID) VALUES ('" + userID + "','" + eventID + "')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteEvent(int eventID)
        {
            strQuery = "DELETE FROM T_events WHERE eventID =" + eventID;
            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void delteUser(int userID)
        {
            strQuery = "DELETE FROM T_user WHERE userID = " + userID;
            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Event> getAllEvents()
        {
            List<Event> lstEvents = new List<Event>();
            strQuery = "SELECT * FROM T_events";
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event theEvent = new Event
                        {
                            eventID = (int)reader["userID"],
                            strEventname = (string)reader["eventName"],
                            strEventLocation = (string)reader["eventLocation"],
                            dateEventStart = (DateTime)reader["eventStart"],
                            dateEventEnd = (DateTime)reader["eventEnd"]
                        };
                        lstEvents.Add(theEvent);
                    }
                }
            }
            conn.Close();
            return lstEvents;
        }

        public List<User> getAllusers()
        {
            List<User> lstUser = new List<User>();
            strQuery = "SELECT * FROM T_User";
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User theUser = new User
                        {
                            userID = (int)reader["userID"],
                            strVorname = (string)reader["vorname"],
                            strNachname = (string)reader["nachname"]
                        };
                        lstUser.Add(theUser);
                    }
                }
            }
            conn.Close();
            return lstUser;
        }

        public List<Event> getEventsByUser(int userID)
        {
            throw new NotImplementedException();
        }

        public User getUser(int userID)
        {
            User theUser = new User();
            strQuery = "SELECT * FROM T_User WHERE id ='" + userID + "' LIMIT 1";
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(strQuery, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User tempUser = new User
                        {
                            userID = (int)reader["userID"],
                            strVorname = (string)reader["vorname"],
                            strNachname = (string)reader["nachname"]
                        };
                        theUser = tempUser;
                    }
                }
            }
            conn.Close();
            return theUser;
        }

        public List<User> getUsersByEvent(int eventID)
        {
            throw new NotImplementedException();
        }

        public void insertEvent(Event theEvent)
        {
            strQuery = "INSERT INTO T_events (eventname,eventLocation,eventStart,eventEnd) VALUES ('" + theEvent.strEventname + "','" + theEvent.strEventLocation + "','" + theEvent.dateEventStart + "','" + theEvent.dateEventEnd + "')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close(); ;
        }

        public void insertUser(User theUser)
        {
            strQuery = "INSERT INTO T_user (vorname,nachname) VALUE ('" + theUser.strVorname + "','" + theUser.strNachname + "')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void removeUserFromEvent(int userID, int eventID)
        {
            strQuery = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateUser(User theUser)
        {
            throw new NotImplementedException();
        }
    }
}
