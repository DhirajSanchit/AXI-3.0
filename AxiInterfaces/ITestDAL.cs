using System.Collections.Generic;
using System.Data;

namespace AxiInterfaces
{
    public interface ITestDAL
    {

        public IList<TestDTO> GetAllTestData();
        
    }

}