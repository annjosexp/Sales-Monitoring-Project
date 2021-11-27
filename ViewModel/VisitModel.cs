using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesMonitoringAPI.ViewModel
{
    public class VisitModel
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
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
