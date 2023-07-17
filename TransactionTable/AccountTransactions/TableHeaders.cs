namespace PortfolioPerformance_TableHelper.TransactionTable.AccountTransactions
{
    public class TableHeaders
    {
        private TableHeaders(string name) { Name = name; }

        public string Name { get; private set; }

        /// <summary>
        /// The transaction's date.
        /// </summary>
        public static TableHeaders Date => new TableHeaders("Date");

        /// <summary>
        /// The transaction's time, precise to the minute.
        /// </summary>
        public static TableHeaders Time => new TableHeaders("Time");

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        public static TableHeaders Type => new TableHeaders("Type");

        /// <summary>
        /// The WKN identifier of the security, e.g. USDT, ETH.
        /// </summary>
        public static TableHeaders WKN => new TableHeaders("WKN");

        /// <summary>
        /// The ISIN identifier of the security, e.g. USDT, ETH.
        /// </summary>
        public static TableHeaders ISIN => new TableHeaders("ISIN");

        /// <summary>
        /// The ticker symbol of the security, e.g. USDT, ETH.
        /// </summary>
        public static TableHeaders Symbol => new TableHeaders("Ticker Symbol");

        /// <summary>
        /// The human-readable name of the security, e.g. chia, bitcoin, ethereum.
        /// </summary>
        public static TableHeaders SecurityName => new TableHeaders("Security Name");

        /// <summary>
        /// The number of shares involved in the transaction.
        /// </summary>
        public static TableHeaders ShareAmount => new TableHeaders("Shares");

        /// <summary>
        /// The gross amount of the transaction in its original currency.
        /// </summary>
        public static TableHeaders CurrencyGrossAmount => new TableHeaders("Currency Gross Amount");

        /// <summary>
        /// The gross amount of the transaction.
        /// </summary>
        public static TableHeaders GrossAmount => new TableHeaders("Gross Amount");

        /// <summary>
        /// The currency in which the transaction is performed.
        /// </summary>
        public static TableHeaders TransactionCurrency => new TableHeaders("Transaction Currency");

        /// <summary>
        /// The transaction's value in the target account's currency.
        /// </summary>
        public static TableHeaders Value => new TableHeaders("Value");

        /// <summary>
        /// The exchange rate applicable for the transaction. Can be used to calculate share amount, share price, and total price.
        /// </summary>
        public static TableHeaders ExchangeRate => new TableHeaders("Exchange Rate");

        /// <summary>
        /// Fees associated with the transaction, e.g., trading fees.
        /// </summary>
        public static TableHeaders Fees => new TableHeaders("Fees");

        /// <summary>
        /// Taxes imposed by the government on the transaction.
        /// </summary>
        public static TableHeaders Taxes => new TableHeaders("Taxes");

        /// <summary>
        /// Note or comments related to the transaction.
        /// </summary>
        public static TableHeaders Note => new TableHeaders("Note");

        /// <summary>
        /// The securities account related to the transaction where securities are added or removed.
        /// </summary>
        public static TableHeaders SecuritiesAccount => new TableHeaders("Securities Account");

        /// <summary>
        /// The offset account related to the transaction.
        /// </summary>
        public static TableHeaders OffsetAccount => new TableHeaders("Offset Account");

        /// <summary>
        /// The cash account related to the transaction. It determines the currency in which the transaction value is calculated.
        /// </summary>
        public static TableHeaders CashAccount => new TableHeaders("Cash Account");


        public static TableHeaders[] ToArray()
        {
            return new TableHeaders[] { Date, Time,Type,WKN,ISIN,Symbol,SecurityName, ShareAmount,CurrencyGrossAmount,GrossAmount,
                TransactionCurrency,Value,ExchangeRate,Fees,Taxes,Note,SecuritiesAccount,OffsetAccount,CashAccount };
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
