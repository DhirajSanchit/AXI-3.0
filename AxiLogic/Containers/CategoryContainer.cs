using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Classes;
using AxiLogic.Interfaces;

namespace AxiLogic.Containers
{
    public class CategoryContainer : ICategoryContainer
    {
        private List<Category> Categories;
        private IDalFactory _dalFactory;

        public CategoryContainer(DalFactory dalFactory)
        {
            Categories = new List<Category>();
            _dalFactory = dalFactory;
        }

        public IReadOnlyCollection<Category> GetCategories()
        {
            return Categories;
        }

        public IList<CategoryDto> GetAllCategories() 
        {
            return _dalFactory.GetCategoryDal().GetAllCategories();
        }
        
        //todo add exceptions *2 VVV
        public void AddCategory(CategoryDto categoryDto) 
        {
            _dalFactory.GetCategoryDal().AddCategory(categoryDto);
        }

        public void RemoveCategory(CategoryDto categoryDto)
        {
            //remove catyegory from articles
            //var articleContainer = new ArticleContainer(_dalFactory);
            //articleContainer.RemoveCategoryFromArticles(categoryDto);
            //remove category from db
            _dalFactory.GetCategoryDal().RemoveCategory(categoryDto);
        }
        
        public void UpdateCategory(CategoryDto categoryDto)
        {
            new Category(categoryDto).UpdateCategory();
        }
    }
}