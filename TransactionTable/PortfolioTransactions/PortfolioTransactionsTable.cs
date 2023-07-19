using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;

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
    public partial class PortfolioTransactionsTable : TransactionsTable
    {
        // Derived class specific properties, fields, and methods go here

        public PortfolioTransactionsTable(FileInfo file, bool splitByMonths)
            : base(file, splitByMonths, PortfolioTableHeaders.ToStringArray())
        {
            // You can add more initialization here if necessary
        }
    }
}
