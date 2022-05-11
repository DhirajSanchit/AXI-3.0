using System.Collections.Generic;
using AxiDAL.DAL;
using AxiDAL.Factories; 
using AxiLogic.Interfaces;

namespace AxiLogic.Helpers
{
    public class CategoryHelper : ICategoryHelper
    {
        private DalFactory _dalFactory;
        
        public CategoryHelper(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
        }
        
        public IList<string> GetCategories()
        {
            IList<string> categories = _dalFactory.GetCategoryDal().GetAllCategories();
            return categories;
        }
    }
}