# PortfolioPerformance-TableHelper

PortfolioPerformance-TableHelper is a helper library for creating CSV entries compatible with Portfolio Performance (https://github.com/buchen/portfolio), an open-source tool for calculating the performance of your stocks and bonds. This library simplifies the generation of CSV files for account and portfolio transactions.

Contributions are welcomed! Feel free to submit pull requests or open issues.

## Features

- Generate account and portfolio transactions in a format readily consumable by Portfolio Performance.
- Reference support for multiple securities and accounts.
- Support for different types of transactions like deposit, interest, fee, tax, dividend, transfer, and withdrawal for account transactions.
- Support for different types of transactions like market transactions and transfers for portfolio transactions.

## Usage Example

The library provides methods to create account and portfolio transactions. 
Please note that the Library splits columns with a `;` so make sure to choose that as delimiting character in PortfolioPerformance. 

Here are some examples:

### Account Transactions

To generate account transactions, you first create an instance of `AccountTransactionsTable` and then use the methods provided by this instance to add various transactions. After you're done adding transactions, call the `Save` method to write these transactions to a CSV file.
``` C#
[Fact]
public void TestAccountTransactions()
{
    // generate tables
    AccountTransactionsTable accountTable = new AccountTransactionsTable();
    // Generate reference security
    Security tsla = new Security("Tesla, Inc.", "USD");
    tsla.ISIN = "US88160R1014";
    tsla.WKN = "A1CX3T";
    tsla.TickerSymbol = "TSLA";
    // generate reference deposit account
    DepositAccount cashAccount = new DepositAccount("references", "USD");
    DepositAccount transferAccount = new DepositAccount("transfer", "USD");
    // deposit
    accountTable.AddDeposit(DateTime.Parse("01/01/2020"), cashAccount, 125.50, "this is a testnote");
    // interest
    accountTable.AddInterest(DateTime.Parse("12/31/2020"), cashAccount, 10, 2.5, "this is some high interest yield");
    accountTable.AddInterestCharge(DateTime.Parse("01/01/2021"), cashAccount, 7.5, "this is some high interest");
    // fee
    accountTable.AddFee(DateTime.Parse("01/02/2021"), cashAccount, 2.5, tsla, "this is some fee");
    accountTable.AddFeeRefund(DateTime.Parse("01/03/2021"), cashAccount, 2.5, tsla, "this is some fee refund");
    // tax
    accountTable.AddTax(DateTime.Parse("01/04/2021"), cashAccount, 2.5, tsla, "this is some tax");
    accountTable.AddTaxRefund(DateTime.Parse("01/05/2021"), cashAccount,  2.5, tsla, "this is some tax refund");
    // Dividend
    accountTable.AddDividend(DateTime.Parse("01/06/2021"), cashAccount, tsla, 2m,25m,1m,2m,"test dividend");
    // Transfer
    accountTable.AddTransfer(DateTime.Parse("01/07/2021"), cashAccount, transferAccount, 25m, "test dividend");
    accountTable.AddTransfer(DateTime.Parse("01/07/2021"), transferAccount, cashAccount, 25m, "test dividend");
    // withdraw
    accountTable.AddWithdraw(DateTime.Now, cashAccount,  125.50, "this is a removal testnote");
    accountTable.Save();
}
```

### Portfolio Transactions
To generate portfolio transactions, you first create an instance of `PortfolioTransactionsTable` and then use the methods provided by this instance to add various transactions. After you're done adding transactions, call the `Save` method to write these transactions to a CSV file.
``` C#
[Fact]
public void TestSecurityTransactions()
{
    PortfolioTransactionsTable portfolioTable = new PortfolioTransactionsTable();
    // Generate reference security
    Security tsla = new Security("Tesla, Inc.", "USD");
    tsla.ISIN = "US88160R1014";
    tsla.WKN = "A1CX3T";
    tsla.TickerSymbol = "TSLA";
    // generate reference deposit account
    DepositAccount cashAccount = new DepositAccount("references", "EUR");
    SecuritiesAccount securitiesAccount = new SecuritiesAccount("securities", cashAccount);
    SecuritiesAccount securitiesTransferAccount = new SecuritiesAccount("TestTransfer", cashAccount);
    // do transaction
    portfolioTable.AddMarketTransaction(
        DateTime.Parse("01/04/2021"), OrderType.Buy, tsla, cashAccount, securitiesAccount,
        113m*3, shares: 3, 2, 3, 
        "this is a transaction with a target value of 50usd and 10 eur");
    // do transfer
    portfolioTable.AddTransfer(DateTime.Parse("01/05/2021"), securitiesAccount, securitiesTransferAccount,
        tsla, 3.0, 0);
    portfolioTable.Save();
}
```

## Contribution

To contribute to PortfolioPerformance-TableHelper, please make sure to follow these steps:

1. Fork the repository.
2. Create a new branch for your features / fixes.
3. Push your changes to this branch.
4. Submit a pull request detailing the changes made, why they were necessary, and how they work.

Please note that your code should adhere to a basic coding standard.
