using System;
using System.Collections.Generic;

namespace SalesMonitoringAPI.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblVisit = new HashSet<TblVisit>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string EmpAddress { get; set; }
        public int? PhoneNo { get; set; }
        public int? LoginId { get; set; }

        public virtual TblUser Login { get; set; }
        public virtual ICollection<TblVisit> TblVisit { get; set; }
    }
}
