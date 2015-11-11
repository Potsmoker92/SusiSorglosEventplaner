using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SusiSorglosEventplaner
{
    public partial class GUI : Form
    {
        private iFachkonzept fachkonzept;

        public GUI()
        {

            fachkonzept = new FachkonzeptSortiert(new DataManagement());
            //fachkonzept = new FachkonzeptUnsortiert(new DataManagement());

            Application.EnableVisualStyles();
            InitializeComponent();
            SetGridUserRights();
            FillGrid();
            Application.Run(this);
        }
    
        private void SetGridUserRights()
        {
            dataGridViewPerson.AllowUserToAddRows = true;
            dataGridViewPerson.AllowUserToDeleteRows = true;
            dataGridViewPerson.MultiSelect = false;

            dataGridViewEvent.MultiSelect = false;
            dataGridViewEvent.AllowUserToAddRows = true;
            dataGridViewEvent.AllowUserToDeleteRows = true;
        }

        private void FillGrid()
        {

            dataGridViewPerson.DataSource = fachkonzept.getAllusers();
            dataGridViewPerson.Refresh();

            dataGridViewEvent.DataSource = fachkonzept.getAllEvents();
            dataGridViewEvent.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fachkonzept.insertUser(new User() { strVorname = textBox1.Text,
                                                strNachname = textBox2.Text
                                                });
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User usr = new User();
            int userID = 0;
            Int32.TryParse(textBox5.Text, out  userID);
            usr.userID = userID;

            usr.strVorname = textBox4.Text;
            usr.strNachname = textBox3.Text;

            fachkonzept.updateUser(usr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int userID = -1;
            Int32.TryParse(textBox6.Text, out userID);
            fachkonzept.deleteUser(userID);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Event evnt = new Event();

            evnt.strEventname = textBox12.Text;
            evnt.strEventLocation = textBox11.Text;

            evnt.dateEventStart = dateTimePicker1.Value;
            evnt.dateEventEnd = dateTimePicker2.Value;

            fachkonzept.insertEvent(evnt);
        }

    

        private void label10_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = -1;
            Int32.TryParse(textBox7.Text, out id);
            fachkonzept.deleteEvent(new Event() { eventID = id });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Event evnt = new Event();
            int id = -1;
            Int32.TryParse(textBox10.Text, out id);
            evnt.eventID = id;
            evnt.strEventname = textBox9.Text;
            evnt.strEventLocation = textBox8.Text;
            evnt.dateEventStart = dateTimePicker4.Value;
            evnt.dateEventEnd = dateTimePicker3.Value;

            fachkonzept.insertEvent(evnt);
        }
    }
}
