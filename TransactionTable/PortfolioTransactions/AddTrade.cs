using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPerformance_TableHelper.TransactionTable.PortfolioTransactions
{
    public partial class Table
    {
        public void AddBuyTransaction(DateTime DateTime, string SecurityName, string CashAccount, double GrossValue,double ExchangeRate = 1 ,double Shares = -1,
            double Fees = -1, double Tax = -1, string WKN = "", string ISIN = "", string Symbol = "", string Note = "")
        {
            int index = MyTable.AppendEmptyRecord();
            MyTable.SetCell(TableHeaders.Type.Name, index, TransactionTypes.Buy.Name);
            SplitDateTime time = DateTimeHelper.Split(DateTime);
            MyTable.SetCell(TableHeaders.Date.Name, index, time.Date);
            MyTable.SetCell(TableHeaders.Time.Name, index, time.Time);
            MyTable.SetCell(TableHeaders.SecurityName.Name, index, SecurityName);
            MyTable.SetCell(TableHeaders.CashAccount.Name, index, CashAccount);
            if (Shares != -1)
            {
                MyTable.SetCell(TableHeaders.ShareAmount.Name, index, Shares.ToString());
            }
            //MyTable.SetCell(TableHeaders.GrossAmount.Name, index, GrossValue.ToString());
            MyTable.SetCell(TableHeaders.Value.Name, index, GrossValue.ToString());
            MyTable.SetCell(TableHeaders.CurrencyGrossAmount.Name, index, GrossValue.ToString());
            //MyTable.SetCell(TableHeaders.GrossAmount.Name, index, GrossValue.ToString());
            //MyTable.SetCell(TableHeaders.TransactionCurrency.Name, index, "CHF");
            if (ExchangeRate != -1)
            {
                MyTable.SetCell(TableHeaders.ExchangeRate.Name, index, ExchangeRate.ToString());
            }
            if (Fees != -1)
            {
                MyTable.SetCell(TableHeaders.Fees.Name, index, Fees.ToString());
            }
            if (Tax != -1)
            {
                MyTable.SetCell(TableHeaders.Taxes.Name, index, Fees.ToString());
            }
            if (WKN != "")
            {
                MyTable.SetCell(TableHeaders.WKN.Name, index, WKN);
            }
            if (ISIN != "")
            {
                MyTable.SetCell(TableHeaders.ISIN.Name, index, ISIN);
            }
            if (Symbol != "")
            {
                MyTable.SetCell(TableHeaders.Symbol.Name, index, Symbol);
            }
            if (Note != "")
            {
                MyTable.SetCell(TableHeaders.Note.Name, index, Note);
            }
        }
    }
}
