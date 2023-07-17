namespace PortfolioPerformanceTableHelper
{
    /// <summary>
    /// This class specifically handles the organization and management of <b>`Securities Account`</b>-related transaction data.<br/><br/>
    ///
    /// The <c>PortfolioTransactionsTable</c> should contain instances of <c>PortfolioTransactionTypes</c> which encompass:<br/>
    /// <c>Buy, Sell, Transfers, DeliveryInbound, and DeliveryOutbound.</c><br/>
    /// please refer to <seealso cref="PortfolioTransactionTypes"/> for a comprehensive list<br/><br/>
    /// </summary>
    /// <remarks>
    /// It's important to note that the <c>PortfolioTransactionsTable</c> does not validate the transaction data or conduct 
    /// financial computations. Its main responsibility is to facilitate the structuring and management of CSV tables for 
    /// import into the Portfolio Performance tool.
    /// </remarks>
    public partial class PortfolioTransactionsTable
    {
        /// <summary>
        /// Initializes a new instance of the PortfolioTransactionsTable class.
        /// </summary>
        public PortfolioTransactionsTable()
        {
            Table = new QuickCsv.Net.Table_NS.Table();
            Table.SetColumnNames(PortfolioTableHeaders.ToStringArray());
        }
        /// <summary>
        /// Gets or sets the underlying QuickCsv.Net.Table_NS.Table.
        /// </summary>
        public QuickCsv.Net.Table_NS.Table Table { get; set; }
        /// <summary>
        /// Saves the table to a file.
        /// </summary>
        /// <param name="fileName">The path of the file to write to.</param>
        public void Save(string fileName = "PortfolioTransactions.csv")
        {
            Table.WriteTableToFile(fileName);
        }
    }
}
