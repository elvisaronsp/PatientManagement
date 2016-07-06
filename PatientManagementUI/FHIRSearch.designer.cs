namespace Company.PatientManagementUI
{
    partial class FHIRSearch
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbl_fhir = new System.Windows.Forms.Label();
            this.lbl_header1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txbx_name = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "https://fhir-open-api-dstu2.smarthealthit.org"});
            this.comboBox1.Location = new System.Drawing.Point(105, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(485, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // lbl_fhir
            // 
            this.lbl_fhir.AutoSize = true;
            this.lbl_fhir.Location = new System.Drawing.Point(41, 62);
            this.lbl_fhir.Name = "lbl_fhir";
            this.lbl_fhir.Size = new System.Drawing.Size(58, 13);
            this.lbl_fhir.TabIndex = 1;
            this.lbl_fhir.Text = "Fhir Server";
            // 
            // lbl_header1
            // 
            this.lbl_header1.AutoSize = true;
            this.lbl_header1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_header1.Location = new System.Drawing.Point(40, 21);
            this.lbl_header1.Name = "lbl_header1";
            this.lbl_header1.Size = new System.Drawing.Size(187, 24);
            this.lbl_header1.TabIndex = 2;
            this.lbl_header1.Text = "Search FHIR Servers";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(41, 99);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 4;
            this.lbl_name.Text = "Name";
            // 
            // txbx_name
            // 
            this.txbx_name.Location = new System.Drawing.Point(105, 96);
            this.txbx_name.Name = "txbx_name";
            this.txbx_name.Size = new System.Drawing.Size(251, 20);
            this.txbx_name.TabIndex = 5;
            // 
            // btn_search
            // 
            this.btn_search.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_search.Location = new System.Drawing.Point(454, 99);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(78, 26);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(578, 102);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 237);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Right mouse click patient for options.";
            // 
            // FHIRSearch
            // 
            this.ClientSize = new System.Drawing.Size(888, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txbx_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_header1);
            this.Controls.Add(this.lbl_fhir);
            this.Controls.Add(this.comboBox1);
            this.Name = "FHIRSearch";
            this.Text = "FHIR Search";
            this.Load += new System.EventHandler(this.FHIRSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lbl_fhir;
        private System.Windows.Forms.Label lbl_header1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txbx_name;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}