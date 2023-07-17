namespace PortfolioPerformanceTableHelper
{
    /// <summary>
    /// This class encapsulates the different types of transactions that can occur in the PortfolioTransactions table. 
    /// It Acts like a string enum
    /// </summary>
    public class PortfolioTransactionTypes
    {
        /// <summary>
        /// The constructor is private, which means instances of PortfolioTransactionTypes can only be created inside this class.
        /// This ensures that only the predefined types are available for use.
        /// </summary>
        /// <param name="name">The string representation of the transaction type.</param>
        private PortfolioTransactionTypes(string name) { Name = name; }

        /// <summary>
        /// Gets the string representation of the transaction type. This can be used when exporting or displaying transactions.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Used when an asset is purchased. The data associated with such a transaction would typically include the cost, number of units, date, etc.
        /// </summary>
        public static PortfolioTransactionTypes Buy => new PortfolioTransactionTypes("Buy");

        /// <summary>
        /// Used when an asset is sold. The data associated with such a transaction would typically include the proceeds from the sale, number of units, date, etc.
        /// </summary>
        public static PortfolioTransactionTypes Sell => new PortfolioTransactionTypes("Sell");

        /// <summary>
        /// Used when an asset is transferred into the portfolio from another of the user's accounts. This does not affect the cash balance.
        /// </summary>
        public static PortfolioTransactionTypes TransferInbound => new PortfolioTransactionTypes("Transfer (Inbound)");

        /// <summary>
        /// Used when an asset is transferred out of the portfolio into another of the user's accounts. This also does not affect the cash balance.
        /// </summary>
        public static PortfolioTransactionTypes TransferOutbound => new PortfolioTransactionTypes("Transfer (Outbound)");

        /// <summary>
        /// Used when an asset is received into the portfolio from a third party. This would typically be recorded at the market value of the asset at the time of receipt.
        /// </summary>
        public static PortfolioTransactionTypes DeliveryInbound => new PortfolioTransactionTypes("Delivery (Inbound)");

        /// <summary>
        /// Used when an asset is transferred out of the portfolio to a third party. This would typically be recorded at the market value of the asset at the time of delivery.
        /// </summary>
        public static PortfolioTransactionTypes DeliveryOutbound => new PortfolioTransactionTypes("Delivery (Outbound)");

        /// <summary>
        /// returns all available Transaction Types
        /// </summary>
        /// <returns></returns>
        public static PortfolioTransactionTypes[] ToArray()
        {
            return new PortfolioTransactionTypes[] { Buy, Sell,TransferInbound,TransferOutbound, DeliveryInbound, DeliveryOutbound };
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
