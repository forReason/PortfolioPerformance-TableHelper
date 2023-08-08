using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset
{
    public partial class TransactionsTable
    {
        /// <summary>
        /// retrieves the time based index of the table<br/>
        /// <b>Returns null, if the record were to be appended at the end of the table</b>
        /// </summary>
        /// <remarks>
        /// This index returns where the value should be.<br/>
        /// It does not mean that a record with that date actually exists in the table. 
        /// </remarks>
        /// <param name="recordDate">The requested DateTime of the record.</param>
        public int? FetchIndexForRecordInsert(DateTime recordDate)
        {
            Table table = GetTable(recordDate);
            // check if insert at 0
            string firstDate = table.GetCell(0, PortfolioTableHeaders.Date.ToString());
            string firstTime = table.GetCell(0, PortfolioTableHeaders.Time.ToString());
            DateTime firstTransactionTime = DateTimeHelper.Merge(firstDate, firstTime);
            if (recordDate < firstTransactionTime)
            {
                return 0;
            }
            // check elements in table
            for (int i = 1; i < table.Length - 1; i++) // only search from index 1-count-1 kecause 3 records are beeing checked
            {
                // fetch current index record's Time
                string date = table.GetCell(i, PortfolioTableHeaders.Date.ToString());
                string time = table.GetCell(i, PortfolioTableHeaders.Time.ToString());
                DateTime currentRecord = DateTimeHelper.Merge(date, time);
                if (currentRecord == recordDate)
                {
                    return i;
                }
                // Fetch time of Previous record
                string prevDate = table.GetCell(i-1, PortfolioTableHeaders.Date.ToString());
                string prevTime = table.GetCell(i-1, PortfolioTableHeaders.Time.ToString());
                DateTime prevRecod = DateTimeHelper.Merge(prevDate, prevTime);
                // Fetch Time of next record
                if (prevRecod <= recordDate && currentRecord >= recordDate)
                {
                    return i;
                }
            }
            // means the record were to be appended to the table
            return null;
        }
    }
}
