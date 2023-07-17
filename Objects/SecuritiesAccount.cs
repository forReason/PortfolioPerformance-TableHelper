namespace PortfolioPerformance_TableHelper.Objects
{
    public struct SecuritiesAccount
    {
        public SecuritiesAccount(string name, DepositAccount referenceAccount)
        {
            Name = name;
            ReferenceAccount = referenceAccount;
        }
        public string Name { get; private set; }
        public DepositAccount ReferenceAccount { get; private set; }
    }
}
