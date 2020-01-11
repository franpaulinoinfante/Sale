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
    public class UserModel
    {
        public int IdUser { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Document { get; set; }
        public string UserAddress { get; set; }
        public string Note { get; set; }

        IUserRepository userRepository;
        public UserModel()
        {
            userRepository = new UserRepository();
        }

        // public method
        public List<UserModel> GetUsers()
        {
            return GetUserModels();
        }

        public void DeleteUser()
        {
            DeleteModel();
        }


        // Private Method

        private List<UserModel> GetUserModels()
        {
            var userDataModel = userRepository.GeAtll();
            List<UserModel> lstuserModels = new List<UserModel>();
            foreach (UserEntity userEntity in userDataModel)
            {
                lstuserModels.Add(new UserModel
                {
                    IdUser = userEntity.IdUser,
                    Lastname = userEntity.Lastname,
                    Firstname = userEntity.Firstname,
                    Birthday = userEntity.Birthday,
                    Gender = userEntity.Gender,
                    Document = userEntity.Document,
                    UserAddress = userEntity.UserAddress,
                    Note = userEntity.Note,
                });

            }
            return lstuserModels;
        }

        private void DeleteModel()
        {
            userRepository.Remove(IdUser);
        }
    }
}
