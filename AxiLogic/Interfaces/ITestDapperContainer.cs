using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Interfaces
{
    
    //Interface for Proof of Concept container
    public interface ITestDapperContainer
    {
         IList<PocTest> dt { get; set; }
          public IList<PocTest> GetAll();
    }
}