using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class SupplierEntity
    {
        public int IdSupplier { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string TradeName { get; set; }
        public string Document { get; set; }
        public string SupplierAddress { get; set; }
        public string Note { get; set; }
    }
}
