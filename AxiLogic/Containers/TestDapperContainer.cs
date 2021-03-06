using System.Collections.Generic;
using AxiDAL.DTOs;
using AxiDAL.Factories;
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

        private IDalFactory _dalFactory;
        
        public IList<PocTest> dt { get; set; }
 
        public TestDapperContainer(DalFactory dalFactory)
        {
            //_context = context;
            _dalFactory = dalFactory;
        }
        
        public IList<PocTest> GetAll()
        {
            dt = new List<PocTest>();
            var TestDtoList = _dalFactory.GetTestDal().GetAllTestData();
            foreach (var dto in TestDtoList)
            {
                dt.Add(new PocTest(dto));
            }

            return dt;
        }
    }
}


 