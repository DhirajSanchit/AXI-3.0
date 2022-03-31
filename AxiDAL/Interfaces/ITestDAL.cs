using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface ITestDAL
    {
        
        //Interface for Profo of Concept DAL
        public IList<TestDTO> GetAllTestData();
        
    }

}