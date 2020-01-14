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

        public string Fullname => $"{Firstname} {Lastname}";

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string Document { get; set; }

        public string Phone { get; set; }

        public string CustomerAddress { get; set; }

        public string Note { get; set; }

        ICustomerRepository _customerRepository;
        public CustomerModel()
        {
            _customerRepository = new CustomerRepository();
        }


        // public

        public List<CustomerModel> GetCustomers()
        {
            return GetCustomerModels();
        }

        public void InsertCustomer()
        {
            InsertModels();
        }

        public void EditCustomer()
        {
            EditCustomerModel();
        }

        public void DeleteCustomer()
        {
            DeleteCustomerModels();
        }


        // privete
        private List<CustomerModel> GetCustomerModels()
        {
            var customerDataModel = _customerRepository.GeAtll();
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
                    Note = entity.Note
                });
            }
            return customerModels;
        }

        private void InsertModels()
        {
            CustomerEntity entity = new CustomerEntity();
            entity.Lastname = Lastname;
            entity.Firstname = Firstname;
            entity.Birthday = Birthday;
            entity.Gender = Gender;
            entity.Document = Document;
            entity.Phone = Phone;
            entity.CustomerAddress = CustomerAddress;
            entity.Note = Note;
            _customerRepository.Add(entity);
        }

        private void EditCustomerModel()
        {
            var entity = new CustomerEntity();
            entity.IdCustomer = IdCustomer;
            entity.Firstname = Firstname;
            entity.Lastname = Lastname;
            entity.Birthday = Birthday;
            entity.Gender = Gender;
            entity.Document = Document;
            entity.Phone = Phone;
            entity.CustomerAddress = CustomerAddress;
            entity.Note = Note;
            _customerRepository.Edit(entity);
        }

        private void DeleteCustomerModels()
        {
            _customerRepository.Remove(IdCustomer);
        }
    }
}
