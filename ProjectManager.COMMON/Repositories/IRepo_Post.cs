using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.COMMON.Repositories
{
    public interface IRepo_Post<TPost>
    {
        public Guid Create(TPost post);
        public void Update(Guid postId, TPost newData);
        public IEnumerable<TPost> Get_ByProjectId(Guid projectId);
        public IEnumerable<TPost> Get_ByProjectId_WorkOnIt(Guid projectId, Guid employeeId);
    }
}
