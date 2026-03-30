using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.COMMON.Repositories
{
    public interface IRepo_Employee<TEmployee>
    {
        public TEmployee Get(Guid employeeId);
        public TEmployee Get_ByUserId(Guid userId);
        public IEnumerable<TEmployee> Get_ByProjectId(Guid projetctId);
        public IEnumerable<TEmployee> Get_Free();
        public bool Check_IsProjectManager(Guid employeeId);
        public Guid Check_WorkOnProject(Guid employeeId, Guid projectId);
        public void Set_IsProjectManager(Guid employeeId);
    }
}
