using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PropertyChanged;
using Company.ClinicalBLL;

namespace Company.PatientManagementUI
{
    public partial class FHIRSearch : Form
    {
        public FHIRSearch()
        {
            InitializeComponent();
        }

        private FHIR_Patient [] fh_array = null;
        
        FHIRViewmodel fhirvm = null;


        private void FHIRSearch_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = true;

            fhirvm = new FHIRViewmodel();
            var bindsource = new BindingSource();
            bindsource.DataSource = fhirvm;
            comboBox1.DataBindings.Add("SelectedItem", bindsource, "Url", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_name.DataBindings.Add("Text", bindsource, "Name",false, DataSourceUpdateMode.OnPropertyChanged);

            btn_search.Enabled = false;
            btn_search.Click += (s, e1) =>
            {
                try
                {
                    var fhlist = ClinicalBLL.ClinicalBLL.find_fhir_patients(fhirvm.Url, fhirvm.Name);

                    fh_array = fhlist.ToArray();
                    dataGridView1.DataSource = fhlist;
                    dataGridView1.Columns["MRN"].Visible = false;
                }
                catch (Exception exc)
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show(exc.ToString(),"Error in FHIR Exchange");
                }
            };

            fhirvm.PropertyChanged += (s1, e1) =>
            {
               //var propertyname = ((PropertyChangedEventArgs)x.EventArgs).PropertyName;
                if (String.IsNullOrEmpty(fhirvm.Url) ||
                    String.IsNullOrEmpty(fhirvm.Name))
                {
                    btn_search.Enabled = false;
                }
                else
                {
                    btn_search.Enabled = true;
                }
            };
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            bool add = true;
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                if (hti.RowIndex > -1)
                {

                    // See if patient has already been added from an external source
                    // and change the context menu to update.
                    var fhir_patient = fh_array[hti.RowIndex];
                    string strContextMenu = "Add to Database";
                    var pat = ClinicalBLL.ClinicalBLL.GetPatient_External_Id_Source(fhir_patient);
                    if (pat != null)
                    {
                        strContextMenu = "Update in Database";
                        add = false ;
                    }
                    ContextMenu m = new ContextMenu();
                    MenuItem m1 = new MenuItem(strContextMenu);

                    m.MenuItems.Add(m1);
                    m.Show(dataGridView1, new Point(e.X, e.Y));

                    // Delegates for context menu.
                    m1.Click += (s, eventargs) =>
                    {
                        var fp_sel = fh_array[hti.RowIndex];
                        if (add)
                        {
                            var fm_mrn = new MRNForm();
                            fm_mrn.ShowDialog(this);
                            
                            if (fm_mrn.DialogResult == DialogResult.OK)
                            {
                                fp_sel.MRN = fm_mrn.getMRN();
                                ClinicalBLL.ClinicalBLL.add_fhir_patient(fp_sel);
                            }
                        }
                        else
                        {
                            ClinicalBLL.ClinicalBLL.update_fhir_patient(fp_sel);
                        }
                        txbx_name.Text = "";
                        dataGridView1.DataSource = null;
                    };
                }
            }
        }
    }

    [ImplementPropertyChanged]
    public class FHIRViewmodel
    {
        public string Url { get; set; }
        public string Name { get; set; }

        #pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning disable 67
    }
}
