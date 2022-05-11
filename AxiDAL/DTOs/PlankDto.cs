using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct PlankDto
    {
        public List<PalletDto> palletDtos;
        public int Id;
        public int RackId;
        public int Location;
    }
}