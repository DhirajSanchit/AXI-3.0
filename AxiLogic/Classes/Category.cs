using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Factories;

namespace AxiLogic.Classes
{
    public class Category
    {
        private List<Category> Categories;
        private DalFactory _dalFactory;

        public Category(DalFactory dalFactory)
        {
            Categories = new List<Category>();
            _dalFactory = dalFactory;
        }
        
        public string Name ;
        public int Id { get; }
        
        public CategoryDto ToDto()
        {
            return new ()
            {
                Id = Id,
                Name = Name
            };
        }

        public void UpdateCategory()
        {
            _dalFactory.GetCategoryDal().UpdateCategory(ToDto());
        }

        public Category(CategoryDto categoryDto)
        {
            Id = categoryDto.Id;
            Name = categoryDto.Name;
        }
    }
}