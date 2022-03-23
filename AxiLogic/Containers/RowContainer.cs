using System;
using System.Collections.Generic;
using AxiLogic.Classes;

namespace AxiLogic.Containers
{
    public class RowContainer
    {
        public readonly List<Row> Rows;

        public RowContainer()
        {
            Rows = new List<Row>();
        }


        public void AddRow(Row row)
        {
            if (Rows.Contains(row))
            {
                throw new ArgumentException("Can not add duplicate row");
            }
            Rows.Add(row);
        }

        public void RemoveRow(Row row)
        {
           if (!Rows.Contains(row))
           {
                throw new ArgumentException("Row does not exist");
           }
           Rows.Remove(row);
        }
    }
}
