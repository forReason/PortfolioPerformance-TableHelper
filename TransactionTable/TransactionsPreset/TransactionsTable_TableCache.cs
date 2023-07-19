using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset
{
    public partial class TransactionsTable
    {
        /// <summary>
        /// the dictionary containing all tables
        /// </summary>
        public Dictionary<int, Table> Tables { get; set; } = new Dictionary<int, Table>();
        /// <summary>
        /// returns the table containing the specifiedDdateTime
        /// </summary>
        /// <remarks>
        /// 1. if the table is cached, returns the table from cache <br/>
        /// 2. if the table is not in cache but stored in file, loads the table from file <br/>
        /// 3. if the table is neither in cache nor in file, generates a new Table
        /// </remarks>
        /// <param name="date"></param>
        /// <returns></returns>
        public Table GetTable(DateTime date)
        {
            int index = date.Year * 100 + date.Month; // eg 202307
            if (!_SplitByMonth) index = 1;

            if (Tables.TryGetValue(index,out Table? table))
            {
                return table;
            }
            else
            {
                FileInfo tableFile = GetTargetFile(date);
                if (tableFile.Exists)
                {
                    Table loadedTable = new Table();
                    loadedTable.LoadFromFile(tableFile.FullName,hasHeaders:true);
                    Tables[index] = loadedTable;
                    return loadedTable;
                }
                else
                {
                    Table newTable = new Table(target: tableFile);
                    newTable.SetColumnNames(AccountTableHeaders.ToStringArray());
                    Tables[index] = newTable;
                    return newTable;
                }
            }
        }
        /// <summary>
        /// Saves the table to a file.
        /// </summary>
        /// <param name="fileName">The path of the file to write to.</param>
        public void Save()
        {
            foreach (KeyValuePair<int,Table> entry in Tables)
            {
                if (entry.Value.ContentChanged)
                {
                    entry.Value.Save();
                }
            }
        }
    }
}
