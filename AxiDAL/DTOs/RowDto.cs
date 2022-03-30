using System.Collections.Generic;

namespace AxiDAL.DTOs
{
    public class RowDto
    {
        public List<RackDto> RackDtos;
        public string Name { get; set; }
    }
}