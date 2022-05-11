using AxiDAL.DTOs;
using System.Collections.Generic;

namespace AxiDAL.Interfaces
{
    public interface IPlankDAL
    {
        public IList<PlankDto> GetAll();
        public int AddPlank(PlankDto plankDto);
        public void UpdatePlank(PlankDto plankDto);
        public void RemovePlank(PlankDto plankDto);
    }
}