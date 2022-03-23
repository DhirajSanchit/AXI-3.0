using AxiInterfaces.DTOs;
using AxiLogic.Classes;

namespace AxiInterfaces.Interfaces
{
    public interface IRow
    {
        void CreateRow(RowDto rowDto);
        void RemoveRow(RowDto rowDto);
    }
}