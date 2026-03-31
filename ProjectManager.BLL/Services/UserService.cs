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
    public class UserService : IRepo_User<User>
    {
        public readonly IRepo_User<DAL.Entities.User> _dalService;

        public UserService(IRepo_User<DAL.Entities.User> dalService)
        {
            _dalService = dalService;
        }

        public Guid CheckPassword(string email, string password)
        {
            return _dalService.CheckPassword(email, password);
        }

        public User Get_ByEmployeeId(Guid employeeId)
        {
            return _dalService.Get_ByEmployeeId(employeeId).ToBLL();
        }
    }
}
