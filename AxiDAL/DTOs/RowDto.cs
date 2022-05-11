using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public struct RowDto
    {
        public List<RackDto> RackDtos;
        public int Id;
        public string Name { get; set; }
    }
}