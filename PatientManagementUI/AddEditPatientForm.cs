using System;
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
using System.Reactive.Linq;
using Company.ClinicalBLL;
using Company.ClinicalDAL;

namespace Company.PatientManagementUI
{
    public partial class AddEditPatientForm : Form
    {

        private int patient_id;
        Patient editPatient;
        PatientVM vm;
        int addMode = 0;
        public AddEditPatientForm()
        {
            InitializeComponent();
        }

        public Patient getPatient()
        {
            editPatient.MRN = vm.MRN;
            editPatient.LastName = vm.LastName;
            editPatient.FirstName = vm.FirstName;
            editPatient.MiddleName = vm.MiddleName;
            editPatient.Sex = vm.Sex;
            editPatient.DateOfBirth = vm.DateOfBirth.Date;
            editPatient.AddressLine1 = vm.AddressLine1;
            editPatient.City = vm.City;
            editPatient.State = vm.State;
            editPatient.Zip = vm.Zip;
            editPatient.HomePhone = vm.HomePhone;
            editPatient.WorkPhone = vm.WorkPhone;

            return editPatient;
        }
       

        public void setPatient(int _patient_id)
        {
            this.patient_id = _patient_id;
            if (this.patient_id == 0)
            {
                addMode = 1;
                editPatient = new Patient();
            }
            else
            {
                editPatient = Company.ClinicalBLL.ClinicalBLL.GetPatient_ID(_patient_id);

            }

            vm = new PatientVM();
            vm.MRN = editPatient.MRN;
            vm.MRN_backcolor = Color.White;
            vm.LastName = editPatient.LastName;
            vm.FirstName = editPatient.FirstName;
            vm.MiddleName = editPatient.MiddleName;
            vm.Sex = editPatient.Sex;
            vm.DateOfBirth = editPatient.DateOfBirth ?? DateTime.Now ;
            vm.AddressLine1 = editPatient.AddressLine1;
            vm.City = editPatient.City;
            vm.State = editPatient.State;
            vm.Zip = editPatient.Zip;
            vm.HomePhone = editPatient.HomePhone;
            vm.WorkPhone = editPatient.WorkPhone;

             /* this code watches for an MRN change,
             * if the MRN exists, then the MRN background in the view model is turned a warning color 
             * that the MRN is already used
             */

            Observable.FromEventPattern(vm, "PropertyChanged")
             .Throttle(TimeSpan.FromMilliseconds(300))
             .ObserveOn(SynchronizationContext.Current)
             .Subscribe(x =>
             {var propertyname= ((PropertyChangedEventArgs)x.EventArgs).PropertyName;
                 if (propertyname == "MRN" && addMode == 1)
                 {
                     var pat_mrn = Company.ClinicalBLL.ClinicalBLL.GetPatient_MRN(vm.MRN);
                     if (pat_mrn == null)
                     {
                         vm.MRN_backcolor = Color.White;
                         btn_save.Enabled = true;
                     }
                     else
                     {
                         vm.MRN_backcolor = Color.Red;
                         btn_save.Enabled = false;
                     }
                 }
                 else if (!Company.ClinicalBLL.ClinicalBLL.isPatientValid(vm.MRN,vm.LastName,vm.FirstName,vm.Sex,vm.DateOfBirth))
                 {
                     btn_save.Enabled = false;
                 }
                 else
                 {
                     btn_save.Enabled = true;
                 }
             }); 

            var bsPatient = new BindingSource();
            bsPatient.DataSource = vm;

            txbx_mrn.DataBindings.Add("Text", bsPatient, "MRN", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_mrn.DataBindings.Add("BackColor", bsPatient, "MRN_backcolor", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_lastname.DataBindings.Add("Text", bsPatient, "LastName", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_firstname.DataBindings.Add("Text", bsPatient, "Firstname", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_middlename.DataBindings.Add("Text", bsPatient, "MiddleName", false, DataSourceUpdateMode.OnPropertyChanged);
            dtp_birthdate.DataBindings.Add("Value", bsPatient, "DateofBirth", false, DataSourceUpdateMode.OnPropertyChanged);
            cb_sex.DataBindings.Add("SelectedItem", bsPatient, "Sex",false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_street.DataBindings.Add("Text", bsPatient, "AddressLine1", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_city.DataBindings.Add("Text", bsPatient, "City", false, DataSourceUpdateMode.OnPropertyChanged);
            cb_state.DataBindings.Add("SelectedItem", bsPatient, "State", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_zip.DataBindings.Add("Text", bsPatient, "Zip", true, DataSourceUpdateMode.OnPropertyChanged);
            txbx_home_phone.DataBindings.Add("Text", bsPatient, "HomePhone", true, DataSourceUpdateMode.OnPropertyChanged);
            txbx_work_phone.DataBindings.Add("Text", bsPatient, "WorkPhone", true, DataSourceUpdateMode.OnPropertyChanged);


        }
    }

    [ImplementPropertyChanged]
    class PatientVM
    {
        public string MRN { get; set; }
        public Color MRN_backcolor { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }

    }
}
