using System.Collections.Generic;
using System.Data;
using AxiDAL;

namespace AxiInterfaces
{
    public interface ITestDAL
    {

        public IList<TestDTO> GetAllTestData();
        
    }

}