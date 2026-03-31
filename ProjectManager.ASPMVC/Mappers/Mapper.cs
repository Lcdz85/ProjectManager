using ProjectManager.BLL.Entities;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC.Mappers
{
    public static class Mapper
    {
        private readonly IRepo_Employee<Employee> _bllEmplService;
        #region User
        public static BLL.Entities.User ToBLL(this Models.Auth.LoginForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.User(entity.Email, entity.Password);
        }
        #endregion
        #region Employee

        #endregion
        #region Projet
        public static Models.Project.ListProject_VM ToListItem(this BLL.Entities.Project entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Project.ListProject_VM()
            {
                ProjectId = entity.ProjectId,
                Name = entity.Name,
                Description = entity.Description
            };
        }
        #endregion

        #region Post
        public static Models.Post.ListPost_VM ToListItem(this BLL.Entities.Post entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Post.ListPost_VM(){
                PostId = entity.PostId,
                Subject = entity.Subject,
                Content = entity.Content,
                EmployeeName = 
            }
        }

        #endregion
        #region Takepart

        #endregion
    }
}
