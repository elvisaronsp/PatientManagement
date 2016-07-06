namespace Company.PatientManagementUI
{
    partial class PatientSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbx_external = new System.Windows.Forms.Button();
            this.btn_load_all_patients = new System.Windows.Forms.Button();
            this.txbx_firstname = new System.Windows.Forms.TextBox();
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_last_name = new System.Windows.Forms.Label();
            this.txbx_lastname = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbx_external);
            this.panel1.Controls.Add(this.btn_load_all_patients);
            this.panel1.Controls.Add(this.txbx_firstname);
            this.panel1.Controls.Add(this.lbl_firstname);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.lbl_last_name);
            this.panel1.Controls.Add(this.txbx_lastname);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 524);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Start typing name to search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "right mouse click on patient for action";
            // 
            // txbx_external
            // 
            this.txbx_external.Location = new System.Drawing.Point(672, 115);
            this.txbx_external.Name = "txbx_external";
            this.txbx_external.Size = new System.Drawing.Size(117, 23);
            this.txbx_external.TabIndex = 16;
            this.txbx_external.Text = "Add From External System";
            this.txbx_external.UseVisualStyleBackColor = true;
            this.txbx_external.Click += new System.EventHandler(this.txbx_external_Click);
            // 
            // btn_load_all_patients
            // 
            this.btn_load_all_patients.Location = new System.Drawing.Point(672, 57);
            this.btn_load_all_patients.Name = "btn_load_all_patients";
            this.btn_load_all_patients.Size = new System.Drawing.Size(117, 23);
            this.btn_load_all_patients.TabIndex = 15;
            this.btn_load_all_patients.Text = "All Patients";
            this.btn_load_all_patients.UseVisualStyleBackColor = true;
            this.btn_load_all_patients.Click += new System.EventHandler(this.btn_load_all_patients_Click);
            // 
            // txbx_firstname
            // 
            this.txbx_firstname.Location = new System.Drawing.Point(144, 104);
            this.txbx_firstname.Name = "txbx_firstname";
            this.txbx_firstname.Size = new System.Drawing.Size(199, 20);
            this.txbx_firstname.TabIndex = 14;
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Location = new System.Drawing.Point(50, 104);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(57, 13);
            this.lbl_firstname.TabIndex = 13;
            this.lbl_firstname.Text = "First Name";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(672, 86);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(117, 23);
            this.btn_add.TabIndex = 12;
            this.btn_add.Text = "Add Patient";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(763, 316);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // lbl_last_name
            // 
            this.lbl_last_name.AutoSize = true;
            this.lbl_last_name.Location = new System.Drawing.Point(49, 69);
            this.lbl_last_name.Name = "lbl_last_name";
            this.lbl_last_name.Size = new System.Drawing.Size(58, 13);
            this.lbl_last_name.TabIndex = 10;
            this.lbl_last_name.Text = "Last Name";
            // 
            // txbx_lastname
            // 
            this.txbx_lastname.Location = new System.Drawing.Point(144, 69);
            this.txbx_lastname.Name = "txbx_lastname";
            this.txbx_lastname.Size = new System.Drawing.Size(199, 20);
            this.txbx_lastname.TabIndex = 9;
            // 
            // PatientSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 524);
            this.Controls.Add(this.panel1);
            this.Name = "PatientSearch";
            this.Text = "Patient Seach";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button txbx_external;
        private System.Windows.Forms.Button btn_load_all_patients;
        private System.Windows.Forms.TextBox txbx_firstname;
        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_last_name;
        private System.Windows.Forms.TextBox txbx_lastname;
        private System.Windows.Forms.Label label2;
    }
}

