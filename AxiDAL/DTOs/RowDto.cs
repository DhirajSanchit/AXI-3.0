using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct RowDto
    {
        public List<RackDto> RackDtos;
        public string Name { get; set; }
    }
}