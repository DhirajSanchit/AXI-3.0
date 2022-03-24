using System.Collections.Generic;
using AxiDAL;
using AxiInterfaces;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{

    public class TestDapperContainer : ITestDapperContainer
    {
        public IList<Test> dt { get; set; }

        private  ITestDAL _itd;

        public TestDapperContainer(ITestDAL itd)
        {
            _itd = itd;
        }

        public IList<Test> GetAll()
        {
            dt = new List<Test>();
            IList<TestDTO> TestDtoList = _itd.GetAllTestData();
            foreach (TestDTO dto in TestDtoList)
            {
                dt.Add(new Test(dto));
            }

            return dt;
        }
    }
}


 