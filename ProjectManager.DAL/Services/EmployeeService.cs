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
    public class EmployeeService : IRepo_Employee<Employee>
    {
        private readonly SqlConnection _connection;

        public EmployeeService(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Check_IsProjectManager(Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Check_IsProjectManager";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                _connection.Open();
                return (bool)command.ExecuteScalar();
            }
            _connection.Close();
            
        }

        public Guid Check_WorkOnProject(Guid employeeId, Guid projectId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Check_WorkOnProject";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                _connection.Open();
                return (Guid)command.ExecuteScalar();
            }
            _connection.Close();
        }

        public Employee Get(Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Get_FromEmployeeId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToEmployee();
                    }
                    throw new ArgumentOutOfRangeException(nameof(employeeId), "L'employé(e) n'existe pas dans la base de données.");
                }
                _connection.Close();

            }
        }

        public IEnumerable<Employee> Get_ByProjectId(Guid projetctId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                List<Employee> result = new List<Employee>();

                command.CommandText = "SP_Employee_Get_FromProjectId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@projectId", projetctId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToEmployee());
                    }
                }
                _connection.Close();

                return result;
            }
        }

        public Employee Get_ByUserId(Guid userId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Get_FromUserId";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(userId), userId);
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return reader.ToEmployee();
                    }
                    throw new ArgumentOutOfRangeException(nameof(userId), "L'UserId ne correspond pas à un employé");
                }
                _connection.Close();

            }
        }

        public IEnumerable<Employee> Get_Free()
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                List<Employee> result = new List<Employee>();

                command.CommandText = "SP_Employee_GetFree";
                command.CommandType = CommandType.StoredProcedure;;
                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToEmployee());
                    }
                }
                _connection.Close();

                return result;
            }
        }

        public void Set_IsProjectManager(Guid employeeId)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_Employee_Set_IsProjectManager";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
