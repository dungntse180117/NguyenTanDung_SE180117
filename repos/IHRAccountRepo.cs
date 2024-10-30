using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;

namespace repos
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email);

        public List<Hraccount> GetHraccounts();
    }
}
