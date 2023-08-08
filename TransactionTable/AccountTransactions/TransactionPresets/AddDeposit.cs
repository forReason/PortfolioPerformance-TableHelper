using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
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
        public void AddDeposit(DateTime depositDate, DepositAccount cashAccount, double amount, string? note = null)
        {
            AddDeposit(depositDate, cashAccount, (decimal) amount, note);
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
        public void AddDeposit(DateTime depositDate, DepositAccount cashAccount, decimal amount, string? note = null)
        {
            Table table = GetTable(depositDate);
            // insert record at specified position
            int? index = null;
            if (this._KeepTableTimeSorted)
            {
                index = FetchIndexForRecordInsert(depositDate);
            }
            int newRecordIndex;
            if (index == null)
            {
                newRecordIndex = table.AppendEmptyRecord();
            }
            else
            {
                newRecordIndex = index.Value;
                table.InsertEmptyRecord(newRecordIndex);
            }
            // set transaction type
            table.SetCell(AccountTableHeaders.Type.Name, newRecordIndex, AccountTransactionTypes.Deposit.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, newRecordIndex, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(depositDate);
            table.SetCell(AccountTableHeaders.Date.Name, newRecordIndex, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, newRecordIndex, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.Value.Name, newRecordIndex, amount.ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, newRecordIndex, note);
            }
        }
    }
}
