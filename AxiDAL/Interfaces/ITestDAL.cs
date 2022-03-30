using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface ITestDAL
    {

        public IList<TestDTO> GetAllTestData();
        
    }

}