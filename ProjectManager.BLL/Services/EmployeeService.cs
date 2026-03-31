using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.BLL.Entities;
using ProjectManager.BLL.Mappers;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.BLL.Services
{
    public class EmployeeService : IRepo_Employee<Employee>
    {
        public readonly IRepo_Employee<DAL.Entities.Employee> _dalService;

        public EmployeeService(IRepo_Employee<DAL.Entities.Employee> dalService)
        {
            _dalService = dalService;
        }

        public bool Check_IsProjectManager(Guid employeeId)
        {
            return _dalService.Check_IsProjectManager(employeeId);
        }

        public Guid Check_WorkOnProject(Guid employeeId, Guid projectId)
        {
            return _dalService.Check_WorkOnProject(employeeId, projectId);
        }

        public Employee Get(Guid employeeId)
        {
            return _dalService.Get(employeeId).ToBLL();
        }

        public IEnumerable<Employee> Get_ByProjectId(Guid projetctId)
        {
            return _dalService.Get_ByProjectId(projetctId).Select(e => e.ToBLL());
        }

        public Employee Get_ByUserId(Guid userId)
        {
            return _dalService.Get_ByUserId(userId).ToBLL();
        }

        public IEnumerable<Employee> Get_Free()
        {
            return _dalService.Get_Free().Select(e => e.ToBLL());
        }

        public void Set_IsProjectManager(Guid employeeId)
        {
            _dalService.Set_IsProjectManager(employeeId);
        }
    }
}
