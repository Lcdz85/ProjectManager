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
    public class TakePartService : IRepo_TakePart<TakePart>
    {
        public readonly IRepo_TakePart<DAL.Entities.TakePart> _dalService;

        public TakePartService(IRepo_TakePart<DAL.Entities.TakePart> dalService)
        {
            _dalService = dalService;
        }

        public Guid Create(TakePart takePart)
        {
            return _dalService.Create(takePart.ToDAL());
        }

        public void SetEnd(Guid employeeId, Guid projectId, DateTime endDate)
        {
            _dalService.SetEnd(employeeId, projectId, endDate);
        }
    }
}
