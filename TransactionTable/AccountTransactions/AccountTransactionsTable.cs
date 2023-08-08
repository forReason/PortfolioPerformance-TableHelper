
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;

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
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// creates a new AccountTransactionsTable from the base class TransactionsTable
        /// </summary>
        /// <param name="file"></param>
        /// <param name="splitByMonths"></param>
        /// <param name="keepTimeSorted"></param>
        public AccountTransactionsTable(FileInfo file, bool splitByMonths, bool keepTimeSorted = true)
            : base(file, splitByMonths, AccountTableHeaders.ToStringArray(), keepTimeSorted)
        {
            // You can add more initialization here if necessary
        }
    }
}
