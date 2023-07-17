using PortfolioPerformance_TableHelper.Objects;
using System.Security.AccessControl;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable
    {
        /// <summary>
        /// Adds a tax transaction to the Account Transactions table.
        /// </summary>
        /// <param name="cashAccount">The cash account associated with the tax transaction.</param>
        /// <param name="depositDate">The date of the tax transaction.</param>
        /// <param name="amount">The amount of the tax transaction.</param>
        /// <param name="security">An optional <see cref="Objects.Security"/> object representing the security associated with the tax transaction.</param>
        /// <param name="note">An optional note related to the tax transaction.</param>
        /// <remarks>
        /// YOU must ensure that the currency of the <see cref="Objects.Security"/> object (if provided) matches the currency of the cash account.
        /// </remarks>
        public void AddTaxRefund(DepositAccount cashAccount, DateTime depositDate, double amount, Objects.Security? security = null, string? note = null)
        {
            AddTaxRefund(cashAccount, depositDate, (decimal)amount, security, note);
        }
        /// <summary>
        /// Adds a tax transaction to the Account Transactions table.
        /// </summary>
        /// <param name="cashAccount">The cash account associated with the tax transaction.</param>
        /// <param name="depositDate">The date of the tax transaction.</param>
        /// <param name="amount">The amount of the tax transaction.</param>
        /// <param name="security">An optional <see cref="Objects.Security"/> object representing the security associated with the tax transaction.</param>
        /// <param name="note">An optional note related to the tax transaction.</param>
        /// <remarks>
        /// YOU must ensure that the currency of the <see cref="Objects.Security"/> object (if provided) matches the currency of the cash account.
        /// </remarks>
        public void AddTaxRefund(DepositAccount cashAccount, DateTime depositDate, decimal amount, Objects.Security? security = null ,string? note = null)
        {
            int index = Table.AppendEmptyRecord();
            // set transaction type
            Table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.TaxRefund.Name);
            // select account, currency is defined by account
            Table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(depositDate);
            Table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            Table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            Table.SetCell(AccountTableHeaders.Value.Name, index, ((decimal)amount).ToString("G"));
            // set the security
            if (security != null)
            {
                if (security.ISIN != null)
                {
                    Table.SetCell(AccountTableHeaders.ISIN.Name, index, security.ISIN);
                }
                if (security.WKN != null)
                {
                    Table.SetCell(AccountTableHeaders.WKN.Name, index, security.WKN);
                }
                if (security.TickerSymbol != null)
                {
                    Table.SetCell(AccountTableHeaders.Symbol.Name, index, security.TickerSymbol);
                }
                if (security.Name != null)
                {
                    Table.SetCell(AccountTableHeaders.SecurityName.Name, index, security.Name);
                }
                Table.SetCell(AccountTableHeaders.TransactionCurrency.Name, index, security.ReferenceCurrency);
            }
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                Table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
