using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Interfaces
{
    
    //TODO: TO BE REVISED
    public interface ITestDapperContainer
    {
         IList<PocTest> dt { get; set; }
          public IList<PocTest> GetAll();
    }
}