namespace PortfolioPerformance_TableHelper.TransactionTable.PortfolioTransactions
{
    public partial class Table
    {
        /// <summary>
        /// Adds a buy transaction to the portfolio transactions table.
        /// </summary>
        /// <param name="DateTime">The date and time of the transaction.</param>
        /// <param name="SecurityName">The name of the security being bought.</param>
        /// <param name="CashAccount">The name of the cash account associated with the transaction.</param>
        /// <param name="SecuritiesAccount">The name of the securities account where the securities are added.</param>
        /// <param name="GrossValue">The total value of the transaction before taxes and fees.</param>
        /// <param name="ExchangeRate">The exchange rate applicable for the transaction (default is 1).</param>
        /// <param name="Shares">The number of shares being bought (default is -1, which means this field will not be set).</param>
        /// <param name="Fees">The total transaction fee (default is -1, which means this field will not be set).</param>
        /// <param name="Tax">The total tax on the transaction (default is -1, which means this field will not be set).</param>
        /// <param name="WKN">The WKN of the security (default is an empty string, which means this field will not be set).</param>
        /// <param name="ISIN">The ISIN of the security (default is an empty string, which means this field will not be set).</param>
        /// <param name="Symbol">The ticker symbol of the security (default is an empty string, which means this field will not be set).</param>
        /// <param name="Note">A note about the transaction (default is an empty string, which means this field will not be set).</param>

        public void AddBuyTransaction(DateTime DateTime, string SecurityName, string CashAccount, string SecuritiesAccount, double GrossValue,double ExchangeRate = 1 ,double Shares = -1,
            double Fees = -1, double Tax = -1, string WKN = "", string ISIN = "", string Symbol = "", string Note = "")
        {
            int index = MyTable.AppendEmptyRecord();
            MyTable.SetCell(TableHeaders.Type.Name, index, TransactionTypes.Buy.Name);
            SplitDateTime time = DateTimeHelper.Split(DateTime);
            MyTable.SetCell(TableHeaders.Date.Name, index, time.Date);
            MyTable.SetCell(TableHeaders.Time.Name, index, time.Time);
            MyTable.SetCell(TableHeaders.SecurityName.Name, index, SecurityName);
            MyTable.SetCell(TableHeaders.CashAccount.Name, index, CashAccount);
            MyTable.SetCell(TableHeaders.SecuritiesAccount.Name, index, SecuritiesAccount);
            if (Shares != -1)
            {
                MyTable.SetCell(TableHeaders.ShareAmount.Name, index, Shares.ToString());
            }
            MyTable.SetCell(TableHeaders.Value.Name, index, GrossValue.ToString());
            MyTable.SetCell(TableHeaders.CurrencyGrossAmount.Name, index, GrossValue.ToString());
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
                MyTable.SetCell(TableHeaders.Taxes.Name, index, Tax.ToString());
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
