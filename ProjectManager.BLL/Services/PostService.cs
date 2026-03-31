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
    public class PostService : IRepo_Post<Post>
    {
        public readonly IRepo_Post<DAL.Entities.Post> _dalService;

        public PostService(IRepo_Post<DAL.Entities.Post> dalService)
        {
            _dalService = dalService;
        }

        public Guid Create(Post post)
        {
            return _dalService.Create(post.ToDAL());
        }

        public IEnumerable<Post> Get_ByProjectId(Guid projectId)
        {
            return _dalService.Get_ByProjectId(projectId).Select(p => p.ToBLL());
        }

        public IEnumerable<Post> Get_ByProjectId_WorkOnIt(Guid projectId, Guid employeeId)
        {
            return _dalService.Get_ByProjectId_WorkOnIt(projectId, employeeId).Select(p => p.ToBLL());
        }

        public void Update(Guid postId, Post newData)
        {
            _dalService.Update(postId, newData.ToDAL());
        }
    }
}
