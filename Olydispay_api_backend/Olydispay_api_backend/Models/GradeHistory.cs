using System;

namespace Olydispay_api_backend.Models
{
    public class GradeHistory
    {
        public int GradeHistoryID { get; set; }
        public string grade {  get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public Employee employee { get; set; }
    }
}
