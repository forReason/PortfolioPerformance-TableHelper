using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// Adds a new deposit record for a <b>Deposit Account</b>.<br/>
        /// removing cash from a portfolio-tracked account and sending it outwards
        /// </summary>
        /// <param name="cashAccount">The name of the cash account where the deposit will be recorded.</param>
        /// <param name="depositDate">The date and time when the deposit transaction occurred.</param>
        /// <param name="amount">The amount of the deposit transaction.</param>
        /// <param name="note">An optional note or comment about the deposit transaction.</param>
        /// <remarks>
        /// The cash account's currency is 
        /// to be already defined in the application. 
        /// </remarks>
        public void AddWithdraw(DateTime withdrawDate, DepositAccount cashAccount, double amount, string? note = null)
        {
            AddWithdraw(withdrawDate, cashAccount, (decimal) amount, note);
        }
        /// <summary>
        /// Adds a new deposit record for a <b>Deposit Account</b>.<br/>
        /// removing cash from a portfolio-tracked account and sending it outwards
        /// </summary>
        /// <param name="cashAccount">The name of the cash account where the deposit will be recorded.</param>
        /// <param name="depositDate">The date and time when the deposit transaction occurred.</param>
        /// <param name="amount">The amount of the deposit transaction.</param>
        /// <param name="note">An optional note or comment about the deposit transaction.</param>
        /// <remarks>
        /// The cash account's currency is 
        /// to be already defined in the application. 
        /// </remarks>
        public void AddWithdraw(DateTime withdrawDate, DepositAccount cashAccount, decimal amount, string? note = null)
        {
            Table table = GetTable(withdrawDate);
            int index = table.AppendEmptyRecord();
            // set Transaction Type
            table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.Withdraw.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(withdrawDate);
            table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.Value.Name, index, amount.ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
