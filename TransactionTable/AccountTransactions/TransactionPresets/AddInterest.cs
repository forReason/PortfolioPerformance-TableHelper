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
        /// <param name="taxes">The amount of taxes on the interest transaction. It should not be larger than the gross amount. Defaults to null.</param>
        /// <param name="note">Any additional notes associated with the interest transaction. Defaults to null.</param>
        /// <remarks>
        /// The final amount credited to the cash account will be the gross amount minus the taxes (i.e., grossAmount - taxes).
        /// This method will throw an ArgumentOutOfRangeException if the tax amount is greater than the gross amount of interest.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax amount is greater than the gross amount of interest.</exception>   
        public void AddInterest(DateTime interestDate, DepositAccount cashAccount, 
            double grossAmount, double? taxes = null,
            string? note = null)
        {
            AddInterest(interestDate, cashAccount, (decimal)grossAmount, (decimal?) taxes, note);
        }
        /// <summary>
        /// <b>WARNING:</b> As of writing of this code, there is a bug which discads tax values in interest payments:<br/>
        /// <see href="https://github.com/buchen/portfolio/issues/3449"/> you might want to split it into one interest and one Tax.<br/><br/>
        /// Adds an interest transaction to the <c>AccountTransactionsTable</c>.<br/>
        /// typically related to interest received from holding cash or cash equivalents.
        /// </summary>
        /// <param name="interestDate">The date of the interest transaction.</param>
        /// <param name="cashAccount">The name of the cash account to which the interest is credited.</param>
        /// <param name="grossAmount">The gross amount of the interest transaction before tax deductions.</param>
        /// <param name="taxes">The amount of taxes on the interest transaction. It should not be larger than the gross amount. Defaults to null.</param>
        /// <param name="note">Any additional notes associated with the interest transaction. Defaults to null.</param>
        /// <remarks>
        /// The final amount credited to the cash account will be the gross amount minus the taxes (i.e., grossAmount - taxes).
        /// This method will throw an ArgumentOutOfRangeException if the tax amount is greater than the gross amount of interest.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax amount is greater than the gross amount of interest.</exception>   
        public void AddInterest(DateTime interestDate, DepositAccount cashAccount, 
            decimal grossAmount, decimal? taxes = null,
            string? note = null)
        {
            if (taxes != null)
            {
                if (taxes > grossAmount)
                {
                    throw new ArgumentOutOfRangeException(nameof(taxes), "Taxes can't be larger than interest!");
                }
            }
            Table table = GetTable(interestDate);
            // insert record at specified position
            int? index = null;
            if (this._KeepTableTimeSorted)
            {
                index = FetchIndexForRecordInsert(interestDate);
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
            table.SetCell(AccountTableHeaders.Type.Name, newRecordIndex, AccountTransactionTypes.Interest.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, newRecordIndex, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(interestDate);
            table.SetCell(AccountTableHeaders.Date.Name, newRecordIndex, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, newRecordIndex, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.GrossAmount.Name, newRecordIndex, ((decimal)grossAmount).ToString("G"));
            // set taxes
            if (taxes != null)
            {
                table.SetCell(AccountTableHeaders.Taxes.Name, newRecordIndex, ((decimal)taxes).ToString("G"));
                table.SetCell(AccountTableHeaders.Value.Name, newRecordIndex, ((decimal)(grossAmount-taxes)).ToString("G"));
            }
            else
            {
                table.SetCell(AccountTableHeaders.Value.Name, newRecordIndex, ((decimal)(grossAmount)).ToString("G"));
            }
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, newRecordIndex, note);
            }
        }
    }
}
