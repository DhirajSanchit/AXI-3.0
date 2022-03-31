using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Interfaces;
using AxiLogic.Classes;
using AxiLogic.Interfaces;


namespace AxiLogic.Containers
{
    /* This class serves as a Proof Of Concept: 
     * To be used as a reference point
     */
    
    public class TestDapperContainer : ITestDapperContainer
    {
        
        
        public IList<PocTest> dt { get; set; }

        private  ITestDAL _context;

        public TestDapperContainer(ITestDAL context)
        {
            _context = context;
        }

        public IList<PocTest> GetAll()
        {
            dt = new List<PocTest>();
            IList<TestDTO> TestDtoList = _context.GetAllTestData();
            foreach (TestDTO dto in TestDtoList)
            {
                dt.Add(new PocTest(dto));
            }

            return dt;
        }
    }
}


 