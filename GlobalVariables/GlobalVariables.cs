using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.ClinicalDAL;


// this will be a singleton that returns a global instance.
namespace Company.Globals
{

    public sealed class GlobalVariables
    {
        private static readonly GlobalVariables instance = new GlobalVariables();
        private ClinicalContext _ctx = null;
        private string _clinicalUser = "user";
        private GlobalVariables() { }

        public static GlobalVariables Instance
        {
            get
            {
                return instance;
            }
        }

        public ClinicalContext ClinicalContext
        {
            get
            {
                return _ctx;
            }
            set
            {
                _ctx = value;
            }
        }


        public string ClinicalUser
        {
            get
            {
                return _clinicalUser;
            }
            set
            {
                _clinicalUser = value;
            }
        }

    }
}