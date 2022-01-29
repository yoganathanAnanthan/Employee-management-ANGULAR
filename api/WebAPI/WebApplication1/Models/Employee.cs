using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int DepId { get; set; }

    }
}