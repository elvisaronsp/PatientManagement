namespace Company.PatientManagementUI
{
    partial class AddEditPatientForm
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cb_sex = new System.Windows.Forms.ComboBox();
            this.lbl_sex = new System.Windows.Forms.Label();
            this.dtp_birthdate = new System.Windows.Forms.DateTimePicker();
            this.lbl_birthdate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_state = new System.Windows.Forms.ComboBox();
            this.txbx_street = new System.Windows.Forms.TextBox();
            this.lbl_street = new System.Windows.Forms.Label();
            this.txbx_city = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.txbx_work_phone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbx_home_phone = new System.Windows.Forms.TextBox();
            this.txbx_zip = new System.Windows.Forms.TextBox();
            this.lbl_zip = new System.Windows.Forms.Label();
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.txbx_firstname = new System.Windows.Forms.TextBox();
            this.lbl_middle_name = new System.Windows.Forms.Label();
            this.txbx_middlename = new System.Windows.Forms.TextBox();
            this.lbl_lame = new System.Windows.Forms.Label();
            this.txbx_lastname = new System.Windows.Forms.TextBox();
            this.lbl_mrn = new System.Windows.Forms.Label();
            this.txbx_mrn = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(153, 287);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(77, 23);
            this.btn_cancel.TabIndex = 42;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Location = new System.Drawing.Point(51, 287);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 41;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;

            // 
            // cb_sex
            // 
            this.cb_sex.FormattingEnabled = true;
            this.cb_sex.Items.AddRange(new object[] {
            "M",
            "F ",
            "U"});
            this.cb_sex.Location = new System.Drawing.Point(278, 90);
            this.cb_sex.Name = "cb_sex";
            this.cb_sex.Size = new System.Drawing.Size(39, 21);
            this.cb_sex.TabIndex = 36;
            // 
            // lbl_sex
            // 
            this.lbl_sex.AutoSize = true;
            this.lbl_sex.Location = new System.Drawing.Point(247, 94);
            this.lbl_sex.Name = "lbl_sex";
            this.lbl_sex.Size = new System.Drawing.Size(25, 13);
            this.lbl_sex.TabIndex = 40;
            this.lbl_sex.Text = "Sex";
            // 
            // dtp_birthdate
            // 
            this.dtp_birthdate.CalendarTrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtp_birthdate.CustomFormat = "MM/dd/yyyy";
            this.dtp_birthdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_birthdate.Location = new System.Drawing.Point(119, 90);
            this.dtp_birthdate.Name = "dtp_birthdate";
            this.dtp_birthdate.Size = new System.Drawing.Size(101, 20);
            this.dtp_birthdate.TabIndex = 34;
            // 
            // lbl_birthdate
            // 
            this.lbl_birthdate.AutoSize = true;
            this.lbl_birthdate.Location = new System.Drawing.Point(59, 94);
            this.lbl_birthdate.Name = "lbl_birthdate";
            this.lbl_birthdate.Size = new System.Drawing.Size(54, 13);
            this.lbl_birthdate.TabIndex = 39;
            this.lbl_birthdate.Text = "Birth Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_state);
            this.groupBox1.Controls.Add(this.txbx_street);
            this.groupBox1.Controls.Add(this.lbl_street);
            this.groupBox1.Controls.Add(this.txbx_city);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_city);
            this.groupBox1.Controls.Add(this.txbx_work_phone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbx_home_phone);
            this.groupBox1.Controls.Add(this.txbx_zip);
            this.groupBox1.Controls.Add(this.lbl_zip);
            this.groupBox1.Location = new System.Drawing.Point(33, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 149);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patient Address";
            // 
            // cb_state
            // 
            this.cb_state.FormattingEnabled = true;
            this.cb_state.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.cb_state.Location = new System.Drawing.Point(280, 64);
            this.cb_state.Name = "cb_state";
            this.cb_state.Size = new System.Drawing.Size(97, 21);
            this.cb_state.TabIndex = 12;
            // 
            // txbx_street
            // 
            this.txbx_street.Location = new System.Drawing.Point(93, 34);
            this.txbx_street.Name = "txbx_street";
            this.txbx_street.Size = new System.Drawing.Size(261, 20);
            this.txbx_street.TabIndex = 8;
            // 
            // lbl_street
            // 
            this.lbl_street.AutoSize = true;
            this.lbl_street.Location = new System.Drawing.Point(26, 34);
            this.lbl_street.Name = "lbl_street";
            this.lbl_street.Size = new System.Drawing.Size(35, 13);
            this.lbl_street.TabIndex = 7;
            this.lbl_street.Text = "Street";
            // 
            // txbx_city
            // 
            this.txbx_city.Location = new System.Drawing.Point(93, 67);
            this.txbx_city.Name = "txbx_city";
            this.txbx_city.Size = new System.Drawing.Size(133, 20);
            this.txbx_city.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Work Phone";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Location = new System.Drawing.Point(26, 70);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(24, 13);
            this.lbl_city.TabIndex = 9;
            this.lbl_city.Text = "City";
            // 
            // txbx_work_phone
            // 
            this.txbx_work_phone.Location = new System.Drawing.Point(315, 108);
            this.txbx_work_phone.Name = "txbx_work_phone";
            this.txbx_work_phone.Size = new System.Drawing.Size(133, 20);
            this.txbx_work_phone.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Home Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "State";
            // 
            // txbx_home_phone
            // 
            this.txbx_home_phone.Location = new System.Drawing.Point(93, 108);
            this.txbx_home_phone.Name = "txbx_home_phone";
            this.txbx_home_phone.Size = new System.Drawing.Size(133, 20);
            this.txbx_home_phone.TabIndex = 14;
            // 
            // txbx_zip
            // 
            this.txbx_zip.Location = new System.Drawing.Point(444, 67);
            this.txbx_zip.Name = "txbx_zip";
            this.txbx_zip.Size = new System.Drawing.Size(59, 20);
            this.txbx_zip.TabIndex = 13;
            // 
            // lbl_zip
            // 
            this.lbl_zip.AutoSize = true;
            this.lbl_zip.Location = new System.Drawing.Point(391, 70);
            this.lbl_zip.Name = "lbl_zip";
            this.lbl_zip.Size = new System.Drawing.Size(47, 13);
            this.lbl_zip.TabIndex = 13;
            this.lbl_zip.Text = "ZipCode";
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Location = new System.Drawing.Point(284, 63);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(57, 13);
            this.lbl_firstname.TabIndex = 38;
            this.lbl_firstname.Text = "First Name";
            // 
            // txbx_firstname
            // 
            this.txbx_firstname.Location = new System.Drawing.Point(347, 59);
            this.txbx_firstname.Name = "txbx_firstname";
            this.txbx_firstname.Size = new System.Drawing.Size(133, 20);
            this.txbx_firstname.TabIndex = 31;
            // 
            // lbl_middle_name
            // 
            this.lbl_middle_name.AutoSize = true;
            this.lbl_middle_name.Location = new System.Drawing.Point(486, 63);
            this.lbl_middle_name.Name = "lbl_middle_name";
            this.lbl_middle_name.Size = new System.Drawing.Size(69, 13);
            this.lbl_middle_name.TabIndex = 35;
            this.lbl_middle_name.Text = "Middle Name";
            // 
            // txbx_middlename
            // 
            this.txbx_middlename.Location = new System.Drawing.Point(561, 59);
            this.txbx_middlename.Name = "txbx_middlename";
            this.txbx_middlename.Size = new System.Drawing.Size(73, 20);
            this.txbx_middlename.TabIndex = 32;
            // 
            // lbl_lame
            // 
            this.lbl_lame.AutoSize = true;
            this.lbl_lame.Location = new System.Drawing.Point(59, 63);
            this.lbl_lame.Name = "lbl_lame";
            this.lbl_lame.Size = new System.Drawing.Size(58, 13);
            this.lbl_lame.TabIndex = 33;
            this.lbl_lame.Text = "Last Name";
            // 
            // txbx_lastname
            // 
            this.txbx_lastname.Location = new System.Drawing.Point(132, 59);
            this.txbx_lastname.Name = "txbx_lastname";
            this.txbx_lastname.Size = new System.Drawing.Size(133, 20);
            this.txbx_lastname.TabIndex = 29;
            // 
            // lbl_mrn
            // 
            this.lbl_mrn.AutoSize = true;
            this.lbl_mrn.Location = new System.Drawing.Point(59, 30);
            this.lbl_mrn.Name = "lbl_mrn";
            this.lbl_mrn.Size = new System.Drawing.Size(32, 13);
            this.lbl_mrn.TabIndex = 30;
            this.lbl_mrn.Text = "MRN";
            // 
            // txbx_mrn
            // 
            this.txbx_mrn.Location = new System.Drawing.Point(97, 27);
            this.txbx_mrn.Name = "txbx_mrn";
            this.txbx_mrn.Size = new System.Drawing.Size(74, 20);
            this.txbx_mrn.TabIndex = 28;
            // 
            // AddEditPatientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 367);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.cb_sex);
            this.Controls.Add(this.lbl_sex);
            this.Controls.Add(this.dtp_birthdate);
            this.Controls.Add(this.lbl_birthdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_firstname);
            this.Controls.Add(this.txbx_firstname);
            this.Controls.Add(this.lbl_middle_name);
            this.Controls.Add(this.txbx_middlename);
            this.Controls.Add(this.lbl_lame);
            this.Controls.Add(this.txbx_lastname);
            this.Controls.Add(this.lbl_mrn);
            this.Controls.Add(this.txbx_mrn);
            this.Name = "AddEditPatientForm";
            this.Text = "AddEditPatient";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cb_sex;
        private System.Windows.Forms.Label lbl_sex;
        private System.Windows.Forms.DateTimePicker dtp_birthdate;
        private System.Windows.Forms.Label lbl_birthdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_state;
        private System.Windows.Forms.TextBox txbx_street;
        private System.Windows.Forms.Label lbl_street;
        private System.Windows.Forms.TextBox txbx_city;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.TextBox txbx_work_phone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbx_home_phone;
        private System.Windows.Forms.TextBox txbx_zip;
        private System.Windows.Forms.Label lbl_zip;
        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.TextBox txbx_firstname;
        private System.Windows.Forms.Label lbl_middle_name;
        private System.Windows.Forms.TextBox txbx_middlename;
        private System.Windows.Forms.Label lbl_lame;
        private System.Windows.Forms.TextBox txbx_lastname;
        private System.Windows.Forms.Label lbl_mrn;
        private System.Windows.Forms.TextBox txbx_mrn;
    }
}