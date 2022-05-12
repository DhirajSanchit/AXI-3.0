using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IRackDAL
    {
        public IList<RackDto> GetAllFromRow(RowDto row);
        public int AddRack(RackDto rack);
        public void UpdateRack(RackDto rack);
        public void DeleteRack(RackDto rack);
    }
}