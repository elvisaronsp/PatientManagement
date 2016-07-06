using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Company.ClinicalDAL;
using Company.ClinicalBLL;
using Company.Globals;
using System.Data.Entity;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1 : IDisposable
    {
        private ClinicalDAL dal = null;
        [TestInitialize()]
        public void MyTestInitialize()
        {
            var data = new List<Patient> {
                new Patient() {id = 1, MRN = "4131", LastName = "Test", FirstName = "James",AddressLine1 = "4 Main Street",Active = true},
                new Patient() {id = 2, MRN = "4132", LastName = "Test", FirstName = "James1",AddressLine1 = "5 Main Street",Active = true },
                new Patient() {id = 3, MRN = "4133", LastName = "Martin", FirstName = "James1",AddressLine1 = "5 Main Street",Active = true },
                new Patient() {id = 4, MRN = "4134", LastName = "Martin", FirstName = "Donna",AddressLine1 = "5 Main Street",Active = false },
                new Patient() {id = 5, MRN = "4100", LastName = "Martin", FirstName = "Steve",AddressLine1 = "5 Main Street",Active = false,
                               External_id = "1000023",External_source =  "https://fhir.test.com"
                              },
                new Patient() {id = 5, MRN = "4101", LastName = "Martin", FirstName = "Steve",AddressLine1 = "5 Main Street",Active = true,
                               External_id = "1000024",External_source =  "https://fhir.test.com"
                              }
            };

            var useractions_data = new List<UserAction>();

            var dbSetMock = new Mock<IDbSet<Patient>>();
            dbSetMock.As<IQueryable<Patient>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Patient>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Patient>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Patient>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());
            dbSetMock.Setup(m => m.Add(It.IsAny<Patient>())).Callback<Patient>(p => data.Add(p));

            var dbSetMock_ua = new Mock<IDbSet<UserAction>>();
            dbSetMock_ua.As<IQueryable<UserAction>>().Setup(m => m.Provider).Returns(useractions_data.AsQueryable().Provider);
            dbSetMock_ua.As<IQueryable<UserAction>>().Setup(m => m.Expression).Returns(useractions_data.AsQueryable().Expression);
            dbSetMock_ua.As<IQueryable<UserAction>>().Setup(m => m.ElementType).Returns(useractions_data.AsQueryable().ElementType);
            dbSetMock_ua.As<IQueryable<UserAction>>().Setup(m => m.GetEnumerator()).Returns(useractions_data.AsQueryable().GetEnumerator());
            dbSetMock_ua.Setup(m => m.Add(It.IsAny<UserAction>())).Callback<UserAction>(u => useractions_data.Add(u));

            var customMock = new Mock<ClinicalContext>();
            customMock.Setup(p => p.Patients).Returns(dbSetMock.Object);
            customMock.Setup(u => u.UserActions).Returns(dbSetMock_ua.Object);

            // this is for the text methods that test the DAL directly.
            this.dal = new ClinicalDAL(customMock.Object);

            // make the clincal context global
            Company.Globals.GlobalVariables.Instance.ClinicalContext = customMock.Object;
            Company.Globals.GlobalVariables.Instance.ClinicalUser = "test";
        }

        //  Test the Business Logic Layer
        [TestMethod]
        public void BLL_AllPatients()
        {
            var pats = ClinicalBLL.GetAllPatients();
            Assert.AreEqual(pats.Count, 4);
        }

        [TestMethod]
        public void BLL_GetPatient_ID()
        {
            // should be null because not active.
            var pat = ClinicalBLL.GetPatient_ID(2);
            var uac_l = ClinicalBLL.GetAllUserActions();
            Assert.IsNotNull(pat);
            Assert.AreEqual(ClinicalBLL.UserActionCode.Patient_Viewed.ToString(), uac_l.Last().Action_id);
            Assert.AreEqual(ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.Patient_Viewed], uac_l.Last().Action_desc);
        }

        [TestMethod]
        public void BLL_GetPatient_MRN()
        {
            // should be null because not active.
            var pat = ClinicalBLL.GetPatient_MRN("43134");
            Assert.IsNull(pat);

            var pat1 = ClinicalBLL.GetPatient_MRN("4133");
            Assert.IsNotNull(pat1);
        }

        [TestMethod]
        public void BLL_GetPatients_LN_FN()
        {
            var result = ClinicalBLL.GetPatients_LN_FN("Test", "James");
            Assert.AreEqual(result.Count, 2);

            var result1 = ClinicalBLL.GetPatients_LN_FN("Test", "");
            Assert.AreEqual(result1.Count, 2);
        }

        [TestMethod]
        public void BLL_AddPatient()
        {
            Patient p1 = new Patient() { MRN = "4313", LastName = "Test", FirstName = "James1" };
            var patient_id = ClinicalBLL.AddPatient(p1);
            var uac_l = ClinicalBLL.GetAllUserActions();

            Assert.AreEqual(patient_id, uac_l.Last().Patient_id);
            Assert.AreEqual(ClinicalBLL.UserActionCode.Patient_Added.ToString(), uac_l.Last().Action_id);
            Assert.AreEqual(ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.Patient_Added], uac_l.Last().Action_desc);
        }

        [TestMethod]
        public void BLL_UpdatePatient()
        {
            var p1 = ClinicalBLL.GetPatient_ID(2);

            p1.MiddleName = "Francis";
            p1.City = "Boston";
            p1.State = "NC";

            ClinicalBLL.UpdatePatient(p1);
            var uac_l = ClinicalBLL.GetAllUserActions();

            Assert.AreEqual(p1.id, uac_l.Last().Patient_id);
            Assert.AreEqual(ClinicalBLL.UserActionCode.Patient_Updated.ToString(), uac_l.Last().Action_id);
            Assert.AreEqual(ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.Patient_Updated], uac_l.Last().Action_desc);

            var p2 = ClinicalBLL.GetPatient_ID(2);
            Assert.AreEqual(p1.MiddleName, p2.MiddleName);
            Assert.AreEqual(p1.City, p2.City);
            Assert.AreEqual(p1.State, p2.State);
        }

        [TestMethod]
        public void BLL_DeletePatient()
        {
            var p1 = ClinicalBLL.GetPatient_ID(2);
            ClinicalBLL.DeletePatient(2);
            var uac_l = ClinicalBLL.GetAllUserActions();

            Assert.AreEqual(p1.id, uac_l.Last().Patient_id);
            Assert.AreEqual(ClinicalBLL.UserActionCode.Patient_Deleted.ToString(), uac_l.Last().Action_id);
            Assert.AreEqual(ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.Patient_Deleted], uac_l.Last().Action_desc);

            var p2 = ClinicalBLL.GetPatient_ID(2);
            Assert.IsNull(p2);
        }

        [TestMethod]
        public void BLL_Find_FHIR_patients()
        {
            // as of july 04 2016, this returned some patients
            var expats = ClinicalBLL.find_fhir_patients("https://fhir-open-api-dstu2.smarthealthit.org", "r");
            Assert.IsTrue(expats.Count > 0);
        }

        [TestMethod]
        public void BLL_add_fhir_patient()
        {
            FHIR_Patient fp1 = new FHIR_Patient
            {
                External_id = "100008",
                External_source = "https://fhir.test.com",
                LastName = "Fhirtest",
                FirstName = "April",
                MRN = "5678"
            };
            var patient_id = ClinicalBLL.add_fhir_patient(fp1);
            var uac_l = ClinicalBLL.GetAllUserActions();
            Assert.AreEqual(patient_id, uac_l.Last().Patient_id);
            Assert.AreEqual(ClinicalBLL.UserActionCode.External_Patient_Added.ToString(), uac_l.Last().Action_id);
            Assert.AreEqual(ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.External_Patient_Added], uac_l.Last().Action_desc);
            Assert.AreEqual("test", uac_l.Last().User);

            var pat = ClinicalBLL.GetPatient_MRN("5678");
            Assert.AreEqual(fp1.LastName, pat.LastName);
            Assert.AreEqual(fp1.External_id, pat.External_id);
            Assert.AreEqual(fp1.External_source, pat.External_source);
        }

        [TestMethod]
        // this test will test the updating/overwriting of patient data with the data from the external system
        // if the patient is already deleted, it will undelete it.
        public void BLL_update_fhir_patient()
        {
            // should match patient in load above.
            FHIR_Patient fp1 = new FHIR_Patient
            {
                External_id = "1000023",
                External_source = "https://fhir.test.com",
                Address = "1818 Thomas Lane",
                LastName = "Fhirtest",
                FirstName = "April",
                MRN = "5678"
            };
            var pat = ClinicalBLL.GetPatient_External_Id_Source(fp1);
            Assert.AreEqual("4100", pat.MRN);
            Assert.AreEqual("5 Main Street", pat.AddressLine1);

            ClinicalBLL.update_fhir_patient(fp1);
            var uac_l = ClinicalBLL.GetAllUserActions();
            Assert.AreEqual(pat.id, uac_l.Last().Patient_id);
            Assert.AreEqual(ClinicalBLL.UserActionCode.External_Patient_Updated.ToString(), uac_l.Last().Action_id);
            Assert.AreEqual(ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.External_Patient_Updated], uac_l.Last().Action_desc);
            var pat1 = ClinicalBLL.GetPatient_MRN("4100");
            Assert.AreEqual(fp1.Address, pat1.AddressLine1);
        }

        // Test the Data Access Layer using the DAL object
        [TestMethod]
        public void DAL_GetAllPatients()
        {
            // returns all active patients
            var patients = dal.GetAllPatients();
            Assert.AreEqual(patients.Count, 4);
        }

        [TestMethod]
        public void DAL_GetPatient_MRN()
        {
            var result = dal.GetPatient_MRN("4313");
            Assert.IsNull(result);

            Patient p1 = new Patient() { MRN = "4313", LastName = "Test", FirstName = "James1" };
            dal.AddPatient(p1);

            var result1 = dal.GetPatient_MRN("4313");
            Assert.AreEqual(result1.MRN, "4313");
        }

        [TestMethod]
        public void DAL_GetPatient_LN_FN()
        {
            var result = dal.GetPatients_LN_FN("Test", "James");
            Assert.AreEqual(result.Count, 2);

            var result1 = dal.GetPatients_LN_FN("Test", "");
            Assert.AreEqual(result1.Count, 2);
        }

        [TestMethod]
        public void DAL_GetPatient_ID()
        {
            var result = dal.GetPatient_ID(2);
            Assert.AreEqual(result.MRN, "4132");
        }

        [TestMethod]
        public void DAL_GetPatient_External_Id_Source()
        {
            var pat = dal.GetPatient_External_Id_Source("1000024", "https://fhir.test.com");
            Assert.AreEqual(pat.MRN, "4101");
        }

        [TestMethod]
        public void DAL_Update_Patient()
        {
            Patient patient = dal.GetPatient_ID(2);
            Assert.AreEqual(patient.MRN, "4132");

            patient.AddressLine1 = "33 Main Street";
            dal.UpdatePatient(patient);

            Patient patient1 = dal.GetPatient_ID(2);
            Assert.AreEqual(patient1.AddressLine1, "33 Main Street");
        }

        [TestMethod]
        public void DAL_Delete_Patient()
        {

            Patient patient = dal.GetPatient_ID(2);
            Assert.AreEqual(patient.MRN, "4132");

            dal.DeletePatient(2);
            Patient patient1 = dal.GetPatient_ID(2);
            Assert.IsNull(patient1);
        }

        [TestMethod]
        public void DAL_AddUserAction()
        {
            var allactions = dal.GetAllUserActions();
            var ct = allactions.Count;

            UserAction ua = new UserAction
            {
                Action_id = ClinicalBLL.UserActionCode.External_Patient_Updated.ToString(),
                Action_desc = ClinicalBLL.UserActionDesc[ClinicalBLL.UserActionCode.External_Patient_Updated],
                Action_date = DateTime.Now,
                Patient_id = 10,
                External_id = "1000",
                External_source = "Ext source"
            };
            dal.AddUserAction(ua);
            var allactions1 = dal.GetAllUserActions();

            Assert.AreEqual(ct + 1, allactions1.Count);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dal != null)
                {
                    dal.Dispose();
                    dal = null;
                }
            }
        }
    }
}
