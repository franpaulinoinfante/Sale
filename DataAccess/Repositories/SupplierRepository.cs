using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;


namespace DataAccess.Repositories
{
    public class SupplierRepository : MasterRepository, Contracts.ISupplierRepository
    {
        private string _getAll;
        private string _insert;
        private string _edit;
        private string _remove;

        public SupplierRepository()
        {
            _getAll = "spSupplierGetAll";
            _insert = "spSupplierInsert";
            _edit = "spSupplierEdit";
            _remove = "spSupplierRemove";
        }

        public void Add(SupplierEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(SupplierEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierEntity> GeAtll()
        {
            var genericList = new List<SupplierEntity>();
            var tablaResult = ExecuteReader(_getAll);
            foreach (DataRow row in tablaResult.Rows)
            {
                genericList.Add(new SupplierEntity
                {
                    IdSupplier = (int)row["IdSupplier"],
                    Lastname = (string)row["LastName"],
                    Firstname = (string)row["Firstname"],
                    TradeName = (string)row["TradeName"],
                    Document = (string)row["Document"],
                    SupplierAddress = (string)row["SupplierAddress"],
                    Note = (string)row["Note"]
                });
            }
            return genericList;
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
