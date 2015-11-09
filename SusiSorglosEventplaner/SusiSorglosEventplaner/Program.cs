using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SusiSorglosEventplaner
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Tim Test datenbank zugriff
            DataManagement manageD = new DataManagement();
            List<User> users =  manageD.getAllusers();
            List<Event> events = manageD.getAllEvents();
            // Tim ende
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
