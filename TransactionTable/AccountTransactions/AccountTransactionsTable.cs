
namespace PortfolioPerformanceTableHelper
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
    public partial class AccountTransactionsTable
    {
        /// <summary>
        /// Initializes a new instance of the AccountTransactionsTable class.
        /// </summary>
        public AccountTransactionsTable()
        {
            Table = new QuickCsv.Net.Table_NS.Table();
            Table.SetColumnNames(AccountTableHeaders.ToStringArray());
        }
        /// <summary>
        /// Gets or sets the underlying QuickCsv.Net.Table_NS.Table.
        /// </summary>
        public QuickCsv.Net.Table_NS.Table Table { get; set; }
        /// <summary>
        /// Saves the table to a file.
        /// </summary>
        /// <param name="fileName">The path of the file to write to.</param>
        public void Save(string fileName = "AccountTransactions.csv")
        {
            Table.WriteTableToFile(fileName);
        }
    }
}
