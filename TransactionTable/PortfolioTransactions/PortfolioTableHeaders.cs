namespace PortfolioPerformanceTableHelper
{
    /// <summary>
    /// is a string-able enum representation of the table headers
    /// </summary>
    public class PortfolioTableHeaders
    {
        private PortfolioTableHeaders(string name) { Name = name; }

        /// <summary>
        /// Gets the string representation of the Table Header.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Represents the date of the transaction. This field should contain a valid date in the format yyyy-MM-dd.
        /// </summary>
        public static PortfolioTableHeaders Date => new PortfolioTableHeaders("Date");

        /// <summary>
        /// Represents the time of the transaction, precise up to the minute. This field should contain a valid time in the format HH:mm.
        /// </summary>
        public static PortfolioTableHeaders Time => new PortfolioTableHeaders("Time");

        /// <summary>
        /// Specifies the type of the transaction. This field should be one of the predefined transaction types, such as 'Buy', 'Sell', etc.
        /// </summary>
        public static PortfolioTableHeaders Type => new PortfolioTableHeaders("Type");

        /// <summary>
        /// Represents the WKN identifier of the security. This field should contain the specific WKN identifier, for instance 'USDT', 'ETH', etc.
        /// </summary>
        public static PortfolioTableHeaders WKN => new PortfolioTableHeaders("WKN");

        /// <summary>
        /// Represents the ISIN identifier of the security. This field should contain a valid ISIN for the security.
        /// </summary>
        public static PortfolioTableHeaders ISIN => new PortfolioTableHeaders("ISIN");

        /// <summary>
        /// Represents the ticker symbol of the security. This field should contain the symbol as used in exchanges, such as 'AAPL' for Apple Inc.
        /// </summary>
        public static PortfolioTableHeaders Symbol => new PortfolioTableHeaders("Ticker Symbol");

        /// <summary>
        /// Specifies the human-readable name of the security. This field should contain the full name of the security.
        /// </summary>
        public static PortfolioTableHeaders SecurityName => new PortfolioTableHeaders("Security Name");

        /// <summary>
        /// Denotes the number of shares involved in the transaction. This field should contain a numerical value.
        /// </summary>
        public static PortfolioTableHeaders ShareAmount => new PortfolioTableHeaders("Shares");

        /// <summary>
        /// Represents the gross amount of the transaction in the original currency. This field should contain a numerical value.
        /// </summary>
        public static PortfolioTableHeaders CurrencyGrossAmount => new PortfolioTableHeaders("Currency Gross Amount");

        /// <summary>
        /// Represents the gross amount of the transaction. This field should contain a numerical value.
        /// </summary>
        public static PortfolioTableHeaders GrossAmount => new PortfolioTableHeaders("Gross Amount");

        /// <summary>
        /// Specifies the currency in which the transaction was conducted. This field should contain a valid currency code, such as 'USD', 'EUR', etc.
        /// </summary>
        public static PortfolioTableHeaders TransactionCurrency => new PortfolioTableHeaders("Transaction Currency");

        /// <summary>
        /// Represents the net value of the transaction in the target account's currency. This field should contain a numerical value.
        /// </summary>
        public static PortfolioTableHeaders Value => new PortfolioTableHeaders("Value");

        /// <summary>
        /// Denotes the exchange rate used for this transaction. This field is used to convert between the transaction currency and the account's base currency.
        /// </summary>
        public static PortfolioTableHeaders ExchangeRate => new PortfolioTableHeaders("Exchange Rate");

        /// <summary>
        /// Specifies any trading or transaction fees associated with this transaction. This field should contain a numerical value.
        /// </summary>
        public static PortfolioTableHeaders Fees => new PortfolioTableHeaders("Fees");

        /// <summary>
        /// Specifies any government taxes applied to this transaction. This field should contain a numerical value.
        /// </summary>
        public static PortfolioTableHeaders Taxes => new PortfolioTableHeaders("Taxes");

        /// <summary>
        /// Allows for any additional notes or details about the transaction. This field may contain any string.
        /// </summary>
        public static PortfolioTableHeaders Note => new PortfolioTableHeaders("Note");

        /// <summary>
        /// Specifies the associated securities account for this transaction. This field should contain the identifier of the securities account.
        /// </summary>
        public static PortfolioTableHeaders SecuritiesAccount => new PortfolioTableHeaders("Securities Account");

        /// <summary>
        /// Specifies the associated offset securities account for this transaction. This field should contain the identifier of the offset securities account.
        /// </summary>
        public static PortfolioTableHeaders OffsetSecuritiesAccount => new PortfolioTableHeaders("Offset securities account");

        /// <summary>
        /// Specifies the associated cash account for this transaction. This field should contain the identifier of the cash account.
        /// </summary>
        public static PortfolioTableHeaders CashAccount => new PortfolioTableHeaders("Cash Account");

        /// <summary>
        /// returns an array of all availble Portfolio Header Objects
        /// </summary>
        /// <returns></returns>
        public static PortfolioTableHeaders[] ToArray()
        {
            return new PortfolioTableHeaders[] { Date, Time,Type,WKN,ISIN,Symbol,SecurityName, ShareAmount,CurrencyGrossAmount,GrossAmount,
                TransactionCurrency,Value,ExchangeRate,Fees,Taxes,Note,SecuritiesAccount,OffsetSecuritiesAccount,CashAccount };
        }
        /// <summary>
        /// returns an array of all availble Portfolio Header Object names as strings
        /// </summary>
        /// <returns></returns>
        public static string[] ToStringArray()
        {
            List<string> list = new List<string>();
            foreach(PortfolioTableHeaders header in ToArray())
            {
                list.Add(header.ToString());
            }
            return list.ToArray();
        }
        /// <summary>
        /// Gets the string representation of the Table Header.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }
    }
}
