using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using candidatedao;

namespace candidate_dao
{
    public class HRAccountDAO
    {
        private CandidateManagementContext context;

        private static HRAccountDAO instance = null;

        public HRAccountDAO()
        {
            context = new CandidateManagementContext();
        }
        public static HRAccountDAO Instance {
            get
            {
                if(instance == null)
                {
                    instance = new HRAccountDAO();

                }
                return instance;
            }
                
        }
        public Hraccount GetHraccountByEmail(string email)
        {
            return context.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }

        public List<Hraccount> GetHraccount()
        {
            return context.Hraccounts.ToList();
        }
    }
}
