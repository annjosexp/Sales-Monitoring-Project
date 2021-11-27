using System;
using System.Collections.Generic;

namespace SalesMonitoringAPI.Models
{
    public partial class TblVisit
    {
        public int VisitId { get; set; }
        public string CustName { get; set; }
        public string ContactPerson { get; set; }
        public int? ContactNo { get; set; }
        public string InterestProduct { get; set; }
        public string VisitSubject { get; set; }
        public string Vdescription { get; set; }
        public DateTime? VisitDateTime { get; set; }
        public bool? IsDisabled { get; set; }
        public bool? IsDeleted { get; set; }
        public int? EmpId { get; set; }

        public virtual TblEmployee Emp { get; set; }
    }
}
