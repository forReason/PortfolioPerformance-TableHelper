using PortfolioPerformance_TableHelper.Objects;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable
    {
        /// <summary>
        /// Adds two corresponding transfer transactions to the Account Transactions table, representing a transfer of funds from a source account to a target account.
        /// </summary>
        /// <param name="sourceAccount">The account from which funds are transferred.</param>
        /// <param name="targetAccount">The account to which funds are transferred.</param>
        /// <param name="depositDate">The date of the transfer transaction.</param>
        /// <param name="sourceAmount">The amount being transferred in the source account's currency.</param>
        /// <param name="targetAmount">The conversion rate applied to the amount to represent the value in the target account's currency.</param>
        /// <param name="note">An optional note related to the transfer transaction.</param>
        /// <remarks>
        /// This method facilitates the recording of a transfer of funds between two accounts. This is represented by two transactions: 
        /// an outbound transfer from the source account and an inbound transfer to the target account. The method handles currency 
        /// conversion, if required, by multiplying the amount by the specified conversion rate to determine the value that is credited to the target account.
        /// </remarks>
        //public void AddTransfer(DateTime transferDate, DepositAccount sourceAccount, DepositAccount targetAccount, double sourceAmount, double targetAmount, string? note = null)
        //{
        //    AddTransfer(transferDate, TransferType.Outbound, sourceAccount,  sourceAmount, note);
        //    AddTransfer(transferDate, TransferType.Inbound, targetAccount, targetAmount, note);
        //}
        /// <summary>
        /// Adds two corresponding transfer transactions to the Account Transactions table, representing a transfer of funds from a source account to a target account.
        /// </summary>
        /// <param name="sourceAccount">The account from which funds are transferred.</param>
        /// <param name="targetAccount">The account to which funds are transferred.</param>
        /// <param name="depositDate">The date of the transfer transaction.</param>
        /// <param name="sourceAmount">The amount being transferred in the source account's currency.</param>
        /// <param name="targetAmount">The conversion rate applied to the amount to represent the value in the target account's currency.</param>
        /// <param name="note">An optional note related to the transfer transaction.</param>
        /// <remarks>
        /// This method facilitates the recording of a transfer of funds between two accounts. This is represented by two transactions: 
        /// an outbound transfer from the source account and an inbound transfer to the target account. The method handles currency 
        /// conversion, if required, by multiplying the amount by the specified conversion rate to determine the value that is credited to the target account.
        /// </remarks>
        //public void AddTransfer(DateTime transferDate, DepositAccount sourceAccount, DepositAccount targetAccount,  decimal sourceAmount, decimal targetAmount, string? note = null)
        //{
        //    AddTransfer(transferDate, TransferType.Outbound, sourceAccount,  sourceAmount, note);
        //    AddTransfer(transferDate, TransferType.Inbound, targetAccount,  targetAmount, note);
        //}
        /// <summary>
        /// Adds a transfer transaction to the Account Transactions table.
        /// </summary>
        /// <param name="type">The type of transfer, either inbound or outbound.</param>
        /// <param name="account">The account associated with the transfer transaction.</param>
        /// <param name="depositDate">The date of the transfer transaction.</param>
        /// <param name="amount">The amount of the transfer transaction.</param>
        /// <param name="note">An optional note related to the transfer transaction.</param>
        /// <remarks>
        /// Transfer transactions represent the movement of funds between accounts. While deposit and withdraw transactions 
        /// denote the addition or removal of funds from a single account, transfer transactions signify a transaction that 
        /// affects two accounts - the source and the destination. For instance, a 'Transfer Inbound' transaction denotes 
        /// funds coming into the account from an external source, and a 'Transfer Outbound' transaction indicates the 
        /// sending of funds from the account to an external destination.<br/>
        /// -> Both accounts should be tracked by PortfolioPerformance
        /// </remarks>
        public void AddTransfer(DateTime transferDate, DepositAccount sourceAccount, DepositAccount targetAccount,
            double amount, string? note = null)
        {
            AddTransfer(transferDate, sourceAccount, targetAccount,  (decimal) amount, note);
        }
        /// <summary>
        /// Adds a transfer transaction to the Account Transactions table.
        /// </summary>
        /// <param name="type">The type of transfer, either inbound or outbound.</param>
        /// <param name="account">The account associated with the transfer transaction.</param>
        /// <param name="depositDate">The date of the transfer transaction.</param>
        /// <param name="amount">The amount of the transfer transaction.</param>
        /// <param name="note">An optional note related to the transfer transaction.</param>
        /// <remarks>
        /// Transfer transactions represent the movement of funds between accounts. While deposit and withdraw transactions 
        /// denote the addition or removal of funds from a single account, transfer transactions signify a transaction that 
        /// affects two accounts - the source and the destination. For instance, a 'Transfer Inbound' transaction denotes 
        /// funds coming into the account from an external source, and a 'Transfer Outbound' transaction indicates the 
        /// sending of funds from the account to an external destination.<br/>
        /// -> Both accounts should be tracked by PortfolioPerformance
        /// </remarks>
        public void AddTransfer(DateTime transferDate, DepositAccount sourceAccount, DepositAccount targetAccount,
            decimal amount, string? note = null)
        {
            int index = Table.AppendEmptyRecord();
            // set Transaction Type
            Table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.TransferOutbound.Name);
            // select account, currency is defined by account
            Table.SetCell(AccountTableHeaders.CashAccount.Name, index, sourceAccount.Name);
            Table.SetCell(AccountTableHeaders.OffsetAccount.Name, index, targetAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(transferDate);
            Table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            Table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            Table.SetCell(AccountTableHeaders.Value.Name, index, (-amount).ToString("G"));

            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                Table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
