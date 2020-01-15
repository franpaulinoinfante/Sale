using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace Domain.Models
{
    public class SupplierModel
    {
        public int IdSupplier { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string TradeName { get; set; }
        public string Document { get; set; }
        public string SupplierAddress { get; set; }
        public string Note { get; set; }

        private ISupplierRepository supplierRepository;

        public SupplierModel()
        {
            supplierRepository = new SupplierRepository();
        }



        //  Public methods
        public IEnumerable<SupplierModel> GetSuppliers()
        {
            return GetSupplierModels();
        }

        // Private methods
        private IEnumerable<SupplierModel> GetSupplierModels()
        {
            var genericList = new List<SupplierModel>();
            var tablaResult = supplierRepository.GeAtll();
            foreach (SupplierEntity entity in tablaResult)
            {
                genericList.Add(new SupplierModel
                {
                    IdSupplier = entity.IdSupplier,
                    Lastname = entity.Lastname,
                    Firstname = entity.Firstname,
                    TradeName = entity.TradeName,
                    Document = entity.Document,
                    SupplierAddress = entity.SupplierAddress,
                    Note = entity.Note
                });
            }
            return genericList;
        }
    }
}
