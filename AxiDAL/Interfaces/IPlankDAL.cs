using AxiDAL.DTOs;
using System.Collections.Generic;

namespace AxiDAL.Interfaces
{
    public interface IPlankDAL
    {
        public IList<PlankDto> GetAllFromRack(RackDto rack);
        public int AddPlank(PlankDto plankDto);
        public void UpdatePlank(PlankDto plankDto);
        public void DeletePlank(PlankDto plankDto);
    }
}