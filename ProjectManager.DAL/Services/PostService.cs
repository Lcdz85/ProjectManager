using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectManager.COMMON.Repositories;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Mappers;

namespace ProjectManager.DAL.Services
{
    public class PostService : IRepo_Post<Post>
    {
        private readonly SqlConnection _connection;

        public PostService(SqlConnection connection)
        {
            _connection = connection;
        }

        public Guid Create(Post post)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Post_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Post.Subject), post.Subject);
                    command.Parameters.AddWithValue(nameof(Post.Content), post.Content);
                    command.Parameters.AddWithValue(nameof(Post.EmployeeId), post.EmployeeId);
                    command.Parameters.AddWithValue(nameof(Post.ProjectId), post.ProjectId);
                    _connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<Post> Get_ByProjectId(Guid projectId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                List<Post> result = new List<Post>();

                command.CommandText = "SP_Post_Get_FromProjectId_ProjectManager";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToPost());
                    }
                }
                _connection.Close();

                return result;

            }
        }

        public IEnumerable<Post> Get_ByProjectId_WorkOnIt(Guid projectId, Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                List<Post> result = new List<Post>();

                command.CommandText = "SP_Post_Get_FromProjectId_WorkOnProject";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToPost());
                    }
                }
                _connection.Close();

                return result;

            }
        }

        public void Update(Guid postId, Guid employeeId, Post newData)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Post_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(postId), postId);
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                command.Parameters.AddWithValue(nameof(Post.Content), newData.Content);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
