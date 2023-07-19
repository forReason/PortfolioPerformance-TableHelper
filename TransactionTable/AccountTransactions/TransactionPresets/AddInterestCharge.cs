using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// <b>WARNING:</b> As of writing of this code, there is a bug which discads tax values in interest payments:<br/>
        /// <see href="https://github.com/buchen/portfolio/issues/3449"/> you might want to split it into one interest and one Tax.<br/><br/>
        /// Adds an interest transaction to the <c>AccountTransactionsTable</c>.<br/>
        /// typically related to interest received from holding cash or cash equivalents.
        /// </summary>
        /// <param name="interestDate">The date of the interest transaction.</param>
        /// <param name="cashAccount">The name of the cash account to which the interest is credited.</param>
        /// <param name="grossAmount">The gross amount of the interest transaction before tax deductions.</param>
        /// <param name="note">Any additional notes associated with the interest transaction. Defaults to null.</param>
        /// <remarks>
        /// The final amount credited to the cash account will be the gross amount minus the taxes (i.e., grossAmount - taxes).
        /// This method will throw an ArgumentOutOfRangeException if the tax amount is greater than the gross amount of interest.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax amount is greater than the gross amount of interest.</exception>   
        public void AddInterestCharge(DateTime interestDate, DepositAccount cashAccount, double grossAmount, string? note = null)
        {
            AddInterestCharge(interestDate, cashAccount, (decimal)grossAmount, note);
        }
        /// <summary>
        /// <b>WARNING:</b> As of writing of this code, there is a bug which discads tax values in interest payments:<br/>
        /// <see href="https://github.com/buchen/portfolio/issues/3449"/> you might want to split it into one interest and one Tax.<br/><br/>
        /// Adds an interest transaction to the <c>AccountTransactionsTable</c>.<br/>
        /// typically related to interest received from holding cash or cash equivalents.
        /// </summary>
        /// <param name="interestDate">The date of the interest transaction.</param>
        /// <param name="cashAccount">The name of the cash account to which the interest is credited.</param>
        /// <param name="amount">The gross amount of the interest transaction before tax deductions.</param>
        /// <param name="note">Any additional notes associated with the interest transaction. Defaults to null.</param>
        /// <remarks>
        /// The final amount credited to the cash account will be the gross amount minus the taxes (i.e., grossAmount - taxes).
        /// This method will throw an ArgumentOutOfRangeException if the tax amount is greater than the gross amount of interest.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax amount is greater than the gross amount of interest.</exception>   
        public void AddInterestCharge(DateTime interestDate, DepositAccount cashAccount, decimal amount, string? note = null)
        {
            Table table = GetTable(interestDate);
            int index = table.AppendEmptyRecord();
            // set transaction type
            table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.InterestCharge.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(interestDate);
            table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.Value.Name, index, ((decimal)amount).ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
