using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface ICategoryDAL
    {
        public IList<string> GetAllCategories();
    }
}