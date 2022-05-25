using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class CategoryMock : ICategoryDAL
    {
        private IDalFactory _mockFactory;
        
        public CategoryMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
        }
        
        
        public IList<CategoryDto> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }
    }
}