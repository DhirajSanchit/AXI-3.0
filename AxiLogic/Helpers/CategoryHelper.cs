using System.Collections.Generic;
using AxiDAL.DAL;
using AxiDAL.Factories;

namespace AxiLogic.Helpers
{
    public class CategoryHelper
    {
        private DalFactory _dalFactory;
        public CategoryHelper(DalFactory dalFactory)
        {
            dalFactory = _dalFactory;
        }
        
        public List<string> GetCategories()
        {
            // return new List<string>() =
        }
    }
}