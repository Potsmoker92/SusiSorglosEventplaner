using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace susisorglos_Datenbank
{
    class DataManagement : IDataManagement
    {
        private static bool isConnectionCreated = false;
        private static string strConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='c:\\users\\tim\\documents\\visual studio 2015\\Projects\\susisorglos_Datenbank\\susisorglos_Datenbank\\Database1.mdf';Integrated Security=True";
        private static SqlConnection conn = new SqlConnection(strConnection);
        public string strQuery = "";

        public void addUserToEvent(int userID, int eventID)
        {
            conn.Open();
            conn.Close();
            throw new NotImplementedException();
        }

        public void deleteEvent(int eventID)
        {
            throw new NotImplementedException();
        }

        public void delteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Event> getAllEvents()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<User> getUsersByEvent(int eventID)
        {
            throw new NotImplementedException();
        }

        public void insertEvent(Event theEvent)
        {
            throw new NotImplementedException();
        }

        public void insertUser(User theUser)
        {
            throw new NotImplementedException();
        }

        public void removeUserFromEvent(int userID, int eventID)
        {
            throw new NotImplementedException();
        }

        public void updateUser(User theUser)
        {
            throw new NotImplementedException();
        }
    }
}
