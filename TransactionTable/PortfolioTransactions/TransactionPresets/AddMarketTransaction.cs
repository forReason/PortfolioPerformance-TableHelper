﻿using PortfolioPerformanceTableHelper.Objects;
using QuickCsv.Net.Table_NS;

namespace PortfolioPerformanceTableHelper
{
    public partial class PortfolioTransactionsTable
    {
        /// <summary>
        /// Adds a transaction to the Portfolio Transactions table.<br/><br/>
        /// NOTE: The security must be denoted in the same currency than the Account! 
        /// If the currencies differ, you need to do currencyConversion separately!
        /// </summary>
        /// <param name="dateTime">The date and time when the buy transaction occurred.</param>
        /// <param name="security">The security that was bought.</param>
        /// <param name="cashAccount">The cash account from which the payment for the purchase was made.</param>
        /// <param name="securitiesAccount">The securities account to which the bought shares were credited.</param>
        /// <param name="transactionValue">The total amount credited or debited from the cash account for the transaction.</param>
        /// <param name="shares">The number of shares.</param>
        /// <param name="fees">Any fees associated with the transaction. Defaults to 0.</param>
        /// <param name="tax">Any tax paid as part of the transaction. Defaults to 0.</param>
        /// <param name="note">An optional note associated with the transaction.</param>
        /// <remarks>
        /// The <c>AddMarketTransaction</c> method records the purchase of securities in the Portfolio Transactions table. 
        /// The <c>transactionValue</c> parameter represents the total amount added or deducted to the Bank account including any fees and taxes. 
        /// The share price is calculated automatically from the <c>transactionValue</c>, <c>tax</c> and <c>fees</c> parameters.
        /// As such, users should ensure they correctly calculate the <c>transactionValue</c> amount before calling this method.
        /// </remarks>
        public void AddMarketTransaction(DateTime dateTime, OrderType type, Security security, DepositAccount cashAccount, SecuritiesAccount securitiesAccount,
            double transactionValue, double shares, double fees = 0, double tax = 0,
            string? note = null)
        {
            AddMarketTransaction(dateTime, type, security, cashAccount, securitiesAccount,
            transactionValue, shares, fees, tax,
            note);
        }
        /// <summary>
        /// Adds a transaction to the Portfolio Transactions table.<br/><br/>
        /// NOTE: The security must be denoted in the same currency than the Account! 
        /// If the currencies differ, you need to do currencyConversion separately!
        /// </summary>
        /// <param name="dateTime">The date and time when the buy transaction occurred.</param>
        /// <param name="security">The security that was bought.</param>
        /// <param name="cashAccount">The cash account from which the payment for the purchase was made.</param>
        /// <param name="securitiesAccount">The securities account to which the bought shares were credited.</param>
        /// <param name="transactionValue">The total amount credited or debited from the cash account for the transaction.</param>
        /// <param name="shares">The number of shares.</param>
        /// <param name="fees">Any fees associated with the transaction. Defaults to 0.</param>
        /// <param name="tax">Any tax paid as part of the transaction. Defaults to 0.</param>
        /// <param name="note">An optional note associated with the transaction.</param>
        /// <remarks>
        /// The <c>AddMarketTransaction</c> method records the purchase of securities in the Portfolio Transactions table. 
        /// The <c>transactionValue</c> parameter represents the total amount added or deducted to the Bank account including any fees and taxes. 
        /// The share price is calculated automatically from the <c>transactionValue</c>, <c>tax</c> and <c>fees</c> parameters.
        /// As such, users should ensure they correctly calculate the <c>transactionValue</c> amount before calling this method.
        /// </remarks>
        public void AddMarketTransaction(DateTime dateTime, OrderType type, Security security, DepositAccount cashAccount, SecuritiesAccount securitiesAccount,
        decimal transactionValue, decimal shares, decimal fees = 0, decimal tax = 0,
        string? note = null)
        {
            Table table = GetTable(dateTime);
            // insert record at specified position
            int? index = null;
            if (this._KeepTableTimeSorted)
            {
                index = FetchIndexForRecordInsert(dateTime);
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
            // set transaction type
            if (type == OrderType.Buy)
            {
                table.SetCell(PortfolioTableHeaders.Type.Name, newRecordIndex, PortfolioTransactionTypes.Buy.Name);
            }
            else
            {
                table.SetCell(PortfolioTableHeaders.Type.Name, newRecordIndex, PortfolioTransactionTypes.Sell.Name);
            }
            // set time
            SplitDateTime time = DateTimeHelper.Split(dateTime);
            table.SetCell(PortfolioTableHeaders.Date.Name, newRecordIndex, time.Date);
            table.SetCell(PortfolioTableHeaders.Time.Name, newRecordIndex, time.Time);
            // set involved accounts
            table.SetCell(PortfolioTableHeaders.CashAccount.Name, newRecordIndex, cashAccount.Name);
            table.SetCell(PortfolioTableHeaders.SecuritiesAccount.Name, newRecordIndex, securitiesAccount.Name);
            // set the security
            if (security != null)
            {
                if (security.ISIN != null)
                {
                    table.SetCell(PortfolioTableHeaders.ISIN.Name, newRecordIndex, security.ISIN);
                }
                if (security.WKN != null)
                {
                    table.SetCell(PortfolioTableHeaders.WKN.Name, newRecordIndex, security.WKN);
                }
                if (security.TickerSymbol != null)
                {
                    table.SetCell(PortfolioTableHeaders.Symbol.Name, newRecordIndex, security.TickerSymbol);
                }
                if (security.Name != null)
                {
                    table.SetCell(PortfolioTableHeaders.SecurityName.Name, newRecordIndex, security.Name);
                }
                table.SetCell(PortfolioTableHeaders.TransactionCurrency.Name, newRecordIndex, security.ReferenceCurrency);
            }
            // set amounts
            table.SetCell(PortfolioTableHeaders.ShareAmount.Name, newRecordIndex, shares.ToString("G"));
            table.SetCell(PortfolioTableHeaders.Value.Name, newRecordIndex, transactionValue.ToString());
            table.SetCell(PortfolioTableHeaders.Fees.Name, newRecordIndex, fees.ToString("G"));
            table.SetCell(PortfolioTableHeaders.Taxes.Name, newRecordIndex, tax.ToString("G"));
            // set note
            if (!string.IsNullOrEmpty(note))
            {
                table.SetCell(PortfolioTableHeaders.Note.Name, newRecordIndex, note);
            }
        }
    }
}
