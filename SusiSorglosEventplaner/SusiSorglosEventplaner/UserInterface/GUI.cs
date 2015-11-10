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
        public GUI()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
            
            Application.Run(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetGridUserRights();
            FillGrid();
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
            Action action = new Action();
            dataGridViewPerson.DataSource = action.ListUser();
            dataGridViewPerson.Refresh();

            dataGridViewEvent.DataSource = action.ListEvent();
            dataGridViewEvent.Refresh();
        }
    }
}
