using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Entities
{
    public class TakePart
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public TakePart(Guid employeeId, Guid projectId, DateTime startDate, DateTime? endDate)
        {
            EmployeeId = employeeId;
            ProjectId = projectId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
