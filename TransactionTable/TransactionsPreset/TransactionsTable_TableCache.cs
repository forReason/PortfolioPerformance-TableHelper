using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset
{
    public partial class TransactionsTable
    {
        /// <summary>
        /// the dictionary containing all tables
        /// </summary>
        public Dictionary<int, Table> Tables { get; set; } = new Dictionary<int, Table>();
        public Table? GetOldestTable()
        {
            // obtain oldest table from chache
            int minValue = int.MaxValue;
            foreach (int key in Tables.Keys)
            {
                if (key < minValue) minValue = key;
            }
            // check if newer Table exists in files
            DateTime? timeInfo = null;
            if (_TargetDirectory != null)
            {
                FileInfo[] files = _TargetDirectory.GetFiles();

                foreach (FileInfo file in files)
                {
                    string filename = Path.GetFileNameWithoutExtension(file.Name);
                    string date = filename.Split('_').Last();
                    string[] parts = filename.Split("-");
                    int year = int.Parse(parts[0]);
                    int month = int.Parse(parts[1]);
                    int key = year * 100 + month;
                    if (key < minValue)
                    {
                        minValue = key;
                        timeInfo = new DateTime(year, month, 1);
                    }
                }
            }
            // return table code
            if (timeInfo != null)
            {
                return GetTable((DateTime)timeInfo);
            }
            else if (minValue != int.MaxValue)
            {
                return Tables[minValue];
            }
            return null;
        }
        /// <summary>
        /// returns the most recent Table
        /// </summary>
        /// <returns></returns>
        public Table? GetNewestTable()
        {
            // obtain newest table in the cache
            int maxValue = int.MinValue;
            foreach (int key in Tables.Keys)
            {
                if (key > maxValue) maxValue = key;
            }
            // check if newer Table exists in files
            DateTime? timeInfo = null;
            if (_TargetDirectory != null)
            {
                FileInfo[] files = _TargetDirectory.GetFiles();
                
                foreach (FileInfo file in files)
                {
                    string filename = Path.GetFileNameWithoutExtension(file.Name);
                    string date = filename.Split('_').Last();
                    string[] parts = filename.Split("-");
                    int year = int.Parse(parts[0]);
                    int month = int.Parse(parts[1]);
                    int key = year * 100 + month;
                    if (key > maxValue)
                    {
                        maxValue = key;
                        timeInfo = new DateTime(year, month, 1);
                    }
                }
            }
            // return table code
            if (timeInfo != null)
            {
                return GetTable((DateTime)timeInfo);
            }
            else if (maxValue != int.MinValue)
            {
                return Tables[maxValue];
            }
            return null;
        }
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
