
namespace DailySchedule
{
    partial class formManageTables
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgTable = new System.Windows.Forms.DataGridView();
            this.addNewRowButton = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbTableNames = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "MANAGE TABLES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Table";
            // 
            // dtgTable
            // 
            this.dtgTable.AllowUserToOrderColumns = true;
            this.dtgTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTable.Location = new System.Drawing.Point(12, 108);
            this.dtgTable.Name = "dtgTable";
            this.dtgTable.RowHeadersWidth = 62;
            this.dtgTable.RowTemplate.Height = 33;
            this.dtgTable.Size = new System.Drawing.Size(776, 267);
            this.dtgTable.TabIndex = 2;
            // 
            // addNewRowButton
            // 
            this.addNewRowButton.Location = new System.Drawing.Point(12, 394);
            this.addNewRowButton.Name = "addNewRowButton";
            this.addNewRowButton.Size = new System.Drawing.Size(112, 34);
            this.addNewRowButton.TabIndex = 3;
            this.addNewRowButton.Text = "Add";
            this.addNewRowButton.UseVisualStyleBackColor = true;
            this.addNewRowButton.Click += new System.EventHandler(this.addNewRowButton_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(154, 394);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 34);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(296, 394);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 34);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbTableNames
            // 
            this.cmbTableNames.FormattingEnabled = true;
            this.cmbTableNames.Location = new System.Drawing.Point(166, 64);
            this.cmbTableNames.Name = "cmbTableNames";
            this.cmbTableNames.Size = new System.Drawing.Size(256, 33);
            this.cmbTableNames.TabIndex = 6;
            // 
            // formManageTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbTableNames);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.addNewRowButton);
            this.Controls.Add(this.dtgTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formManageTables";
            this.Text = "Manage Tables";
            this.Load += new System.EventHandler(this.frmManageTables_load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgTable;
        private System.Windows.Forms.Button addNewRowButton;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbTableNames;
    }
}