using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Company.ClinicalBLL;
using Company.Globals;

namespace Company.PatientManagementUI
{ 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Company.ClinicalBLL.ClinicalBLL.CreateDB();
            // sign in form or use existing sign in 
            GlobalVariables.Instance.ClinicalUser = "user";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new PatientSearch());
            }
            catch (Exception e)
            {
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                                  "with the following information:\n\n";
                errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}