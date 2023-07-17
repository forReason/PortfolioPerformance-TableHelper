namespace PortfolioPerformanceTableHelper.Objects
{
    /// <summary>
    /// Represents a security within a financial portfolio.
    /// </summary>
    public class Security
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Security"/> class.
        /// </summary>
        /// <param name="name">The name of the security.</param>
        /// <param name="referenceCurrency">The reference currency for the security. Defaults to "USD".</param>
        public Security(string name, string referenceCurrency = "USD")
        {
            this.Name = name;
            this.ReferenceCurrency = referenceCurrency;
        }

        /// <summary>
        /// Gets or sets the name of the security.
        /// </summary>
        /// <remarks>
        /// For example, the name of the security might be "Tesla Inc."
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the reference currency of the security.
        /// </summary>
        /// <remarks>
        /// For example, the reference currency might be "USD".
        /// </remarks>
        public string ReferenceCurrency { get; set; }

        /// <summary>
        /// Gets or sets the International Securities Identification Number (ISIN) of the security.
        /// </summary>
        /// <remarks>
        /// For example, the ISIN for Tesla Inc. is "US88160R1014".
        /// </remarks>
        public string? ISIN { get; set; }

        /// <summary>
        /// Gets or sets the Wertpapierkennnummer (WKN) of the security.
        /// </summary>
        /// <remarks>
        /// For example, the WKN for Tesla Inc. is "A1CX3T".
        /// </remarks>
        public string? WKN { get; set; }

        /// <summary>
        /// Gets or sets the ticker symbol of the security.
        /// </summary>
        /// <remarks>
        /// For example, the ticker symbol for Tesla Inc. is "TSLA".
        /// </remarks>
        public string? TickerSymbol { get; set; }
    }

}
