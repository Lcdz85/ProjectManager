using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.COMMON.Repositories
{
    public interface IRepo_Project<TProject>
    {
        public Guid Create(TProject project);
        public void Update(Guid projectId, TProject newData);
        public TProject Get(Guid projectId);
        public IEnumerable<TProject> Get_ByEmployeeId(Guid employeeId);
        public IEnumerable<TProject> Get_ByProjectManagerId(Guid projectManagerId);
    }
}
