﻿using PortfolioPerformance_TableHelper.Objects;

namespace PortfolioPerformanceTableHelper
{
    public partial class AccountTransactionsTable
    {
        /// <summary>
        /// <b>WARNING:</b> As of writing of this code, there is a bug which discads tax values in interest payments:<br/>
        /// <see href="https://github.com/buchen/portfolio/issues/3449"/> you might want to split it into one interest and one Tax.<br/><br/>
        /// Adds an interest transaction to the <c>AccountTransactionsTable</c>.<br/>
        /// typically related to interest received from holding cash or cash equivalents.
        /// </summary>
        /// <param name="cashAccount">The name of the cash account to which the interest is credited.</param>
        /// <param name="depositDate">The date of the interest transaction.</param>
        /// <param name="grossAmount">The gross amount of the interest transaction before tax deductions.</param>
        /// <param name="taxes">The amount of taxes on the interest transaction. It should not be larger than the gross amount. Defaults to null.</param>
        /// <param name="note">Any additional notes associated with the interest transaction. Defaults to null.</param>
        /// <remarks>
        /// The final amount credited to the cash account will be the gross amount minus the taxes (i.e., grossAmount - taxes).
        /// This method will throw an ArgumentOutOfRangeException if the tax amount is greater than the gross amount of interest.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax amount is greater than the gross amount of interest.</exception>   
        public void AddInterestCharge(DepositAccount cashAccount, DateTime depositDate, double grossAmount, string? note = null)
        {
            AddInterestCharge(cashAccount, depositDate, (decimal)grossAmount, note);
        }
        /// <summary>
        /// <b>WARNING:</b> As of writing of this code, there is a bug which discads tax values in interest payments:<br/>
        /// <see href="https://github.com/buchen/portfolio/issues/3449"/> you might want to split it into one interest and one Tax.<br/><br/>
        /// Adds an interest transaction to the <c>AccountTransactionsTable</c>.<br/>
        /// typically related to interest received from holding cash or cash equivalents.
        /// </summary>
        /// <param name="cashAccount">The name of the cash account to which the interest is credited.</param>
        /// <param name="depositDate">The date of the interest transaction.</param>
        /// <param name="amount">The gross amount of the interest transaction before tax deductions.</param>
        /// <param name="taxes">The amount of taxes on the interest transaction. It should not be larger than the gross amount. Defaults to null.</param>
        /// <param name="note">Any additional notes associated with the interest transaction. Defaults to null.</param>
        /// <remarks>
        /// The final amount credited to the cash account will be the gross amount minus the taxes (i.e., grossAmount - taxes).
        /// This method will throw an ArgumentOutOfRangeException if the tax amount is greater than the gross amount of interest.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the tax amount is greater than the gross amount of interest.</exception>   
        public void AddInterestCharge(DepositAccount cashAccount, DateTime depositDate, decimal amount, string? note = null)
        {
            int index = Table.AppendEmptyRecord();
            // set transaction type
            Table.SetCell(AccountTableHeaders.Type.Name, index, AccountTransactionTypes.InterestCharge.Name);
            // select account, currency is defined by account
            Table.SetCell(AccountTableHeaders.CashAccount.Name, index, cashAccount.Name);
            // set the time
            SplitDateTime time = DateTimeHelper.Split(depositDate);
            Table.SetCell(AccountTableHeaders.Date.Name, index, time.Date);
            Table.SetCell(AccountTableHeaders.Time.Name, index, time.Time);
            // set the amount
            Table.SetCell(AccountTableHeaders.Value.Name, index, ((decimal)amount).ToString("G"));
            // set the notes
            if (!string.IsNullOrEmpty(note))
            {
                Table.SetCell(AccountTableHeaders.Note.Name, index, note);
            }
        }
    }
}
