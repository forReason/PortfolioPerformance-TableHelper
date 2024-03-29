﻿using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.TransactionTable.TransactionsPreset;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable : TransactionsTable
    {
        /// <summary>
        /// Adds a transfer transaction to the Account Transactions table.
        /// </summary>
        /// <param name="transferDate">The date of the transfer transaction.</param>
        /// <param name="sourceAccount">The account where the transaction is sent from.</param>
        /// <param name="targetAccount">The account where the transaction is sent to.</param>
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
        /// <param name="transferDate">The date of the transfer transaction.</param>
        /// <param name="sourceAccount">The account where the transaction is sent from.</param>
        /// <param name="targetAccount">The account where the transaction is sent to.</param>
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
            Table table = GetTable(transferDate);
            // insert record at specified position
            int? index = null;
            if (this._KeepTableTimeSorted)
            {
                index = FetchIndexForRecordInsert(transferDate);
            }
            int newRecordIndex;
            if (index == null)
            {
                newRecordIndex = table.AppendEmptyRecord();
            }
            else
            {
                newRecordIndex = index.Value;
                table.InsertEmptyRecord(newRecordIndex);
            }
            // set Transaction Type
            table.SetCell(AccountTableHeaders.Type.Name, newRecordIndex, AccountTransactionTypes.TransferOutbound.Name);
            // select account, currency is defined by account
            table.SetCell(AccountTableHeaders.CashAccount.Name, newRecordIndex, sourceAccount.Name);
            table.SetCell(AccountTableHeaders.OffsetAccount.Name, newRecordIndex, targetAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(transferDate);
            table.SetCell(AccountTableHeaders.Date.Name, newRecordIndex, time.Date);
            table.SetCell(AccountTableHeaders.Time.Name, newRecordIndex, time.Time);
            // set the amount
            table.SetCell(AccountTableHeaders.Value.Name, newRecordIndex, (-amount).ToString("G"));

            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(AccountTableHeaders.Note.Name, newRecordIndex, note);
            }
        }
    }
}
