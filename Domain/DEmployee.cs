using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace Domain
{
    public  class DEmployee
    {
        private DAEmployee objDAEmpleado = new DAEmployee();

        public DataTable GetProducto()
        {
            DataTable tabla = new DataTable();
            tabla = objDAEmpleado.GetData();
            return tabla;
        }

        public int InsertData()
        {
            return objDAEmpleado.InsertReacord("Gonzales", "Yunior", "08-30-1979", "M", "047-0201999-2", "Santiago", "RRHH");
        }

        public int EdiRecord()
        {
            return objDAEmpleado.EditReacord(1, "Infante", "Javier", "08-30-1999", "M", "047-0201999-8", "Santiago", "hola");
        }

        public int DeleteRecord()
        {
           return objDAEmpleado.DeleteReacord(3);
        }
    }
}
