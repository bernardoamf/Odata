using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServices.Domain
{
    class Orders
    {
        public int ID { get; set; }
        public int customerID { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public int salesPersonID { get; set; }
    
    }
}
