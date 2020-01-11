using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DAEmployee : Repository
    {
        //SqlDataReader leer;
        //DataTable table = new DataTable();
        //SqlCommand sqlcmd = new SqlCommand();
        public DataTable GetData()
        {
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM [dbo].[User]";
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        using (var tabla = new DataTable())
                        {
                            tabla.Load(reader);
                            return tabla;
                        }
                    }
                }
            }
        }

        public int InsertReacord(string lastname, string firstname, string birthday, string sex, string document, string employeeAddress, string note)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var sqlComman = new SqlCommand())
                {
                    sqlComman.Connection = connection;
                    sqlComman.CommandText =
                        @"INSERT INTO [dbo].[User](Lastname,Firstname,BirthDay,Sex,Document,EmployeeAddress,Note) VALUES (@Lastname,@Firstname,@BirthDay,@Sex,@Document,@EmployeeAddress,@Note)";

                    sqlComman.CommandType = CommandType.Text;
                    sqlComman.Parameters.Add("@Lastname", SqlDbType.NVarChar);
                    sqlComman.Parameters.Add("@Firstname", SqlDbType.NVarChar);
                    sqlComman.Parameters.Add("@BirthDay", SqlDbType.DateTime);
                    sqlComman.Parameters.Add("@Sex", SqlDbType.Char);
                    sqlComman.Parameters.Add("@Document", SqlDbType.Char);
                    sqlComman.Parameters.Add("@EmployeeAddress", SqlDbType.NVarChar);
                    sqlComman.Parameters.Add("@Note", SqlDbType.NText);

                    sqlComman.Parameters["@Lastname"].Value = lastname;
                    sqlComman.Parameters["@Firstname"].Value = firstname;
                    sqlComman.Parameters["@BirthDay"].Value = Convert.ToDateTime(birthday);
                    sqlComman.Parameters["@Sex"].Value = sex;
                    sqlComman.Parameters["@Document"].Value = document;
                    sqlComman.Parameters["@EmployeeAddress"].Value = employeeAddress;
                    sqlComman.Parameters["@Note"].Value = note;

                    int result;
                    result = sqlComman.ExecuteNonQuery();
                    return result;
                }
            }
        }

        public int EditReacord(int id, string lastname, string firstname, string birthday, string sex, string document, string employeeAddress, string note)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var sqlComman = new SqlCommand())
                {
                    sqlComman.Connection = connection;
                    sqlComman.CommandText =
                        @"UPDATE dbo.User 
                            SET Lastname=@Lastname,
		                        Firstname=@Firstname,
		                        BirthDay=@BirthDay,
		                        Sex=@Sex,
		                        Document=@Document,
		                        EmployeeAddress=@EmployeeAddress,
		                        Note= @Note
	                        WHERE IdEmployee = @Id";

                    sqlComman.CommandType = CommandType.Text;
                    sqlComman.Parameters.Add("@Id", SqlDbType.Int);
                    sqlComman.Parameters.Add("@Lastname", SqlDbType.NVarChar);
                    sqlComman.Parameters.Add("@Firstname", SqlDbType.NVarChar);
                    sqlComman.Parameters.Add("@BirthDay", SqlDbType.DateTime);
                    sqlComman.Parameters.Add("@Sex", SqlDbType.Char);
                    sqlComman.Parameters.Add("@Document", SqlDbType.Char);
                    sqlComman.Parameters.Add("@EmployeeAddress", SqlDbType.NVarChar);
                    sqlComman.Parameters.Add("@Note", SqlDbType.NText);

                    sqlComman.Parameters["@Id"].Value = id;
                    sqlComman.Parameters["@Lastname"].Value = lastname;
                    sqlComman.Parameters["@Firstname"].Value = firstname;
                    sqlComman.Parameters["@BirthDay"].Value = Convert.ToDateTime(birthday);
                    sqlComman.Parameters["@Sex"].Value = sex;
                    sqlComman.Parameters["@Document"].Value = document;
                    sqlComman.Parameters["@EmployeeAddress"].Value = employeeAddress;
                    sqlComman.Parameters["@Note"].Value = note;

                    int result;
                    result = sqlComman.ExecuteNonQuery();
                    return result;
                }
            }
        }

        public int DeleteReacord(int id)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var sqlComman = new SqlCommand())
                {
                    sqlComman.Connection = connection;
                    sqlComman.CommandText = @"DELETE FROM dbo.User WHERE IdEmployee = @Id";
                    sqlComman.CommandType = CommandType.Text;

                    sqlComman.Parameters.Add("@Id", SqlDbType.Int);
                    sqlComman.Parameters["@Id"].Value = id;

                    int result;
                    result = sqlComman.ExecuteNonQuery();
                    return result;
                }
            }
        }
    }
}
