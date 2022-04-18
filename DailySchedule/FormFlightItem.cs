using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DailySchedule
{
    public partial class formFlightItem : Form
    {
        clsManageSqliteDB clsSQLite = new clsManageSqliteDB();

        public formFlightItem()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formFlightItem_Load(object sender, EventArgs e)
        {
            try
            {
                // add items from datatable to Formation C/S combobox
                string query = "SELECT name FROM formation";
                DataTable dTable = clsSQLite.GetDataTable(query);
                cmbForm.DataSource = dTable;
                cmbForm.DisplayMember = "name";

                // add items from datatable to FORNT SEAT combobox
                //query = "SELECT name FROM formation";
                dTable = clsSQLite.GetDataTable("SELECT name FROM ip");
                DataTable dTable2 = clsSQLite.GetDataTable("SELECT name FROM sp");
                dTable.Merge(dTable2);
                cmbFrontSeat.DataSource = dTable;
                cmbFrontSeat.DisplayMember = "name";

                cmbRearSeat.DataSource = dTable;
                cmbRearSeat.DisplayMember = "name";

                dTable = clsSQLite.GetDataTable("SELECT name FROM mix");
                cmbMix.DataSource = dTable;
                cmbMix.DisplayMember = "name";

                dTable = clsSQLite.GetDataTable("SELECT name FROM route");
                cmbRoute.DataSource = dTable;
                cmbRoute.DisplayMember = "name";

                dTable = clsSQLite.GetDataTable("SELECT content FROM freq");
                cmbFreq.DataSource = dTable;
                cmbFreq.DisplayMember = "content";

                dTable = clsSQLite.GetDataTable("SELECT content FROM scl");
                cmbScl.DataSource = dTable;
                cmbScl.DisplayMember = "content";

                dTable = clsSQLite.GetDataTable("SELECT name FROM rmm");
                cmbRmm.DataSource = dTable;
                cmbRmm.DisplayMember = "name";

                dTable = clsSQLite.GetDataTable("SELECT chop || \" \" || tacan as chop_tac FROM formation");
                cmbChopTac.DataSource = dTable;
                cmbChopTac.DisplayMember = "chop_tac";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Loading data from database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }

        }
    }
}
