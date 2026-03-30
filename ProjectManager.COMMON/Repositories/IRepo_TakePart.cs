using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.COMMON.Repositories
{
    public interface IRepo_TakePart<TTakePart>
    {
        public Guid Create(TTakePart takePart);
        public void SetEnd(Guid employeeId, Guid projectId, DateTime endDate);
    }
}
