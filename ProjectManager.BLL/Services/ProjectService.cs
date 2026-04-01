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
    public class ProjectService : IRepo_Project<Project>
    {
        private readonly IRepo_Project<DAL.Entities.Project> _dalService;
        private readonly IRepo_Employee<Employee> _employeeService;



        public ProjectService(IRepo_Project<DAL.Entities.Project> dalService, IRepo_Employee<Employee> employeeService)
        {
            _dalService = dalService;
            _employeeService = employeeService;
        }

        public Guid Create(Project project)
        {
            return _dalService.Create(project.ToDAL());

        }

        public Project Get(Guid projectId)
        {
            IEnumerable<Employee> members = _employeeService.Get_ByProjectId(projectId);
            int membersCount = members.Count();
            return _dalService.Get(projectId).ToBLL(members, membersCount);
        }

        public IEnumerable<Project> Get_ByEmployeeId(Guid employeeId)
        {
            return _dalService.Get_ByEmployeeId(employeeId).Select(p => p.ToBLL());
        }

        public IEnumerable<Project> Get_ByProjectManagerId(Guid projectManagerId)
        {
            return _dalService.Get_ByProjectManagerId(projectManagerId).Select(p => p.ToBLL());

        }

        public void Update(Guid projectId, Project newData)
        {
            _dalService.Update(projectId, newData.ToDAL());
        }
    }
}
