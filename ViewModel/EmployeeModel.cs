using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.ViewModel
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string EmpAddress { get; set; }
        public int? PhoneNo { get; set; }
        public int? LoginId { get; set; }
        public string UserType { get; set; }
    }
}
