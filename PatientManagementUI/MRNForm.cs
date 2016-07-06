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


namespace Company.PatientManagementUI
{
    public partial class MRNForm : Form
    {
        MRNViewModel vm = new MRNViewModel();

        public MRNForm()
        {
            InitializeComponent();
        }

        public string getMRN()
        {
            return vm.MRN;
        }

        private void MRNForm_Load(object sender, EventArgs e)
        {
            vm = new MRNViewModel();

            var bsPatient = new BindingSource();
            bsPatient.DataSource = vm;
            txbx_mrn.DataBindings.Add("Text", bsPatient, "MRN", false, DataSourceUpdateMode.OnPropertyChanged);
            txbx_mrn.DataBindings.Add("BackColor", bsPatient, "MRN_backcolor", false, DataSourceUpdateMode.OnPropertyChanged);

            Observable.FromEventPattern(vm, "PropertyChanged")
            .Throttle(TimeSpan.FromMilliseconds(300))
            .ObserveOn(SynchronizationContext.Current)
            .Subscribe(x =>
            {
                var propertyname = ((PropertyChangedEventArgs)x.EventArgs).PropertyName;
                if (propertyname == "MRN")
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
            });
        }
    }

    [ImplementPropertyChanged]
    class MRNViewModel
    {
        public string MRN { get; set; }
        public Color MRN_backcolor { get; set; }
    }
}