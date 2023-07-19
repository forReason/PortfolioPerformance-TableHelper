using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;
using System.Security.AccessControl;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// Adds a tax transaction to the Account Transactions table.
        /// </summary>
        /// <param name="taxDate">The date of the tax transaction.</param>
        /// <param name="cashAccount">The cash account associated with the tax transaction.</param>
        /// <param name="amount">The amount of the tax transaction.</param>
        /// <param name="security">An optional <see cref="Objects.Security"/> object representing the security associated with the tax transaction.</param>
        /// <param name="note">An optional note related to the tax transaction.</param>
        /// <remarks>
        /// YOU must ensure that the currency of the <see cref="Objects.Security"/> object (if provided) matches the currency of the cash account.
        /// </remarks>
        public void AddTaxRefund(DateTime taxDate, DepositAccount cashAccount, double amount, Objects.Security? security = null, string? note = null)
        {
            AddTaxRefund(taxDate, cashAccount, (decimal)amount, security, note);
        }
        /// <summary>
        /// Adds a tax transaction to the Account Transactions table.
        /// </summary>
        /// <param name="taxDate">The date of the tax transaction.</param>
        /// <param name="cashAccount">The cash account associated with the tax transaction.</param>
        /// <param name="amount">The amount of the tax transaction.</param>
        /// <param name="security">An optional <see cref="Objects.Security"/> object representing the security associated with the tax transaction.</param>
        /// <param name="note">An optional note related to the tax transaction.</param>
        /// <remarks>
        /// YOU must ensure that the currency of the <see cref="Objects.Security"/> object (if provided) matches the currency of the cash account.
        /// </remarks>
        public void AddTaxRefund(DateTime taxDate, DepositAccount cashAccount, decimal amount, Objects.Security? security = null ,string? note = null)
        {
            Table table = GetTable(taxDate);
            int index = table.AppendEmptyRecord();
            // set transaction type
            table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.TaxRefund.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(taxDate);
            table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.Value.Name, index, ((decimal)amount).ToString("G"));
            // set the security
            if (security != null)
            {
                if (security.ISIN != null)
                {
                    table.SetCell(AccountTableHeaders.ISIN.Name, index, security.ISIN);
                }
                if (security.WKN != null)
                {
                    table.SetCell(AccountTableHeaders.WKN.Name, index, security.WKN);
                }
                if (security.TickerSymbol != null)
                {
                    table.SetCell(AccountTableHeaders.Symbol.Name, index, security.TickerSymbol);
                }
                if (security.Name != null)
                {
                    table.SetCell(AccountTableHeaders.SecurityName.Name, index, security.Name);
                }
                table.SetCell(AccountTableHeaders.TransactionCurrency.Name, index, security.ReferenceCurrency);
            }
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
