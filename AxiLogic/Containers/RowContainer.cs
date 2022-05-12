using System;
using System.Collections.Generic;
using System.IO;
using AxiDAL.DAL;
using AxiDAL.Factories;
using AxiDAL.Interfaces;
using AxiLogic.Classes;
using AxiLogic.Helpers;
using AxiLogic.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxiLogic.Containers
{
    public class RowContainer : IRowContainer
    {
        public readonly List<Row> Rows;
        private DalFactory _dalFactory;

        public RowContainer(DalFactory dalFactory)
        {
            _dalFactory = dalFactory;
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
        
        public Row GetRowByName(string name)
        {
            foreach (var row in Rows)
            {
                if (row.Name == name)
                {
                    return row;
                }
            }
            return null;
        }
    }
}
