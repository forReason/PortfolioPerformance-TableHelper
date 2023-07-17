namespace PortfolioPerformanceTableHelper
{
    public class AccountTableHeaders
    {
        private AccountTableHeaders(string name) { Name = name; }

        public string Name { get; private set; }

        /// <summary>
        /// The transaction's date.
        /// </summary>
        public static AccountTableHeaders Date => new AccountTableHeaders("Date");

        /// <summary>
        /// The transaction's time, precise to the minute.
        /// </summary>
        public static AccountTableHeaders Time => new AccountTableHeaders("Time");

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        public static AccountTableHeaders Type => new AccountTableHeaders("Type");

        /// <summary>
        /// The WKN identifier of the security, e.g. USDT, ETH.
        /// </summary>
        public static AccountTableHeaders WKN => new AccountTableHeaders("WKN");

        /// <summary>
        /// The ISIN identifier of the security, e.g. USDT, ETH.
        /// </summary>
        public static AccountTableHeaders ISIN => new AccountTableHeaders("ISIN");

        /// <summary>
        /// The ticker symbol of the security, e.g. USDT, ETH.
        /// </summary>
        public static AccountTableHeaders Symbol => new AccountTableHeaders("Ticker Symbol");

        /// <summary>
        /// The human-readable name of the security, e.g. chia, bitcoin, ethereum.
        /// </summary>
        public static AccountTableHeaders SecurityName => new AccountTableHeaders("Security Name");

        /// <summary>
        /// The number of shares involved in the transaction.
        /// </summary>
        public static AccountTableHeaders ShareAmount => new AccountTableHeaders("Shares");

        /// <summary>
        /// The gross amount of the transaction in its original currency.
        /// </summary>
        public static AccountTableHeaders CurrencyGrossAmount => new AccountTableHeaders("Currency Gross Amount");

        /// <summary>
        /// The gross amount of the transaction.
        /// </summary>
        public static AccountTableHeaders GrossAmount => new AccountTableHeaders("Gross Amount");

        /// <summary>
        /// The currency in which the transaction is performed.
        /// </summary>
        public static AccountTableHeaders TransactionCurrency => new AccountTableHeaders("Transaction Currency");

        /// <summary>
        /// The transaction's value in the target account's currency.
        /// </summary>
        public static AccountTableHeaders Value => new AccountTableHeaders("Value");

        /// <summary>
        /// The exchange rate applicable for the transaction. Can be used to calculate share amount, share price, and total price.
        /// </summary>
        public static AccountTableHeaders ExchangeRate => new AccountTableHeaders("Exchange Rate");

        /// <summary>
        /// Fees associated with the transaction, e.g., trading fees.
        /// </summary>
        public static AccountTableHeaders Fees => new AccountTableHeaders("Fees");

        /// <summary>
        /// Taxes imposed by the government on the transaction.
        /// </summary>
        public static AccountTableHeaders Taxes => new AccountTableHeaders("Taxes");

        /// <summary>
        /// Note or comments related to the transaction.
        /// </summary>
        public static AccountTableHeaders Note => new AccountTableHeaders("Note");

        /// <summary>
        /// The securities account related to the transaction where securities are added or removed.
        /// </summary>
        public static AccountTableHeaders SecuritiesAccount => new AccountTableHeaders("Securities Account");

        /// <summary>
        /// The offset account related to the transaction.
        /// </summary>
        public static AccountTableHeaders OffsetAccount => new AccountTableHeaders("Offset Account");

        /// <summary>
        /// The cash account related to the transaction. It determines the currency in which the transaction value is calculated.
        /// </summary>
        public static AccountTableHeaders CashAccount => new AccountTableHeaders("Cash Account");


        public static AccountTableHeaders[] ToArray()
        {
            return new AccountTableHeaders[] { Date, Time,Type,WKN,ISIN,Symbol,SecurityName, ShareAmount,CurrencyGrossAmount,GrossAmount,
                TransactionCurrency,Value,ExchangeRate,Fees,Taxes,Note,SecuritiesAccount,OffsetAccount,CashAccount };
        }
        public static string[] ToStringArray()
        {
            List<string> list = new List<string>();
            foreach(AccountTableHeaders header in ToArray())
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
