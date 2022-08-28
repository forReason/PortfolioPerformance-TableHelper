using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPerformance_TableHelper.TransactionTable.AccountTransactions
{
    public class TableHeaders
    {
        private TableHeaders(string name) { Name = name; }

        public string Name { get; private set; }
        /// <summary>
        /// The date of the transaction
        /// </summary>
        public static TableHeaders Date { get { return new TableHeaders("Date"); } }
        /// <summary>
        /// The time of the transaction (note: only precise to the minute)
        /// </summary>
        public static TableHeaders Time { get { return new TableHeaders("Time"); } }
        /// <summary>
        /// The transaction type
        /// </summary>
        public static TableHeaders Type { get { return new TableHeaders("Type"); } }
        /// <summary>
        /// the wkn identifier of the security. EG USDT, ETH, etc
        /// </summary>
        public static TableHeaders WKN { get { return new TableHeaders("WKN"); } }
        public static TableHeaders ISIN { get { return new TableHeaders("ISIN"); } }
        public static TableHeaders Symbol { get { return new TableHeaders("Ticker Symbol"); } }
        public static TableHeaders SecurityName { get { return new TableHeaders("Security Name"); } }
        /// <summary>
        /// amount of transaction shares
        /// </summary>
        public static TableHeaders ShareAmount { get { return new TableHeaders("Shares"); } }
        public static TableHeaders CurrencyGrossAmount { get { return new TableHeaders("Currency Gross Amount"); } }
        public static TableHeaders GrossAmount { get { return new TableHeaders("Gross Amount"); } }
        public static TableHeaders TransactionCurrency { get { return new TableHeaders("Transaction Currency"); } }

        /// <summary>
        /// The Currencyvalue of the Transaction (currency is determined by the target account)
        /// </summary>
        public static TableHeaders Value { get { return new TableHeaders("Value"); } }
        /// <summary>
        /// The rate of exchange of the currency. may be used to triangulate between share amount, share price and total price
        /// </summary>
        public static TableHeaders ExchangeRate { get { return new TableHeaders("Exchange Rate"); } }
        /// <summary>
        /// Trading or other fees associated with this transaction
        /// </summary>
        public static TableHeaders Fees { get { return new TableHeaders("Fees"); } }
        /// <summary>
        /// Governement Taxes which apply to this transaction
        /// </summary>
        public static TableHeaders Taxes { get { return new TableHeaders("Taxes"); } }
        /// <summary>
        /// Note for the transaction
        /// </summary>
        public static TableHeaders Note { get { return new TableHeaders("Note"); } }
        /// <summary>
        /// the associated securities account (to add/remove securities from)
        /// </summary>
        public static TableHeaders SecuritiesAccount { get { return new TableHeaders("Securities Account"); } }
        public static TableHeaders OffsetAccount { get { return new TableHeaders("Offset Account"); } }
        /// <summary>
        /// The associated cash account which also determines the currency in which the value is calculated
        /// </summary>
        public static TableHeaders CashAccount { get { return new TableHeaders("Cash Account"); } }

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
