using System;
using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{
    public class RowContainer
    {
        private List<Row> _rows;

        public RowContainer()
        {
            _rows = new List<Row>();
        }


        public void CreateRow(Row row)
        {
            if (_rows.Contains(row))
            {
                throw new ArgumentException("Can not add duplicate row");
            }
            _rows.Add(row);
        }

        public void RemoveRow(Row row)
        {
           if (!_rows.Contains(row))
           {
                throw new ArgumentException("Row does not exist");
            }
            _rows.Remove(row);
        }
    }
}
