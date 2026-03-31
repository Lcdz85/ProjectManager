using System.ComponentModel.DataAnnotations;

namespace ProjectManager.ASPMVC.Models.Employee
{
    public class ListEmployee_VM
    {
        [ScaffoldColumn(false)]
        Guid EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}
