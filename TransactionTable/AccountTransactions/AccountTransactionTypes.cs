namespace PortfolioPerformanceTableHelper
{ 
    /// <summary>
    /// This class encapsulates the different types of transactions that can occur in the AccountTransactions table. 
    /// It Acts like a string enum
    /// </summary>
    public class AccountTransactionTypes
    {
        /// <summary>
        /// The constructor is private, this means instances of AccountTransactionTypes can only be created inside this class.
        /// This way, we ensure that only the predefined types are available.
        /// </summary>
        /// <param name="name">The string representation of the transaction type.</param>
        private AccountTransactionTypes(string name) { Name = name; }

        /// <summary>
        /// Gets the string representation of the transaction type.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Used when funds are added to a portfolio. This is often the initial cash used to purchase assets.
        /// </summary>
        public static AccountTransactionTypes Deposit => new AccountTransactionTypes("Deposit");

        /// <summary>
        /// Used when funds are removed from a portfolio, typically for personal use or to transfer to another investment.
        /// </summary>
        public static AccountTransactionTypes Withdraw => new AccountTransactionTypes("Removal");

        /// <summary>
        /// Used when funds are transferred into the portfolio from another of the user's accounts.
        /// </summary>
        public static AccountTransactionTypes TransferInbound => new AccountTransactionTypes("Transfer (Inbound)");

        /// <summary>
        /// Used when funds are transferred out of the portfolio into another of the user's accounts.
        /// </summary>
        public static AccountTransactionTypes TransferOutbound => new AccountTransactionTypes("Transfer (Outbound)");

        /// <summary>
        /// Used when the portfolio receives a dividend payment from an asset, such as shares in a company.
        /// </summary>
        public static AccountTransactionTypes Dividend => new AccountTransactionTypes("Dividend");

        /// <summary>
        /// Used when there are fees associated with a transaction, or fees due for maintaining the account or other services.
        /// </summary>
        public static AccountTransactionTypes Fees => new AccountTransactionTypes("Fees");

        /// <summary>
        /// Used when there is a refund of previously paid fees. This may be due to an error, a promotional offer, or other reasons.
        /// </summary>
        public static AccountTransactionTypes FeesRefund => new AccountTransactionTypes("Fees Refund");

        /// <summary>
        /// Used when taxes are deducted from the portfolio and paid to the government.
        /// </summary>
        public static AccountTransactionTypes Tax => new AccountTransactionTypes("Taxes");

        /// <summary>
        /// Used when a previously paid tax is refunded back into the portfolio.
        /// </summary>
        public static AccountTransactionTypes TaxRefund => new AccountTransactionTypes("Tax Refund");

        /// <summary>
        /// Used when the portfolio generates interest, typically from a cash holding or a loan.
        /// </summary>
        public static AccountTransactionTypes Interest => new AccountTransactionTypes("Interest");

        /// <summary>
        /// Used when interest is charged to the portfolio, such as on a loan or an overdraft.
        /// </summary>
        public static AccountTransactionTypes InterestCharge => new AccountTransactionTypes("Interest Charge");

        /// <summary>
        /// returns all available Transaction Types
        /// </summary>
        /// <returns></returns>
        public static AccountTransactionTypes[] ToArray()
        {
            return new AccountTransactionTypes[] { /*Buy, Sell,*/ Deposit, Withdraw, TransferInbound, TransferOutbound, Dividend, Fees, FeesRefund, Tax, TaxRefund, Interest, InterestCharge };
        }
        /// <summary>
        /// converts the selected transaction type to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
