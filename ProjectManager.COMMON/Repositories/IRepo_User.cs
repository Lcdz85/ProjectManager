using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.COMMON.Repositories
{
    public interface IRepo_User<TUser>
    {
        public Guid CheckPassword(string email, string password);
        public TUser Get_ByEmployeeId(Guid employeeId);
    }
}
