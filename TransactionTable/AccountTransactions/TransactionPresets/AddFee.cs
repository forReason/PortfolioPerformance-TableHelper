using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;
namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// Adds a fee transaction to the Account Transactions table.
        /// </summary>
        /// <param name="cashAccount">The cash account associated with the fee transaction.</param>
        /// <param name="feeDate">The date of the fee transaction.</param>
        /// <param name="amount">The amount of the fee transaction.</param>
        /// <param name="security">An optional <see cref="Objects.Security"/> object representing the security associated with the fee transaction.</param>
        /// <param name="note">An optional note related to the fee transaction.</param>
        /// <remarks>
        /// YOU must ensure that the currency of the <see cref="Objects.Security"/> object (if provided) matches the currency of the cash account.
        /// </remarks>
        public void AddFee(DateTime feeDate, DepositAccount cashAccount, double amount, Objects.Security? security = null, string? note = null)
        {
            AddFee(feeDate, cashAccount, (decimal)amount, security, note);
        }
        /// <summary>
        /// Adds a fee transaction to the Account Transactions table.
        /// </summary>
        /// <param name="feeDate">The date of the fee transaction.</param>
        /// <param name="cashAccount">The cash account associated with the fee transaction.</param>
        /// <param name="amount">The amount of the fee transaction.</param>
        /// <param name="security">An optional <see cref="Objects.Security"/> object representing the security associated with the fee transaction.</param>
        /// <param name="note">An optional note related to the fee transaction.</param>
        /// <remarks>
        /// YOU must ensure that the currency of the <see cref="Objects.Security"/> object (if provided) matches the currency of the cash account.
        /// </remarks>
        public void AddFee(DateTime feeDate, DepositAccount cashAccount, decimal amount, Objects.Security? security = null ,string? note = null)
        {
            Table table = GetTable(feeDate);
            // insert record at specified position
            int? index = null;
            if (this._KeepTableTimeSorted)
            {
                index = FetchIndexForRecordInsert(feeDate);
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
            table.SetCell(AccountTableHeaders.Type.Name, newRecordIndex, AccountTransactionTypes.Fees.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, newRecordIndex, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(feeDate);
            table.SetCell(AccountTableHeaders.Date.Name, newRecordIndex, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, newRecordIndex, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.Value.Name, newRecordIndex, ((decimal)amount).ToString("G"));
            // set the security
            if (security != null)
            {
                if (security.ISIN != null)
                {
                    table.SetCell(AccountTableHeaders.ISIN.Name, newRecordIndex, security.ISIN);
                }
                if (security.WKN != null)
                {
                    table.SetCell(AccountTableHeaders.WKN.Name, newRecordIndex, security.WKN);
                }
                if (security.TickerSymbol != null)
                {
                    table.SetCell(AccountTableHeaders.Symbol.Name, newRecordIndex, security.TickerSymbol);
                }
                if (security.Name != null)
                {
                    table.SetCell(AccountTableHeaders.SecurityName.Name, newRecordIndex, security.Name);
                }
                table.SetCell(AccountTableHeaders.TransactionCurrency.Name, newRecordIndex, security.ReferenceCurrency);
            }
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, newRecordIndex, note);
            }
        }
    }
}
