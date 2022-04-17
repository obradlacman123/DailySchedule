using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DailySchedule
{
    public partial class frmAddNewFormation : Form
    {
        //Adding Class ref.
        clsManageSqliteDB clsSQLite = new clsManageSqliteDB();
        
        //public properties
        public Boolean _isNewItem = true;
        public string _table_name;
        public string[] _items;
        public string _item_id;
        public string[] _columns;

        // private properties
        private List<Label> _ctrlLabels;
        private List<TextBox> _ctrlTextBoxes;

        public frmAddNewFormation()
        {
            InitializeComponent();
        }

        private void AddNewItem()
        {
            try
            {
                string query = string.Empty;
                string query_value = string.Empty;

                query = "INSERT INTO " + _table_name + " ( ";
                for (int i = 0; i < flpLeft.Controls.Count; i++)
                {
                    query += (i == 0 ? "" : ", ") + flpLeft.Controls[i].Text;
                    query_value += (i == 0 ? "'" : "', '") + flpRight.Controls[i].Text;
                }
                query = query + ") VALUES ("
                + query_value + "' )";

                int result = clsSQLite.ExecuteQuery(query);
                MessageBox.Show(result + " item(s) successfully added");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Saving Data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateItem()
        {
            try
            {
                string query = string.Empty;
                query = "UPDATE " + _table_name + " SET ";
                for (int i = 0; i < flpLeft.Controls.Count; i++)
                {
                    query += (i == 0 ? "" : "', ") + flpLeft.Controls[i].Text + " = '" + flpRight.Controls[i].Text;
                }
                query += "' WHERE id = " + _item_id;

                int result = clsSQLite.ExecuteQuery(query);
                MessageBox.Show(result + " item(s) successfully updated");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Saving Data:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validate item content before inserting
            for (int i = 0; i < flpRight.Controls.Count; i++)
            {
                if (string.IsNullOrEmpty(flpRight.Controls[i].Text)) { MessageBox.Show("Please fill all inputs", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); flpRight.Controls[i].Focus(); return; }
            }

            if (!_isNewItem)
            {
                UpdateItem();
            }
            else
            {
                AddNewItem();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewFormation_Load(object sender, EventArgs e)
        {
            this.Text = ("\"" + _table_name + "\" table").ToUpper();
            //_items = new string[] { };
            _ctrlLabels = new List<Label>();
            _ctrlTextBoxes = new List<TextBox>();

            flpRight.FlowDirection = FlowDirection.TopDown;
            flpRight.WrapContents = true;
            for (int i = 0; i < _columns.Length; i++)
            {
                // new label in left panel
                var labelTemp = new Label();
                labelTemp.Text = _columns[i];
                labelTemp.Width = flpLeft.Width - 40;
                labelTemp.Height = 30;
                labelTemp.TextAlign = ContentAlignment.MiddleRight;
                labelTemp.Margin = new Padding(20, 5, 20, 5);
                _ctrlLabels.Add(labelTemp);

                // new textbox in left panel
                var txtTemp = new TextBox();
                txtTemp.Width = flpRight.Width - 40;
                txtTemp.Height = 30;
                txtTemp.Margin = new Padding(20, 5, 20, 5);
                if (_isNewItem == false)
                {
                    txtTemp.Text = _items[i];
                } else
                {

                }
                _ctrlTextBoxes.Add(txtTemp);

                flpLeft.Controls.Add(labelTemp);
                flpRight.Controls.Add(txtTemp);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
