using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;

namespace Services
{
    public interface IHRAccountServices
    {
        public Hraccount GetHraccountByEmail(String email);
        public List<Hraccount> GetHraccounts();
    }
}
