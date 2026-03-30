using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Hiredate { get; set; }
        public bool IsProjectManager { get; set; }

        public Employee(Guid employeeId, string firstname, string lastname, DateTime hiredate, bool isProjectManager)
        {
            EmployeeId = employeeId;
            Firstname = firstname;
            Lastname = lastname;
            Hiredate = hiredate;
            IsProjectManager = isProjectManager;
        }

        public Employee(string firstname, string lastname, DateTime hiredate, bool isProjectManager = false)
        {
            Firstname = firstname;
            Lastname=lastname;
            Hiredate = hiredate;
            IsProjectManager = isProjectManager;
        }
    }
}
