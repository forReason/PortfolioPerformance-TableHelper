using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// Adds a dividend transaction to the Account Transactions table.
        /// </summary>
        /// <param name="dividendDate">The date when the dividend was credited to the account.</param>
        /// <param name="cashAccount">The account credited with the dividend.</param>
        /// <param name="security">The security that generated the dividend.</param>
        /// <param name="shareAmount">The number of shares that generated the dividend.</param>
        /// <param name="creditNote">The amount credited to the account, after taxes and fees deduction.</param>
        /// <param name="fees">Any fees associated with the dividend transaction. Defaults to 0.</param>
        /// <param name="taxes">Any taxes levied on the dividend. Defaults to 0.</param>
        /// <param name="note">An optional note associated with the dividend transaction.</param>
        /// <remarks>
        /// The <c>AddDividend</c> method captures dividend transactions in the Account Transactions table. 
        /// The <c>creditNote</c> parameter represents the net amount that is credited to the account after deduction 
        /// of taxes and fees from the gross dividend. The gross dividend amount is automatically calculated as the sum 
        /// of the <c>creditNote</c>, <c>taxes</c>, and <c>fees</c>.
        /// As such, users should ensure that they correctly calculate the <c>creditNote</c> amount before 
        /// calling this method.
        /// </remarks>
        public void AddDividend
            (DateTime dividendDate, DepositAccount cashAccount, Security security, 
            double shareAmount, double creditNote, double fees = 0, double taxes = 0,
            string? note = null)
        {
            AddDividend
            (dividendDate, cashAccount, security,
            (decimal)shareAmount, (decimal)creditNote, (decimal)fees, (decimal)taxes,
            note);
        }
        /// <summary>
        /// Adds a dividend transaction to the Account Transactions table.
        /// </summary>
        /// <param name="dividendDate">The date when the dividend was credited to the account.</param>
        /// <param name="cashAccount">The account credited with the dividend.</param>
        /// <param name="security">The security that generated the dividend.</param>
        /// <param name="shareAmount">The number of shares that generated the dividend.</param>
        /// <param name="creditNote">The amount credited to the account, after taxes and fees deduction.</param>
        /// <param name="fees">Any fees associated with the dividend transaction. Defaults to 0.</param>
        /// <param name="taxes">Any taxes levied on the dividend. Defaults to 0.</param>
        /// <param name="note">An optional note associated with the dividend transaction.</param>
        /// <remarks>
        /// The <c>AddDividend</c> method captures dividend transactions in the Account Transactions table. 
        /// The <c>creditNote</c> parameter represents the net amount that is credited to the account after deduction 
        /// of taxes and fees from the gross dividend. The gross dividend amount is automatically calculated as the sum 
        /// of the <c>creditNote</c>, <c>taxes</c>, and <c>fees</c>.
        /// As such, users should ensure that they correctly calculate the <c>creditNote</c> amount before 
        /// calling this method.
        /// </remarks>
        public void AddDividend
            (DateTime dividendDate, DepositAccount cashAccount,Security security, 
            decimal shareAmount, decimal creditNote, decimal fees = 0, decimal taxes = 0,
            string? note = null)
        {
            Table table = GetTable(dividendDate);
            int index = table.AppendEmptyRecord();
            // set transaction type
            table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.Dividend.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(dividendDate);
            table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
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
            // set the amount
            table.SetCell(AccountTableHeaders.ShareAmount.Name, index, shareAmount.ToString("G"));
            table.SetCell(AccountTableHeaders.Value.Name, index, creditNote.ToString("G"));
            // set fees
            table.SetCell(AccountTableHeaders.Fees.Name, index, fees.ToString("G"));
            // set taxes
            table.SetCell(AccountTableHeaders.Taxes.Name, index, taxes.ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
