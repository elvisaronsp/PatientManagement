using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Company.ClinicalDAL
{
    public class Patient
    {
        public int id { get; set; }
        public string MRN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public bool Active { get; set; }
        public string External_id { get; set; }
        public string External_source { get; set; }

        public Patient() { }
    }

    public class UserAction
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Action_id { get; set; }
        public string Action_desc { get; set; }
        public DateTime Action_date { get; set; }
        public int Patient_id { get; set; }
        public string External_id { get; set; }
        public string External_source { get; set; }

        public UserAction() { }
    }

    public class ClinicalContext : DbContext
    {

        public ClinicalContext() : base("ClincalDB")
        {
        }

        public virtual IDbSet<Patient> Patients { get; set; }
        public virtual IDbSet<UserAction> UserActions { get; set; }
    }

    public partial class ClinicalDAL : IDisposable
    {
        private ClinicalContext ctx = null;

        public ClinicalDAL()
        {
            ctx = new ClinicalContext();
        }

        public ClinicalDAL(ClinicalContext _ctx)
        {
            if (_ctx == null)
            {
                ctx = new ClinicalContext();
            }
            else
            {
                ctx = _ctx;
            }
        }

        public void CreateClincalDB()
        {
            using (var ctx = new ClinicalContext())
            {
                ctx.Database.CreateIfNotExists();
            }
        }

        public Task<List<Patient>> GetAllPatientsAsync()
        {
            if (ctx != null)
            {
                var q = (from p in ctx.Patients select p);
                return q.ToListAsync();
            }
            return null;

        }

        public List<Patient> GetAllPatients()
        {
            var q = (from p in ctx.Patients
                     where p.Active == true
                     select p);
            return q.ToList();
        }


        // pass in an empty string and not nulls
        public List<Patient> GetPatients_LN_FN(string LastName, string FirstName)
        {
            var q = (from p in ctx.Patients
                     where p.LastName.StartsWith(LastName) &&
                           p.FirstName.StartsWith(FirstName) &&
                           p.Active == true
                     select p);
            return q.ToList();
        }


        public Patient GetPatient_ID(int ID)
        {

            Patient pat = (from p in ctx.Patients
                           where p.id == ID
                           && p.Active == true
                           select p).FirstOrDefault();
            return pat;

        }

        public Patient GetPatient_MRN(string MRN)
        {
            Patient pat = (from p in ctx.Patients
                           where p.MRN == MRN
                           && p.Active == true
                           select p).FirstOrDefault();
            return pat;
        }

        public Patient GetPatient_External_Id_Source(string External_Id, string External_Source)
        {
            Patient pat = (from p in ctx.Patients
                           where p.External_id == External_Id
                           && p.External_source == External_Source
                           select p).FirstOrDefault();
            return pat;
        }

        public int AddPatient(Patient p)
        {
            p.Active = true;
            ctx.Patients.Add(p);
            ctx.SaveChanges();
            return p.id;
        }

        public void UpdatePatient(Patient p)
        {
            ctx.Patients.Attach(p);
            ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void DeletePatient(int patient_id)
        {
            var pat = GetPatient_ID(patient_id);
            pat.Active = false;
            ctx.SaveChanges();
        }

        public void AddUserAction(UserAction ua)
        {
            ctx.UserActions.Add(ua);
            ctx.SaveChanges();
        }

        public List<UserAction> GetAllUserActions()
        {
            var q = (from p in ctx.UserActions
                     select p);
            return q.ToList();
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
                if (ctx != null)
                {
                    ctx.Dispose();
                    ctx = null;
                }
            }
        }

    }
}