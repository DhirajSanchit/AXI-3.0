using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface ICategoryDAL
    {
        public IList<CategoryDto> GetAllCategories();

        public void AddCategory(CategoryDto categoryDto);

        public void RemoveCategory(int id);
        public void UpdateCategory(CategoryDto categoryDto);
    }
}