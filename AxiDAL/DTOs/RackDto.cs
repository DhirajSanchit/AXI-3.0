using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct RackDto
    {
        public int Location;
        public int Id;
        public int RowId;
        public List<PlankDto> plankDtos;
    }
}