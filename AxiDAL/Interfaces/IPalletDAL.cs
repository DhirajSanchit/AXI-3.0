using System.Collections.Generic;
using AxiDAL.DTOs;

namespace AxiDAL.Interfaces
{
    public interface IPalletDAL
    {
        public void DeletePallet(PalletDto palletDto);
        public void UpdatePallet(PalletDto palletDto);
        public int AddPallet(PalletDto palletDto);
        public IList<PalletDto> GetAllFromPlank(PlankDto plank);
    }
}