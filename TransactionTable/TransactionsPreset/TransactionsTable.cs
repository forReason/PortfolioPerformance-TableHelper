
namespace PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset
{
    /// <summary>
    /// This class specifically handles the organization and management of <b>`Deposit Account`</b>-related transaction data.<br/><br/>
    /// 
    /// The <c>AccountTransactionsTable</c> should contain instances of <c>AccountTransactionTypes</c> which encompass:<br/>
    /// <c>Deposits, Withdraws, Transfers , Dividend, Fees, Taxes and Interest.</c><br/>
    /// please refer to <seealso cref="AccountTransactionTypes"/> for a comprehensive list<br/><br/>
    /// </summary>
    /// <remarks>
    /// It's important to note that the <c>AccountTransactionsTable</c> does not validate the transaction data or conduct financial 
    /// computations. Its main responsibility is to facilitate the structuring and management of CSV tables for import into 
    /// the Portfolio Performance tool.
    /// </remarks>
    public partial class TransactionsTable
    {
        /// <summary>
        /// Initializes a new instance of the AccountTransactionsTable class.
        /// </summary>
        public TransactionsTable(FileInfo file, bool splitByMonths, string[] headers)
        {
            _SplitByMonth = splitByMonths;
            _FileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.Name);
            GenerateDirectory(file);
            _Headers = headers;
        }
        /// <summary>
        /// defines if the files should be split by month value
        /// </summary>
        private bool _SplitByMonth { get; set; }
        /// <summary>
        /// defines the headers of the table
        /// </summary>
        private string[] _Headers { get; set; }
    }
}
