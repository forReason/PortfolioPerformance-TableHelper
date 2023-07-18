namespace PortfolioPerformanceTableHelper.Objects
{
    /// <summary>
    /// this is an account holding CASH
    /// </summary>
    public struct DepositAccount
    {
        public DepositAccount(string name, string currency) 
        { 
            this.Name = name;
            this.Currency = currency;
        }
        public string Name { get; private set; }
        public string Currency { get; private set; }
    }
}
