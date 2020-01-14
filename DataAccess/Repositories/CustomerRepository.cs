using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class CustomerRepository : MasterRepository, ICustomerRepository
    {
        private string _selectAll;
        private string _insert;
        private string _update;
        private string _delete;

        public CustomerRepository()
        {
            _selectAll = "spCustomerGetAll";
            _insert = "spCustomerInsert";
            _update = "spCustomerEdit";
            _delete = "spCustomerDelete";
        }

        public IEnumerable<CustomerEntity> GeAtll()
        {
            var tableResult = ExecuteReader(_selectAll);
            var lstCustomer = new List<CustomerEntity>();
            foreach (DataRow item in tableResult.Rows)
            {
                lstCustomer.Add(new CustomerEntity
                {
                    IdCustomer = (int)item["IdCustomer"],
                    Lastname = (string)item["Lastname"],
                    Firstname = (string)item["Firstname"],
                    Birthday = (DateTime)item["Birthday"],
                    Gender = (string)item["Gender"],
                    Document = (string)item["Document"],
                    Phone = (string)item["Phone"],
                    CustomerAddress = (string)item["CustomerAddress"],
                    Note = (string)item["Note"]
                });
            }
            return lstCustomer;
        }
        public void Add(CustomerEntity entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Lastname", entity.Lastname));
            parameters.Add(new SqlParameter("@Firstname", entity.Firstname));
            parameters.Add(new SqlParameter("@Birthday", entity.Birthday));
            parameters.Add(new SqlParameter("@Gender", entity.Gender));
            parameters.Add(new SqlParameter("@Document", entity.Document));
            parameters.Add(new SqlParameter("@Phone", entity.Phone));
            parameters.Add(new SqlParameter("@CustomerAddress", entity.CustomerAddress));
            parameters.Add(new SqlParameter("@Note", entity.Note));
            ExecuteNonQuery(_insert);
        }

        public void Edit(CustomerEntity entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdCustomer", entity.IdCustomer));
            parameters.Add(new SqlParameter("@Lastname", entity.Lastname));
            parameters.Add(new SqlParameter("@Firstname", entity.Firstname));
            parameters.Add(new SqlParameter("@Birthday", entity.Birthday));
            parameters.Add(new SqlParameter("@Gender", entity.Gender));
            parameters.Add(new SqlParameter("@Document", entity.Document));
            parameters.Add(new SqlParameter("@Phone", entity.Phone));
            parameters.Add(new SqlParameter("@CustomerAddress", entity.CustomerAddress));
            parameters.Add(new SqlParameter("@Note", entity.Note));
            ExecuteNonQuery(_update);
        }

        public void Remove(int Id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdCustomer", Id));
            ExecuteNonQuery(_delete);
        }
    }
}
