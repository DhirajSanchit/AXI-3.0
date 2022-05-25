using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;

namespace AxiUnitTests.Scrubs
{
    public class CategoryMock : ICategoryDAL
    {
        private IDalFactory _mockFactory;

        private List<CategoryDto> _categoryDtos = new();

        public CategoryMock(IDalFactory mockFactory)
        {
            _mockFactory = mockFactory;
            _categoryDtos.Add(new CategoryDto()
            {
                Id = 1,
                Name = "A"
            });
            _categoryDtos.Add(new CategoryDto()
            {
                Id = 2,
                Name = "B"
            });
        }
        
        
        public IList<CategoryDto> GetAllCategories()
        {
            return _categoryDtos;
        }

        public void AddCategory(CategoryDto categoryDto)
        {
            _categoryDtos.Add(categoryDto);
        }

        public void RemoveCategory(CategoryDto categoryDto)
        {
            _categoryDtos.Remove(categoryDto);
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            foreach (var dto in _categoryDtos)
            {
                if (categoryDto.Id == dto.Id)
                {
                    _categoryDtos.Remove(dto);
                    _categoryDtos.Add(categoryDto);
                }
            }
        }
    }
}