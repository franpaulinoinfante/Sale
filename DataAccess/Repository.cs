using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class Repository
    {
        private readonly string _connectionString;

        public Repository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
