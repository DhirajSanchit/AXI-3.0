using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct RackDto
    {
        public int Location;
        public int Id;
        public List<PlankDto> plankDtos;
    }
}