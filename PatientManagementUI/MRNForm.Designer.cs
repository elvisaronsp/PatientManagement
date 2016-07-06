namespace Company.PatientManagementUI
{
    partial class MRNForm
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
            this.lbl_mrn = new System.Windows.Forms.Label();
            this.txbx_mrn = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_mrn
            // 
            this.lbl_mrn.AutoSize = true;
            this.lbl_mrn.Location = new System.Drawing.Point(101, 27);
            this.lbl_mrn.Name = "lbl_mrn";
            this.lbl_mrn.Size = new System.Drawing.Size(152, 13);
            this.lbl_mrn.TabIndex = 0;
            this.lbl_mrn.Text = "Enter MRN for External Patient";
            // 
            // txbx_mrn
            // 
            this.txbx_mrn.Location = new System.Drawing.Point(87, 55);
            this.txbx_mrn.Name = "txbx_mrn";
            this.txbx_mrn.Size = new System.Drawing.Size(188, 20);
            this.txbx_mrn.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Location = new System.Drawing.Point(87, 97);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "OK";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(199, 97);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(76, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // MRNForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 132);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txbx_mrn);
            this.Controls.Add(this.lbl_mrn);
            this.Name = "MRNForm";
            this.Text = "MRNForm";
            this.Load += new System.EventHandler(this.MRNForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mrn;
        private System.Windows.Forms.TextBox txbx_mrn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
    }
}