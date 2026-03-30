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
    public class ProjetService : IRepo_Project<Project>
    {
        private readonly SqlConnection _connection;

        public ProjetService(SqlConnection connection)
        {
            _connection = connection;
        }

        public Guid Create(Project projet)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_Project_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Project.Name), projet.Name);
                    command.Parameters.AddWithValue(nameof(Project.Description), projet.Description);
                    command.Parameters.AddWithValue(nameof(Project.ProjectManagerId), projet.ProjectManagerId);
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
        public void Update(Guid projectId, Project newData)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_UserProfile_Update";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                command.Parameters.AddWithValue(nameof(Project.Name), newData.Name);
                command.Parameters.AddWithValue(nameof(Project.Description), newData.Description);
                command.Parameters.AddWithValue(nameof(Project.Creationdate), newData.Creationdate);
                command.Parameters.AddWithValue(nameof(Project.ProjectManagerId), newData.ProjectManagerId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public Project Get(Guid projectId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Project_Get_ById";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToProject();
                    }
                    throw new ArgumentOutOfRangeException(nameof(projectId), "Le projet n'existe pas dans la base de données.");
                }
                _connection.Close();

            }
        }

        public IEnumerable<Project> Get_ByEmployeeId(Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                List<Project> result = new List<Project>();

                command.CommandText = "SP_Project_Get_FromEmployeeId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToProject());
                    }
                }
                _connection.Close();

                return result;
            }
        }

        public IEnumerable<Project> Get_ByProjectManagerId(Guid projectManagerId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                List<Project> result = new List<Project>();

                command.CommandText = "SP_Project_Get_FromProjectManagerId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(projectManagerId), projectManagerId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToProject());
                    }
                }
                _connection.Close();

                return result;
            }
        }


    }
}
