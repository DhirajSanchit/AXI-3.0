using System;
using System.Collections.Generic;
using System.IO;
using AxiLogic.Classes;
using AxiLogic.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxiLogic.Containers
{
    public class RowContainer
    {
        public readonly List<Row> Rows;

        public RowContainer()
        {
            var json = JObject.Parse(File.ReadAllText(@"..\AxiLogic\Jsons\StockLayout.json"));
            Rows = json["Rows"].ToObject<List<Row>>();
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
