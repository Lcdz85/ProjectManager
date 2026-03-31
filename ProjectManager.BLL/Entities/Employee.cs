using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Entities
{
    public class Employee
    {
        public Guid EmployeeId { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime Hiredate { get; private set; }
        public bool IsProjectManager { get; private set; }

        public Employee(Guid employeeId, string firstname, string lastname, DateTime hiredate, bool isProjectManager)
        {
            EmployeeId = employeeId;
            Firstname = firstname;
            Lastname = lastname;
            Hiredate = hiredate;
            IsProjectManager = isProjectManager;
        }

        public Employee(string firstname, string lastname, DateTime hiredate)
        {
            Firstname = firstname;
            Lastname = lastname;
            Hiredate = hiredate;
        }
    }
}
