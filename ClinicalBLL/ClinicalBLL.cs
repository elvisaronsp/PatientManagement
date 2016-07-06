using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Company.ClinicalDAL;
using Company.Globals;


namespace Company.ClinicalBLL
{
    public partial class ClinicalBLL
    {
        static private readonly ClinicalContext context = GlobalVariables.Instance.ClinicalContext;
        static private readonly string ClinicalUser = GlobalVariables.Instance.ClinicalUser;
        public static void CreateDB()
        {
            using (var ctx = new ClinicalDAL.ClinicalDAL(context))
            {
                ctx.CreateClincalDB();
            }
        }

        // valid if MRN, lastname, firstnme, dateofbirth and gender are not null.
        public static bool isPatientValid(string MRN, string Lastname, string Firstname, string Sex, DateTime Dateofbirth)
        {
            if (String.IsNullOrEmpty(MRN) ||
                String.IsNullOrEmpty(Lastname) ||
                String.IsNullOrEmpty(Firstname) ||
                String.IsNullOrEmpty(Sex) ||
                Dateofbirth == null)
            {
                return false;
            }
            return true;
        }

        // if the patient doesn't have external info, it was added manually.
        public static int AddPatient(Company.ClinicalDAL.Patient pat)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                int patient_id = dal.AddPatient(pat);
                UserActionCode uac = UserActionCode.Patient_Added;
                if (!String.IsNullOrEmpty(pat.External_id))
                {
                    uac = UserActionCode.External_Patient_Added;
                }
                UserAction ua = new UserAction
                {
                    User = ClinicalUser,
                    Action_id = uac.ToString(),
                    Action_desc = UserActionDesc[uac],
                    Action_date = DateTime.Now,
                    Patient_id = patient_id,
                    External_id = pat.External_id,
                    External_source = pat.External_source
                };
                dal.AddUserAction(ua);
                return patient_id;
            }
        }

        public static void UpdatePatient(Company.ClinicalDAL.Patient pat)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                dal.UpdatePatient(pat);
                UserAction ua = new UserAction
                {
                    User = ClinicalUser,
                    Action_id = UserActionCode.Patient_Updated.ToString(),
                    Action_desc = UserActionDesc[UserActionCode.Patient_Updated],
                    Action_date = DateTime.Now,
                    Patient_id = pat.id,
                    External_id = pat.External_id,
                    External_source = pat.External_source
                };
                dal.AddUserAction(ua);
            }
        }

        public static void DeletePatient(int patient_id)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                var pat = dal.GetPatient_ID(patient_id);
                if (pat != null)
                {
                    dal.DeletePatient(patient_id);
                    UserAction ua = new UserAction
                    {
                        User = ClinicalUser,
                        Action_id = UserActionCode.Patient_Deleted.ToString(),
                        Action_desc = UserActionDesc[UserActionCode.Patient_Deleted],
                        Action_date = DateTime.Now,
                        Patient_id = patient_id,
                        External_id = pat.External_id,
                        External_source = pat.External_source
                    };
                    dal.AddUserAction(ua);
                };
            }
        }

        public static List<ClinicalDAL.Patient> GetAllPatients()
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                return dal.GetAllPatients();
            }
        }

        public static ClinicalDAL.Patient GetPatient_ID(int patient_id)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                var pat = dal.GetPatient_ID(patient_id);
                if (pat != null)
                {
                    UserAction ua = new UserAction
                    {
                        User = ClinicalUser,
                        Action_id = UserActionCode.Patient_Viewed.ToString(),
                        Action_desc = UserActionDesc[UserActionCode.Patient_Viewed],
                        Action_date = DateTime.Now,
                        Patient_id = patient_id,
                        External_id = pat.External_id,
                        External_source = pat.External_source
                    };
                    dal.AddUserAction(ua);
                }
                return pat;
            }
        }

        // this is just to validate if an MRN exist. If used to query patient will need to be logged.
        public static ClinicalDAL.Patient GetPatient_MRN(string mrn)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                return dal.GetPatient_MRN(mrn);
            }
        }

        // this is just to validate if an MRN exist. If used to query patient will need to be logged.
        public static ClinicalDAL.Patient GetPatient_External_Id_Source(FHIR_Patient fp)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                return dal.GetPatient_External_Id_Source(fp.External_id, fp.External_source);
            }
        }

        public static List<ClinicalDAL.Patient> GetPatients_LN_FN(string lastname, string firstname)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                return dal.GetPatients_LN_FN(lastname, firstname);
            }
        }

        public static void Add_UserAction(UserAction ua)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                dal.AddUserAction(ua);
            }
        }

        // Only take the 1st character for sex/gender
        public static int add_fhir_patient(FHIR_Patient fp)
        {
            var pat = new Company.ClinicalDAL.Patient();
            pat.MRN = fp.MRN;
            pat.LastName = fp.LastName;
            pat.FirstName = fp.FirstName;
            pat.Sex = !string.IsNullOrEmpty(fp.Gender) ? fp.Gender.Substring(0, 1) : "U";
            pat.DateOfBirth = !string.IsNullOrEmpty(fp.Birthdate) ? DateTime.Parse(fp.Birthdate) : (DateTime?)null;
            pat.AddressLine1 = fp.Address;
            pat.City = fp.City;
            pat.State = fp.State;
            pat.Zip = fp.Zip;
            pat.HomePhone = fp.Phone;
            pat.External_id = fp.External_id;
            pat.External_source = fp.External_source;
            return AddPatient(pat);
        }

        // this will overwrite the current patient information with the value from the FHIR repo
        // if the patient is deleted, the patient will be reactivated
        public static void update_fhir_patient(FHIR_Patient fp)
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                var pat = dal.GetPatient_External_Id_Source(fp.External_id, fp.External_source);
                if (pat != null)
                {

                    pat.LastName = fp.LastName;
                    pat.FirstName = fp.FirstName;
                    pat.Sex = !string.IsNullOrEmpty(fp.Gender) ? fp.Gender.Substring(0, 1) : "U";
                    pat.DateOfBirth = !string.IsNullOrEmpty(fp.Birthdate) ? DateTime.Parse(fp.Birthdate) : (DateTime?)null;
                    pat.AddressLine1 = fp.Address;
                    pat.City = fp.City;
                    pat.State = fp.State;
                    pat.Zip = fp.Zip;
                    pat.HomePhone = fp.Phone;
                    pat.Active = true;

                    dal.UpdatePatient(pat);
                    UserAction ua = new UserAction
                    {
                        User = GlobalVariables.Instance.ClinicalUser,
                        Action_id = UserActionCode.External_Patient_Updated.ToString(),
                        Action_desc = UserActionDesc[UserActionCode.External_Patient_Updated],
                        Action_date = DateTime.Now,
                        Patient_id = pat.id,
                        External_id = pat.External_id,
                        External_source = pat.External_source
                    };
                    dal.AddUserAction(ua);
                }
            }
        }

        public static List<FHIR_Patient> find_fhir_patients(string _Url, string _Name)
        {
            var endpoint = new Uri(_Url);
            var client = new FhirClient(endpoint);
            client.UseFormatParam = true;
            client.PreferredFormat = ResourceFormat.Json;

            var list_fhir = new List<FHIR_Patient>();

            var query = new string[] { "name=" + _Name };
            try
            {
                var bundle = client.Search("Patient", query);
                UserAction ua = new UserAction
                {
                    User = "user",
                    Action_id = UserActionCode.External_FHIR_Queried.ToString(),
                    Action_desc = UserActionDesc[UserActionCode.External_FHIR_Queried],
                    External_source = _Url
                };
                Console.WriteLine("Got " + bundle.Entry.Count() + " records!");
                foreach (var pt in bundle.Entry)
                {
                    Hl7.Fhir.Model.Patient p = (Hl7.Fhir.Model.Patient)pt.Resource;
                    var fc = new FHIR_Patient();
                    fc.External_id = p.Id;
                    fc.External_source = _Url;
                    fc.LastName = p.Name.First().Family.FirstOrDefault();
                    fc.FirstName = p.Name.First().Given.FirstOrDefault();
                    fc.Birthdate = p.BirthDate.ToString();
                    fc.Gender = p.Gender.ToString();
                    fc.Address = "";
                    fc.City = "";
                    fc.State = "";
                    fc.Zip = "";
                    if (p.Address.Count > 0)
                    {
                        fc.Address = p.Address.First().Line.FirstOrDefault();
                        fc.City = p.Address.First().City;
                        fc.State = p.Address.First().State;
                        fc.Zip = p.Address.First().PostalCode;
                    };
                    list_fhir.Add(fc);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return list_fhir;
        }

        public static List<UserAction> GetAllUserActions()
        {
            using (var dal = new Company.ClinicalDAL.ClinicalDAL(context))
            {
                return dal.GetAllUserActions();
            }
        }

        // Add public business level enums here
        public enum UserActionCode
        {
            Patient_Viewed = 100,
            Patient_Added = 101,
            Patient_Updated = 102,
            Patient_Deleted = 103,
            External_Patient_Added = 201,
            External_Patient_Updated = 202,
            External_FHIR_Queried = 500,
            User_Logged_On = 501
        };

        public static Dictionary<UserActionCode, string> UserActionDesc = new Dictionary<UserActionCode, string>
        {
            {UserActionCode.Patient_Viewed,"Patient Viewed"},
            {UserActionCode.Patient_Added,"Patient Added"},
            {UserActionCode.Patient_Updated,"Patient Updated"},
            {UserActionCode.Patient_Deleted,"Patient Deleted"},
            {UserActionCode.External_Patient_Added,"External Patient Added"},
            {UserActionCode.External_Patient_Updated,"External Patient Updated"},
            {UserActionCode.External_FHIR_Queried,"External_FHIR_Queried"},
            {UserActionCode.User_Logged_On,"User Logged On"}
        };
    }

    // Add public business level classes here.
    public class FHIR_Patient
    {
        public string External_id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string External_source { get; set; }
        public string MRN { get; set; }

    }
}
