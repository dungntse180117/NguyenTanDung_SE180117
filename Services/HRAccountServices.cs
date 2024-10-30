using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using repos;

namespace Services
{
    public class HRAccountServices : IHRAccountServices
    {
        private IHRAccountRepo IAccountRepo;
        public HRAccountServices() {
            IAccountRepo = new HRAccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return IAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return IAccountRepo.GetHraccounts();

        }
    }
}
