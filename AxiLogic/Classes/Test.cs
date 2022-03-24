using AxiDAL;

namespace AxiLogic.Classes
{
    public class Test
    {
        public int id { get; set;}
        public string value { get; set; }

        public Test(TestDTO dto)
        {
            id = dto.id;
            value = dto.value;
        }
        

        public Test(int id, string value)
        {
            this.id = id;
            this.value = value;
        }
    }
}