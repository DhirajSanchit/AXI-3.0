using AxiLogic.Classes;

namespace AxiLogic.Interfaces
{
    public interface IRowContainer
    {
        public void AddRow(Row row);
        public void RemoveRow(Row row);
        public Row GetRowByName(string name);
    }
}