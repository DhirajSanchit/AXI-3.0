using AxiDAL.DTOs;

namespace AxiLogic.Classes
{
    public class PocTest
    {
        public int id { get; set;}
        public string value { get; set; }

        public PocTest(TestDTO dto)
        {
            id = dto.id;
            value = dto.value;
        }
        

        public PocTest(int id, string value)
        {
            this.id = id;
            this.value = value;
        }
    }
}