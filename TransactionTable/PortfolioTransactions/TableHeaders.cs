namespace PortfolioPerformance_TableHelper.TransactionTable.PortfolioTransactions
{
    public class TableHeaders
    {
        private TableHeaders(string name) { Name = name; }

        public string Name { get; private set; }
        /// <summary>
        /// Represents the date of the transaction. This field should contain a valid date in the format yyyy-MM-dd.
        /// </summary>
        public static TableHeaders Date => new TableHeaders("Date");

        /// <summary>
        /// Represents the time of the transaction, precise up to the minute. This field should contain a valid time in the format HH:mm.
        /// </summary>
        public static TableHeaders Time => new TableHeaders("Time");

        /// <summary>
        /// Specifies the type of the transaction. This field should be one of the predefined transaction types, such as 'Buy', 'Sell', etc.
        /// </summary>
        public static TableHeaders Type => new TableHeaders("Type");

        /// <summary>
        /// Represents the WKN identifier of the security. This field should contain the specific WKN identifier, for instance 'USDT', 'ETH', etc.
        /// </summary>
        public static TableHeaders WKN => new TableHeaders("WKN");

        /// <summary>
        /// Represents the ISIN identifier of the security. This field should contain a valid ISIN for the security.
        /// </summary>
        public static TableHeaders ISIN => new TableHeaders("ISIN");

        /// <summary>
        /// Represents the ticker symbol of the security. This field should contain the symbol as used in exchanges, such as 'AAPL' for Apple Inc.
        /// </summary>
        public static TableHeaders Symbol => new TableHeaders("Ticker Symbol");

        /// <summary>
        /// Specifies the human-readable name of the security. This field should contain the full name of the security.
        /// </summary>
        public static TableHeaders SecurityName => new TableHeaders("Security Name");

        /// <summary>
        /// Denotes the number of shares involved in the transaction. This field should contain a numerical value.
        /// </summary>
        public static TableHeaders ShareAmount => new TableHeaders("Shares");

        /// <summary>
        /// Represents the gross amount of the transaction in the original currency. This field should contain a numerical value.
        /// </summary>
        public static TableHeaders CurrencyGrossAmount => new TableHeaders("Currency Gross Amount");

        /// <summary>
        /// Represents the gross amount of the transaction. This field should contain a numerical value.
        /// </summary>
        public static TableHeaders GrossAmount => new TableHeaders("Gross Amount");

        /// <summary>
        /// Specifies the currency in which the transaction was conducted. This field should contain a valid currency code, such as 'USD', 'EUR', etc.
        /// </summary>
        public static TableHeaders TransactionCurrency => new TableHeaders("Transaction Currency");

        /// <summary>
        /// Represents the net value of the transaction in the target account's currency. This field should contain a numerical value.
        /// </summary>
        public static TableHeaders Value => new TableHeaders("Value");

        /// <summary>
        /// Denotes the exchange rate used for this transaction. This field is used to convert between the transaction currency and the account's base currency.
        /// </summary>
        public static TableHeaders ExchangeRate => new TableHeaders("Exchange Rate");

        /// <summary>
        /// Specifies any trading or transaction fees associated with this transaction. This field should contain a numerical value.
        /// </summary>
        public static TableHeaders Fees => new TableHeaders("Fees");

        /// <summary>
        /// Specifies any government taxes applied to this transaction. This field should contain a numerical value.
        /// </summary>
        public static TableHeaders Taxes => new TableHeaders("Taxes");

        /// <summary>
        /// Allows for any additional notes or details about the transaction. This field may contain any string.
        /// </summary>
        public static TableHeaders Note => new TableHeaders("Note");

        /// <summary>
        /// Specifies the associated securities account for this transaction. This field should contain the identifier of the securities account.
        /// </summary>
        public static TableHeaders SecuritiesAccount => new TableHeaders("Securities Account");

        /// <summary>
        /// Specifies the associated offset securities account for this transaction. This field should contain the identifier of the offset securities account.
        /// </summary>
        public static TableHeaders OffsetSecuritiesAccount => new TableHeaders("Offset securities account");

        /// <summary>
        /// Specifies the associated cash account for this transaction. This field should contain the identifier of the cash account.
        /// </summary>
        public static TableHeaders CashAccount => new TableHeaders("Cash Account");


        public static TableHeaders[] ToArray()
        {
            return new TableHeaders[] { Date, Time,Type,WKN,ISIN,Symbol,SecurityName, ShareAmount,CurrencyGrossAmount,GrossAmount,
                TransactionCurrency,Value,ExchangeRate,Fees,Taxes,Note,SecuritiesAccount,OffsetSecuritiesAccount,CashAccount };
        }
        public static string[] ToStringArray()
        {
            List<string> list = new List<string>();
            foreach(TableHeaders header in ToArray())
            {
                list.Add(header.ToString());
            }
            return list.ToArray();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
