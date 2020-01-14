using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MasterRepository : Repository
    {
        protected List<SqlParameter> parameters;

        protected void ExecuteNonQuery(string storedProcedure)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = connection;
                    sqlCmd.CommandText = storedProcedure;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter item in parameters)
                    {
                        sqlCmd.Parameters.Add(item);
                    }
                    sqlCmd.ExecuteNonQuery();
                    parameters.Clear();
                }
            }
        }

        protected DataTable ExecuteReader(string storedProcedure)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandText = storedProcedure;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = connection;
                    var sqlReader = sqlCmd.ExecuteReader();
                    using (var tableResult = new DataTable())
                    {
                        tableResult.Load(sqlReader);
                        return tableResult;
                    }
                }
            }
        }
    }
}
