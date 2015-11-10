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
    }
}
