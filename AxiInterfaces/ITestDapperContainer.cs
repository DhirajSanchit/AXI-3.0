using System.Collections.Generic;
using AxiDAL;
using AxiLogic.Classes;

namespace AxiInterfaces
{
    
    //TODO: TO BE REVISED
    public interface ITestDapperContainer
    {
        IList<Test> dt { get; set; }
        public IList<Test> GetAll();
    }
}