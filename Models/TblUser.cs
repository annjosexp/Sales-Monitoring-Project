using System;
using System.Collections.Generic;

namespace SalesMonitoringAPI.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
