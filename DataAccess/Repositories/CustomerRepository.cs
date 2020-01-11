using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Contracts;
using DataAccess.Repositories;
using System.Data;

namespace DataAccess.Repositories
{
    public class CustomerRepository :MasterRepository, ICustomerRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public CustomerRepository()
        {
            selectAll = "spGetAll";
            insert = "spInsert";
            update = "spUdate";
            delete = "spDelete";
        }

        public void Add(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerEntity> GeAtll()
        {
            var tableResult = ExecuteReader(selectAll);
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

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
