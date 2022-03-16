using System;
using System.Collections.Generic;

namespace ProftaakAxi2._0.Data
{ 
    //Deprecated?
    public class QueryHandler
    {
        /// <summary>
        /// Creates INSERT query which inserts a new row with the given key value pairs. Key and value List must be of equal length with each pair at the same index.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="keys"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string InsertStr(Table table, List<string> keys, List<string> values)
        {
            try
            {
                if (keys.Count != values.Count)
                {
                    throw new Exception(@"key and value List length unequal");
                }

                var query = $"INSERT INTO {table.ToString()} (";
                foreach (var key in keys)
                {
                    query += $"{key}, ";
                }

                query = $"{query.Remove(query.Length - 2)}) VALUES (";
                foreach (var value in values)
                {
                    query += $"{value}, ";
                }

                query = $"{query.Remove(query.Length - 2)});";

                return query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Creates UPDATE query which updates all rows that satisfy the given WHERE condition with the given key value pairs. Key and Value List must be of equal length with each pair at the same index. Target key/value and operand are put into WHERE condition.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="keys"></param>
        /// <param name="values"></param>
        /// <param name="targetKey"></param>
        /// <param name="targetValue"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string UpdateStr(Table table, List<string> keys, List<string> values, string targetKey,
            string targetValue, Operand operand)
        {
            try
            {
                if (keys.Count != values.Count)
                {
                    throw new Exception(@"key and value List length unequal");
                }

                var query = $"UPDATE {table.ToString()} SET ";
                foreach (var key in keys)
                {
                    query += $"{key} = {values[keys.IndexOf(key)]}, ";
                }
                query = $"{query.Remove(query.Length - 2)} WHERE {targetKey}{GetOperandValue(operand)}{targetValue};";
                return query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Creates DELETE query which deletes all rows that satisfy WHERE condition. Target key/value and operand are put into WHERE condition.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="targetKey"></param>
        /// <param name="targetValue"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public string DeleteStr(Table table, string targetKey, string targetValue, Operand operand)
        {
            try
            {
                var query = $"DELETE FROM {table.ToString()} WHERE {targetKey}{GetOperandValue(operand)}{targetValue};";
                return query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Creates SELECT query which retrieves given columns for al rows. Columns can't be empty.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public string SelectStr(Table table, List<string> columns)
        {
            try
            {
                var query = "Select ";
                if (columns.Count == 0)
                {
                    throw new Exception("No columns given.");
                }

                foreach (var column in columns)
                {
                    query += $"{column}, ";
                }

                query = $"{query.Remove(query.Length - 2)} FROM {table.ToString()};";
                return query;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Creates SELECT query which retrieves given columns for al rows that satisfy WHERE condition. Columns can't be empty. Target key/value and operand are put into WHERE condition.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columns"></param>
        /// <param name="targetKey"></param>
        /// <param name="targetValue"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        public string SelectStr(Table table, List<string> columns, string targetKey, string targetValue,
            Operand operand)
        {
            try
            {
                var query = "Select ";
                foreach (var column in columns)
                {
                    query += $"{column}, ";
                }

                query =
                    $"{query.Remove(query.Length - 2)} FROM {table.ToString()} WHERE {targetKey}{GetOperandValue(operand)}{targetValue};";


                return query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Returns operand value matching the given operand.
        /// </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string GetOperandValue(Operand operand)
        {
            switch (operand)
            {
                case Operand.Equal:
                    return "=";
                case Operand.Greater:
                    return ">";
                case Operand.Less:
                    return "<";
            }
            throw new Exception("Unknown operator");
        }
    }

    public enum Table
    {
        Employee,
        Shipment,
        Article,
        Stock
        //todo add correct table names
    }
    
    public enum Operand
    {
        Equal,
        Greater,
        Less
    }
}