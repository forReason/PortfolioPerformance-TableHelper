using QuickCsv.Net.Table_NS;
using System;
using System.Globalization;

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
            if (_TargetDirectory != null && _TargetDirectory.Exists)
            {
                FileInfo[] files = _TargetDirectory.GetFiles();

                foreach (FileInfo file in files)
                {
                    string filename = Path.GetFileNameWithoutExtension(file.Name);
                    string date = filename.Split('_').Last();
                    string[] parts = date.Split("-");
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
            if (_TargetDirectory != null && _TargetDirectory.Exists)
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
                    newTable.SetColumnNames(_Headers);
                    Tables[index] = newTable;
                    return newTable;
                }
            }
        }
        /// <summary>
        /// Gets the most recent date and time entry from the newest table.
        /// </summary>
        /// <returns>
        /// The most recent <see cref="DateTime"/> entry from the newest table, 
        /// or <see langword="null"/> if the table doesn't exist. 
        /// </returns>
        /// <exception cref="InvalidDataException">
        /// Throws an <see cref="InvalidDataException"/> if a date and time string cannot be parsed into a <see cref="DateTime"/> object.
        /// </exception>
        public DateTime? GetNewestEntryTime()
        {
            Table? newestTable = GetNewestTable();
            if (newestTable == null) return null;
            DateTime newestTime = DateTime.MinValue;
            int timeColumn = newestTable.GetColumnIndex(AccountTableHeaders.Time.Name);
            int dateColumn = newestTable.GetColumnIndex(AccountTableHeaders.Date.Name);
            for (int i = 0; i < newestTable.Length; i++)
            {
                // set the time
                string dateString = newestTable.GetCell(row: i, column: dateColumn);
                string timeString = newestTable.GetCell(row: i, column: timeColumn);
                string dateTime = $"{dateString} {timeString}";
                if (DateTime.TryParseExact(dateTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime outputDateTime))
                {
                    if (outputDateTime > newestTime) newestTime = outputDateTime;
                }
                else
                {
                    throw new InvalidDataException("DateTime could not be parsed!");
                }
            }
            return newestTime;
        }
        /// <summary>
        /// Gets the oldest date and time entry from the oldest table.
        /// </summary>
        /// <returns>
        /// The oldest <see cref="DateTime"/> entry from the oldest table, 
        /// or <see langword="null"/> if the table doesn't exist. 
        /// </returns>
        /// <exception cref="InvalidDataException">
        /// Throws an <see cref="InvalidDataException"/> if a date and time string cannot be parsed into a <see cref="DateTime"/> object.
        /// </exception>
        public DateTime? GetOldestEntryTime()
        {
            Table oldestTable = GetOldestTable(); // use a function that retrieves the oldest table
            if (oldestTable == null) return null;
            DateTime oldestTime = DateTime.MaxValue;
            int timeColumn = oldestTable.GetColumnIndex(AccountTableHeaders.Time.Name);
            int dateColumn = oldestTable.GetColumnIndex(AccountTableHeaders.Date.Name);
            for (int i = 0; i < oldestTable.Length; i++)
            {
                // set the time
                string dateString = oldestTable.GetCell(row: i, column: dateColumn);
                string timeString = oldestTable.GetCell(row: i, column: timeColumn);
                string dateTime = $"{dateString} {timeString}";
                if (DateTime.TryParseExact(dateTime, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime outputDateTime))
                {
                    if (outputDateTime < oldestTime) oldestTime = outputDateTime;
                }
                else
                {
                    throw new InvalidDataException("DateTime could not be parsed!");
                }
            }
            return oldestTime == DateTime.MaxValue ? (DateTime?)null : oldestTime;
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
