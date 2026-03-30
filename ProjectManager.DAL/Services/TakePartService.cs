using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProjectManager.COMMON.Repositories;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Services
{
    public class TakePartService : IRepo_TakePart<TakePart>
    {
        private readonly SqlConnection _connection;

        public TakePartService(SqlConnection connection)
        {
            _connection = connection;
        }

        public Guid Create(TakePart takePart)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                try
                {
                    command.CommandText = "SP_TakePart_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(TakePart.EmployeeId), takePart.EmployeeId);
                    command.Parameters.AddWithValue(nameof(TakePart.ProjectId), takePart.ProjectId);
                    command.Parameters.AddWithValue(nameof(TakePart.StartDate), takePart.StartDate);
                    command.Parameters.AddWithValue(nameof(TakePart.EndDate), (object?)takePart.EndDate ?? DBNull.Value);

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

        public void SetEnd(Guid employeeId, Guid projectId, DateTime endDate)
        {
            using (SqlCommand command = _connection.CreateCommand())
            {
                command.CommandText = "SP_TakePart_SetEnd";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(employeeId), employeeId);
                command.Parameters.AddWithValue(nameof(projectId), projectId);
                command.Parameters.AddWithValue(nameof(endDate), endDate);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }
    }
}
