using AxiInterfaces.DTOs;


namespace AxiInterfaces.Interfaces
{
    public interface IRow
    {
        void CreateRow(RowDto rowDto);
        void RemoveRow(RowDto rowDto);
    }
}