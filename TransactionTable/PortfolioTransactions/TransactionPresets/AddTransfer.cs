using PortfolioPerformance_TableHelper.Objects;
using PortfolioPerformanceTableHelper.Objects;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable
    {

        public void AddTransfer(SecuritiesAccount sourceAccount, SecuritiesAccount targetAccount, DateTime depositDate, Security security, double shares, double fees = 0,string? note = null)
        {
            AddTransfer(TransferType.Outbound, sourceAccount, security, depositDate, shares, fees, note);
            AddTransfer(TransferType.Inbound, targetAccount, security, depositDate, shares, fees, note);
        }

        public void AddTransfer(SecuritiesAccount sourceAccount, SecuritiesAccount targetAccount, DateTime depositDate, Security security, decimal shares, decimal fees = 0, string? note = null)
        {
            AddTransfer(TransferType.Outbound, sourceAccount, security, depositDate, shares, fees, note);
            AddTransfer(TransferType.Inbound, targetAccount, security, depositDate, shares, fees, note);
        }

        public void AddTransfer(TransferType type, SecuritiesAccount account, Security security, DateTime depositDate, double shares, double fees = 0, string? note = null)
        {
            AddTransfer(type, account, security, depositDate, (decimal) shares, (decimal) fees, note);
        }

        public void AddTransfer(TransferType type, SecuritiesAccount account, Security security, DateTime depositDate, decimal shares, decimal fees = 0, string? note = null)
        {
            int index = Table.AppendEmptyRecord();
            // set Transaction Type
            if (type == TransferType.Inbound)
            {
                Table.SetCell(PortfolioTableHeaders.Type.Name, index, PortfolioTransactionTypes.TransferInbound.Name);
            }
            else
            {
                Table.SetCell(PortfolioTableHeaders.Type.Name, index, PortfolioTransactionTypes.TransferOutbound.Name);
            }
            // select account, currency is defined by account
            Table.SetCell(PortfolioTableHeaders.SecuritiesAccount.Name, index, account.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(depositDate);
            Table.SetCell(PortfolioTableHeaders.Date.Name, index, time.Date);
            Table.SetCell(PortfolioTableHeaders.Time.Name, index, time.Time);
            // set the security
            if (security != null)
            {
                if (security.ISIN != null)
                {
                    Table.SetCell(PortfolioTableHeaders.ISIN.Name, index, security.ISIN);
                }
                if (security.WKN != null)
                {
                    Table.SetCell(PortfolioTableHeaders.WKN.Name, index, security.WKN);
                }
                if (security.TickerSymbol != null)
                {
                    Table.SetCell(PortfolioTableHeaders.Symbol.Name, index, security.TickerSymbol);
                }
                if (security.Name != null)
                {
                    Table.SetCell(PortfolioTableHeaders.SecurityName.Name, index, security.Name);
                }
                Table.SetCell(PortfolioTableHeaders.TransactionCurrency.Name, index, security.ReferenceCurrency);
            }
            // set the amount
            Table.SetCell(PortfolioTableHeaders.ShareAmount.Name, index, shares.ToString("G"));
            Table.SetCell(PortfolioTableHeaders.Fees.Name, index, fees.ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                Table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
