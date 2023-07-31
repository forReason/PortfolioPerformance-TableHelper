using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.Objects;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class PortfolioTransactionsTable
    {
        /// <summary>
        /// Adds a transfer of securities between accounts.
        /// </summary>
        /// <param name="transferDate">The date of the transfer.</param>
        /// <param name="sourceAccount">The securities account where the transfer is taking place.</param>
        /// <param name="targetAccount">The offset securities account, if any. If specified, this account will be used as the source (for inbound transfers) or destination (for outbound transfers).</param>
        /// <param name="security">The security being transferred.</param>
        /// <param name="shares">The amount of shares being transferred.</param>
        /// <param name="transactionValue">The transaction value of the transferred shares. The value represents the price per share multiplied by the amount of shares at the time of the transfer.</param>
        /// <param name="fees">Any fees associated with the transfer, defaults to 0 if not provided.</param>
        /// <param name="note">Any additional notes about the transfer.</param>
        public void AddTransfer(DateTime transferDate, 
            SecuritiesAccount sourceAccount, SecuritiesAccount targetAccount, Security security, 
            double shares, double transactionValue = 0, double fees = 0,string? note = null)
        {
            AddTransfer(transferDate, sourceAccount, targetAccount,security, shares, transactionValue, fees, note);
        }
        /// <summary>
        /// Adds a transfer of securities between accounts.
        /// </summary>
        /// <param name="transferDate">The date of the transfer.</param>
        /// <param name="sourceAccount">The securities account where the transfer is taking place.</param>
        /// <param name="targetAccount">The offset securities account, if any. If specified, this account will be used as the source (for inbound transfers) or destination (for outbound transfers).</param>
        /// <param name="security">The security being transferred.</param>
        /// <param name="shares">The amount of shares being transferred.</param>
        /// <param name="transactionValue">The transaction value of the transferred shares. The value represents the price per share multiplied by the amount of shares at the time of the transfer.</param>
        /// <param name="fees">Any fees associated with the transfer, defaults to 0 if not provided.</param>
        /// <param name="note">Any additional notes about the transfer.</param>
        public void AddTransfer(DateTime transferDate, 
            SecuritiesAccount sourceAccount, SecuritiesAccount targetAccount, Security security, 
            decimal shares, decimal transactionValue = 0m, decimal fees = 0, string? note = null)
        {
            Table table = GetTable(transferDate);
            int index = table.AppendEmptyRecord();
            // set Transaction Type
            table.SetCell(PortfolioTableHeaders.Type.Name, index, PortfolioTransactionTypes.TransferOutbound.Name);
            // select account, currency is defined by account
            //Table.SetCell(PortfolioTableHeaders.CashAccount.Name, index, account.Name);
            table.SetCell(PortfolioTableHeaders.SecuritiesAccount.Name, index, sourceAccount.Name);
            table.SetCell(PortfolioTableHeaders.OffsetSecuritiesAccount.Name, index, targetAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(transferDate);
            table.SetCell(PortfolioTableHeaders.Date.Name, index, time.Date);
            table.SetCell(PortfolioTableHeaders.Time.Name, index, time.Time);
            // set the security
            if (security != null)
            {
                if (security.ISIN != null)
                {
                    table.SetCell(PortfolioTableHeaders.ISIN.Name, index, security.ISIN);
                }
                if (security.WKN != null)
                {
                    table.SetCell(PortfolioTableHeaders.WKN.Name, index, security.WKN);
                }
                if (security.TickerSymbol != null)
                {
                    table.SetCell(PortfolioTableHeaders.Symbol.Name, index, security.TickerSymbol);
                }
                if (security.Name != null)
                {
                    table.SetCell(PortfolioTableHeaders.SecurityName.Name, index, security.Name);
                }
                table.SetCell(PortfolioTableHeaders.TransactionCurrency.Name, index, security.ReferenceCurrency);
            }
            // set the amount
            table.SetCell(PortfolioTableHeaders.ShareAmount.Name, index, shares.ToString("G"));
            if(transactionValue != 0m)
            {
                table.SetCell(PortfolioTableHeaders.Value.Name, index, transactionValue.ToString("G"));
            }
            table.SetCell(PortfolioTableHeaders.Fees.Name, index, fees.ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
