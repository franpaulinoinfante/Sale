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
    public class CategoryModel
    {
        public int IdCategory { get; set; }
        public string Category { get; set; }
        private ICategoryRepository categoryRepository;

        public CategoryModel()
        {
            categoryRepository = new CategoryRepository();
            IdCategory = 0;
            Category = string.Empty;
        }

        // Public methods
        public IEnumerable<CategoryModel> GetCategories()
        {
            return GetCategoryModels();
        }

        public void InsertCategory()
        {
            InsertModels();
        }

        public void EditCategory()
        {
            EditModels();
        }

        public void RemoveCategory()
        {
            RemoveModels();
        }


        // Private Methods
        private IEnumerable<CategoryModel> GetCategoryModels()
        {
            var categoryModels = categoryRepository.GeAtll();
            List<CategoryModel> genericList = new List<CategoryModel>();
            foreach (CategoryEntity item in categoryModels)
            {
                genericList.Add(new CategoryModel
                {
                    IdCategory = item.IdCategory,
                    Category = item.Category
                });
            }
            return genericList;
        }

        private void InsertModels()
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            categoryEntity.IdCategory = IdCategory;
            categoryEntity.Category = Category;
            categoryRepository.Add(categoryEntity);
        }
        private void EditModels()
        {
            CategoryEntity categoryEntity = new CategoryEntity();
            categoryEntity.IdCategory = IdCategory;
            categoryEntity.Category = Category;
            categoryRepository.Edit(categoryEntity);
        }

        private void RemoveModels()
        {
            categoryRepository.Remove(IdCategory);
        }
    }
}
