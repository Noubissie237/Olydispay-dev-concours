using System.ComponentModel.DataAnnotations.Schema;

namespace Olydispay_api_backend.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string name { get; set; }
    }
}
