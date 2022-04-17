using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DailySchedule
{
    public partial class formManageTables : Form
    {
        struct TableName
        {
            public string InShow;
            public string InDB;
            public string[] Columns;
            public TableName(string x, string y, string[] z)
            {
                InShow = x;
                InDB = y;
                Columns = z;
            }
        };
        TableName[] oTableNames;
        int iTableNamesLength;
        clsManageSqliteDB clsSQLite = new clsManageSqliteDB();
        public formManageTables()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            // validate table columns are set
            if (oTableNames[cmbTableNames.SelectedIndex].Columns.Length <= 0)
            {
                MessageBox.Show("Please confirm with columns: now 0");
                return;
            }
            frmAddNewFormation frmItem = new frmAddNewFormation();
            frmItem._columns = oTableNames[cmbTableNames.SelectedIndex].Columns;
            frmItem._table_name = oTableNames[cmbTableNames.SelectedIndex].InDB;
            frmItem.FormClosing += FrmItem_FormClosing;
            frmItem.Show();
        }

        private void FrmItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                int curSelectedId = cmbTableNames.SelectedIndex;
                string query = "SELECT * FROM " + oTableNames[curSelectedId].InDB;
                DataTable dTable = clsSQLite.GetDataTable(query);
                dtgTable.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in RefreshData():\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void InitializeSelecteTableCombobox()
        {
            iTableNamesLength = 2;
            oTableNames = new TableName[105];
            oTableNames[0] = new TableName("Lessons", "lessons", new string[]{ "name", "duration", "periods" });
            oTableNames[1] = new TableName("Formation", "formation", new string[] { "content" });

            cmbTableNames.Items.Clear();
            for (int i = 0; i < iTableNamesLength; i++)
            {
                cmbTableNames.Items.Add(oTableNames[i].InShow);
            }
            cmbTableNames.SelectedIndex = 0;
            cmbTableNames.SelectedIndexChanged += CmbTableNames_SelectedIndexChanged;
        }

        private void CmbTableNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
            //throw new NotImplementedException();
        }

        private void frmManageTables_load(object sender, EventArgs e)
        {
            InitializeSelecteTableCombobox();
            this.Cursor = Cursors.WaitCursor;
            this.MaximizeBox = false;
            dtgTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgTable.MultiSelect = false;
            RefreshData();
            this.Cursor = Cursors.Default;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // validate rows <= 0 (including default empty row)
            if (dtgTable.Rows.Count <= 1)
            {
                MessageBox.Show("No item to edit", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // validate table columns are set
            if (oTableNames[cmbTableNames.SelectedIndex].Columns.Length <= 0)
            {
                MessageBox.Show("Please confirm with columns: now 0");
                return;
            }

            frmAddNewFormation frmItem = new frmAddNewFormation();
            frmItem._isNewItem = false;
            frmItem._item_id = dtgTable.SelectedRows[0].Cells["id"].Value.ToString();
            frmItem._table_name = oTableNames[cmbTableNames.SelectedIndex].InDB;
            Array.Resize(ref frmItem._columns, oTableNames[cmbTableNames.SelectedIndex].Columns.Length);
            oTableNames[cmbTableNames.SelectedIndex].Columns.CopyTo(frmItem._columns, 0);
            Array.Resize(ref frmItem._items, oTableNames[cmbTableNames.SelectedIndex].Columns.Length);
            oTableNames[cmbTableNames.SelectedIndex].Columns.CopyTo(frmItem._items, 0);
            for (int i = 0; i < frmItem._items.Length; i++)
            {
                frmItem._items[i] = dtgTable.SelectedRows[0].Cells[frmItem._items[i]].Value.ToString();
            }
            frmItem.FormClosing += FrmItem_FormClosing;

            frmItem.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //check that either there are formation items in grid list, if not then return without doing any task.
            if (dtgTable.Rows.Count == 0) { MessageBox.Show("No item in list to delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

            //delete selected inventory item, and before deleting ask for delete confirmation by message box
            if (MessageBox.Show("Delete Selected Item, are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //read item_code from grid control and store it into selected_item_code string variable
                string selected_item_id = dtgTable.SelectedRows[0].Cells["id"].Value.ToString();
                //make query to delete with selected item_id taking from variable
                string query = "DELETE FROM " + oTableNames[cmbTableNames.SelectedIndex].InDB + " WHERE id = " + selected_item_id;
                //execute query
                try
                {
                    clsSQLite.ExecuteQuery(query);
                    RefreshData();
                    MessageBox.Show("Deleted Sucessfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Deleting Data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
