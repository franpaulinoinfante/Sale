using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserEntity
    {
        public int IdUser { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Document { get; set; }
        public string UserAddress { get; set; }
        public string Note { get; set; }
    }
}
