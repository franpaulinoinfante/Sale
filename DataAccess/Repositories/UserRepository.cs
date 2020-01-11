using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class UserRepository : MasterRepository, IUserRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public UserRepository()
        {
            selectAll = "spSelectAll";
            insert = "spInsert";
            update = "spUdate";
            delete = "spDelete";
        }

        public void Add(UserEntity entity)
        {
            parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Lastname", entity.Lastname));
            parameters.Add(new SqlParameter("@Firstname", entity.Firstname));
            parameters.Add(new SqlParameter("@Birthday", entity.Birthday));
            parameters.Add(new SqlParameter("@Gender", entity.Gender));
            parameters.Add(new SqlParameter("@Document", entity.Document));
            parameters.Add(new SqlParameter("@UserAddress", entity.UserAddress));
            parameters.Add(new SqlParameter("@Note", entity.Note));
            ExecuteNonQuery(insert);
        }

        public void Edit(UserEntity entity)
        {
            parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@IdUser", entity.IdUser));
            parameters.Add(new SqlParameter("@Lastname", entity.Lastname));
            parameters.Add(new SqlParameter("@Firstname", entity.Firstname));
            parameters.Add(new SqlParameter("@Birthday", entity.Birthday));
            parameters.Add(new SqlParameter("@Gender", entity.Gender));
            parameters.Add(new SqlParameter("@Document", entity.Document));
            parameters.Add(new SqlParameter("@UserAddress", entity.UserAddress));
            parameters.Add(new SqlParameter("@Note", entity.Note));
            ExecuteNonQuery(update);
        }

        public IEnumerable<UserEntity> GeAtll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listUser = new List<UserEntity>();
            foreach (DataRow item in tableResult.Rows)
            {
                listUser.Add(new UserEntity
                {
                    IdUser = (int)item["IdUser"],
                    Lastname = (string)item["Lastname"],
                    Firstname = (string)item["Firstname"],
                    Birthday = (DateTime)item["Birthday"],
                    Gender = (string)item["Gender"],
                    Document = (string)item["Document"],
                    Phone = (string)item["Phone"],
                    UserAddress = (string)item["UserAddress"],
                    Note = (string)item["Note"]
                });
            }
            return listUser;
        }

        public void Remove(int Id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdUser", Id));
            ExecuteNonQuery(delete);
        }
    }
}
