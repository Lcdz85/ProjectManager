using ProjectManager.BLL.Entities;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC.Mappers
{
    public static class Mapper
    {
        #region User
        public static BLL.Entities.User ToBLL(this Models.Auth.LoginForm entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.User(entity.Email, entity.Password);
        }
        #endregion
        #region Employee

        #endregion
        #region Project
        public static Models.Project.ListProject_VM ToListItem(this BLL.Entities.Project entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Project.ListProject_VM()
            {
                ProjectId = entity.ProjectId,
                Name = entity.Name,
                Description = entity.Description,
                MembersCount = entity.MembersCount
            };
        }
        public static Models.Project.DetailsProject_VM ToDetails(this BLL.Entities.Project entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Project.DetailsProject_VM()
            {
                ProjectId = entity.ProjectId,
                Name = entity.Name,
                Description = entity.Description,
                Creationdate = entity.Creationdate,
                Members = entity.Members.Select(m => m.Lastname)
            };
        }

        public static BLL.Entities.Project ToBLL(this Models.Project.CreateProject_Form entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.Project(
                entity.Name,
                entity.Description
            );
        }

        public static Models.Project.EditProject_Form ToEdit(this BLL.Entities.Project entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Project.EditProject_Form()
            {
                ProjectId = entity.ProjectId,
                Description = entity.Description,
            };
        }

        public static BLL.Entities.Project ToBLL(this Models.Project.EditProject_Form entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Entities.Project(
                entity.ProjectId,
                entity.Description
            );
        }


        #endregion

        #region Post
        public static Models.Post.ListPost_VM ToListItem(this BLL.Entities.Post entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Models.Post.ListPost_VM()
            {
                PostId = entity.PostId,
                Subject = entity.Subject,
                Content = entity.Content
            };
        }

        #endregion
        #region Takepart

        #endregion
    }
}
