using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reactive.Linq;
using Company.ClinicalDAL;
using Company.Globals;
using Company.ClinicalBLL;

namespace Company.PatientManagementUI
{
    public partial class PatientSearch : Form
    {
      
        public PatientSearch()
        {
            InitializeComponent();
        }

        public void load_patients(Patient patient_search)
        {
            // don't want to search all search items are empty
            if (String.IsNullOrEmpty(patient_search.LastName) && String.IsNullOrEmpty(patient_search.FirstName))
            {
                dataGridView1.DataSource = null;
                return;
            }

            dataGridView1.DataSource = ClinicalBLL.ClinicalBLL.GetPatients_LN_FN(patient_search.LastName, patient_search.FirstName);
            this.dataGridView1.Columns["Active"].Visible = false;          
        }

        public void load_patients()
        {
            dataGridView1.DataSource = Company.ClinicalBLL.ClinicalBLL.GetAllPatients();
            this.dataGridView1.Columns["Active"].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var patient_search = new Patient();
            patient_search.FirstName = "";
            patient_search.LastName = "" ;

            UserAction ua = new UserAction
            {
                User = GlobalVariables.Instance.ClinicalUser,

                Action_id = Company.ClinicalBLL.ClinicalBLL.UserActionCode.User_Logged_On.ToString(),
                Action_desc = Company.ClinicalBLL.ClinicalBLL.UserActionDesc[Company.ClinicalBLL.ClinicalBLL.UserActionCode.User_Logged_On],
                Action_date = DateTime.Now
            };
            Company.ClinicalBLL.ClinicalBLL.Add_UserAction(ua);

            var lname_input = Observable.FromEventPattern(txbx_lastname, "TextChanged")
                         .Throttle(TimeSpan.FromMilliseconds(300))
                         .Select(x => ((TextBox)x.Sender).Text)
                         .DistinctUntilChanged();

            var fname_input = Observable.FromEventPattern(txbx_firstname, "TextChanged")
             .Throttle(TimeSpan.FromMilliseconds(300))
             .Select(x => ((TextBox)x.Sender).Text)
             .DistinctUntilChanged();

            lname_input.ObserveOn(dataGridView1).Subscribe(txt =>
            {
                patient_search.LastName = txt;
                load_patients(patient_search);
            });
            fname_input.ObserveOn(dataGridView1).Subscribe(txt =>
            {
                patient_search.LastName = txt;
                load_patients(patient_search);
            });
            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToOrderColumns = true;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                if (hti.RowIndex > -1)
                {
                    dataGridView1.Rows[hti.RowIndex].Selected = true;

                    //dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    ContextMenu m = new ContextMenu();
                    MenuItem m1 = new MenuItem("Edit");
                    MenuItem m2 = new MenuItem("Delete");
                    int patient_id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                    m.MenuItems.Add(m1);
                    m.MenuItems.Add(m2);
                    m.Show(dataGridView1, new Point(e.X, e.Y));

                    // Delegates for context menu.
                    m1.Click += (s, eventargs) =>
                    {
                        showPatientEditAdd(patient_id);
                    };

                    m2.Click += (s, eventargs) =>
                    {

                        string patient_name = dataGridView1.SelectedRows[0].Cells["MRN"].Value.ToString() + " " +
                        dataGridView1.SelectedRows[0].Cells["FirstName"].Value.ToString() + " " +
                        dataGridView1.SelectedRows[0].Cells["LastName"].Value.ToString();
                        // Confirm if the user really wants to delete the product
                        DialogResult result = MessageBox.Show("Do you really want to delete " + patient_name + "?", "Confirm patient deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            Company.ClinicalBLL.ClinicalBLL.DeletePatient(patient_id);
                            dataGridView1.DataSource = null;
                        }
                    };
                }
            }
        }

        private void showPatientEditAdd(int _patient_id)
        {
            AddEditPatientForm f2 = new AddEditPatientForm();
            f2.setPatient(_patient_id);
            f2.ShowDialog(this);
            if (f2.DialogResult == DialogResult.OK)
            {
                var patient = f2.getPatient();
                if (patient.id == 0)
                {
                    Company.ClinicalBLL.ClinicalBLL.AddPatient(patient);
                    load_patients(patient);
                }
                else
                {
                    Company.ClinicalBLL.ClinicalBLL.UpdatePatient(patient);
                    load_patients(patient);
                }
            }
        }

        private void txbx_external_Click(object sender, EventArgs e)
        {
            var f = new FHIRSearch();
            f.ShowDialog();
        }

        private void btn_load_all_patients_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Company.ClinicalBLL.ClinicalBLL.GetAllPatients();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            showPatientEditAdd(0);
        }

        private void btn_load_all_patients_Click_1(object sender, EventArgs e)
        {

        }
    }
}
