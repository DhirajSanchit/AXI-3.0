using System.Collections.Generic;
using AxiDAL.DAL;
using AxiDAL.DTOs;
using AxiDAL.Factories;

namespace AxiLogic.Helpers
{
    public class CategoryHelper
    {
        private DalFactory _dalFactory;
        public IList<CategoryDto> _dataset;
        
        public CategoryHelper(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }
        
        public List<string> GetCategories()
        {
            _dataset = _dalFactory.GetCategoryDal().GetAllCategories();
            return null;
        }
        
 
    }
}