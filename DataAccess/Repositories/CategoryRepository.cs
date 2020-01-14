using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Data.SqlClient;
using DataAccess.Contracts;
using System.Data;

namespace DataAccess.Repositories
{
    public class CategoryRepository : MasterRepository, ICategoryRepository
    {
        private string _getAll;
        private string _insert;
        private string _edit;
        private string _remove;

        public CategoryRepository()
        {
            _getAll = "spCategoryGetAll";
            _insert = "spCategoryInsert";
            _edit = "spCategoryEdit";
            _remove = "spCategoryRevome";
        }
        public void Add(CategoryEntity entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@DescriptionCat", entity.Category));
            ExecuteNonQuery(_insert);
        }

        public void Edit(CategoryEntity entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdCategory", entity.IdCategory));
            parameters.Add(new SqlParameter("@DescriptionCat", entity.Category));
            ExecuteNonQuery(_edit);
        }

        public IEnumerable<CategoryEntity> GeAtll()
        {
            var tablaResult = ExecuteReader(_getAll);
            var lstCategory = new List<CategoryEntity>();
            foreach (DataRow item in tablaResult.Rows)
            {
                lstCategory.Add(new CategoryEntity
                {
                    IdCategory = (int)item["IdCategory"],
                    Category = (string)item["DescriptionCat"]
                });
            }
            return lstCategory;
        }

        public void Remove(int Id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdCategory", Id));
            ExecuteNonQuery(_remove);
        }
    }
}
