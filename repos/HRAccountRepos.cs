using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using candidate_dao;

namespace repos
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);


        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccount();
       
    }
}
