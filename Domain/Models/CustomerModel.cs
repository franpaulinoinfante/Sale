using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace Domain.Models
{
    public class CustomerModel
    {
        public int IdCustomer { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string CustomerAddress { get; set; }
        public string Note { get; set; }

        ICustomerRepository customerRepository;
        public CustomerModel()
        {
            customerRepository = new CustomerRepository();
        }


        // publoc

            public List<CustomerModel> GetCustomers()
        {
            return GetCustomerModels();
        }

        // privete
        private List<CustomerModel> GetCustomerModels()
        {
            var customerDataModel = customerRepository.GeAtll();
            List<CustomerModel> customerModels = new List<CustomerModel>();
            foreach (CustomerEntity entity in customerDataModel)
            {
                customerModels.Add(new CustomerModel
                {
                    IdCustomer = entity.IdCustomer,
                    Lastname = entity.Lastname,
                    Firstname = entity.Firstname,
                    Birthday = entity.Birthday,
                    Gender = entity.Gender,
                    Document = entity.Document,
                    Phone = entity.Phone,
                    CustomerAddress = entity.CustomerAddress,
                    Note = entity.Note,
                });
            }
            return customerModels;
        }
    }
}
