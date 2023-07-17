using PortfolioPerformance_TableHelper.Objects;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable
    {
        /// <summary>
        /// Adds a new deposit record for a <b>Deposit Account</b>.<br/>
        /// Sending cash from an outside, untracked account to a portfolio-tracked account
        /// </summary>
        /// <param name="cashAccount">The name of the cash account where the deposit will be recorded.</param>
        /// <param name="depositDate">The date and time when the deposit transaction occurred.</param>
        /// <param name="amount">The amount of the deposit transaction.</param>
        /// <param name="note">An optional note or comment about the deposit transaction.</param>
        /// <remarks>
        /// The cash account's currency is 
        /// to be already defined in the application. 
        /// </remarks>
        public void AddDeposit(DepositAccount cashAccount, DateTime depositDate, double amount, string? note = null)
        {
            AddDeposit(cashAccount, depositDate, (decimal) amount, note);
        }
        /// <summary>
        /// Adds a new deposit record for a <b>Deposit Account</b>.<br/>
        /// Sending cash from an outside, untracked account to a portfolio-tracked account
        /// </summary>
        /// <param name="cashAccount">The name of the cash account where the deposit will be recorded.</param>
        /// <param name="depositDate">The date and time when the deposit transaction occurred.</param>
        /// <param name="amount">The amount of the deposit transaction.</param>
        /// <param name="note">An optional note or comment about the deposit transaction.</param>
        /// <remarks>
        /// The cash account's currency is 
        /// to be already defined in the application. 
        /// </remarks>
        public void AddDeposit(DepositAccount cashAccount, DateTime depositDate, decimal amount, string? note = null)
        {
            int index = Table.AppendEmptyRecord();
            // set transaction type
            Table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.Deposit.Name);
            // select account, currency is defined by account
            Table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(depositDate);
            Table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            Table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            Table.SetCell(AccountTableHeaders.Value.Name, index, amount.ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                Table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
