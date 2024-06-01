using System;
using System.Collections;
using System.Collections.Generic;

namespace Olydispay_api_backend.Models
{
    public enum Gender
    {
        MALE,
        FEMALE
    }
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
    }
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public string jobTitle { get; set; }
        public string contractStartDate { get; set; }
        public string contractEndDate { get; set; }
        public int? managerId { get; set; }
        public string? listOfPersonManaged { get; set; }
        public Department department { get; set; }
    }
}
