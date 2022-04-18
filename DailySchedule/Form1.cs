using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailySchedule
{
    public partial class Form1 : Form
    {
        clsManageSqliteDB clsSQLite = new clsManageSqliteDB();
        DataGridView[] dtgFlights = new DataGridView[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgFlights[0] = dataGridView1;
            dtgFlights[1] = dataGridView2;
            dtgFlights[2] = dataGridView3;
            dtgFlights[3] = dataGridView4;
            for (int i = 0; i < 4; i++)
            {
                string query = "SELECT * FROM schedules WHERE shift = " + i.ToString();
                DataTable dTable = clsSQLite.GetDataTable(query);
                dtgFlights[i].DataSource = dTable;
            }
        }

        private void btnManageTables_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            formFlightItem formItem = new formFlightItem();
            formItem.Show();
        }

        private void btnManageTables_Click_1(object sender, EventArgs e)
        {
            formManageTables formMT = new formManageTables();
            formMT.Show();
        }
    }
}
