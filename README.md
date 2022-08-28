# PortfolioPerformance-TableHelper
This library should help creating csv entries for portfolio performance.
Note that this library is very young and still quite limited. But feel free to contribute!

# usage example
```
PortfolioPerformance_TableHelper.TransactionTable.AccountTransactions.Table mining_dividend_table = new PortfolioPerformance_TableHelper.TransactionTable.AccountTransactions.Table();
PortfolioPerformance_TableHelper.TransactionTable.PortfolioTransactions.Table transactions_table = new PortfolioPerformance_TableHelper.TransactionTable.PortfolioTransactions.Table();
// add dividend for each individual mining device
IncomeOverview incomeOverview = (IncomeOverview)IncomePreviewStackPanel.Children[0];
foreach (IncomeOverview_Row position in incomeOverview.MainPanel.Children)
{
    mining_dividend_table.AddDividend(DateTime: (DateTime)this.IncomeDate_DatePicker.SelectedDate,
    SecurityName: position.DeviceName_Label.Content.ToString(),
    Symbol: position.DeviceSymbol,
    CashAccount: "Crypto_Mining_Wallet_Account",
    SecuritiesAccount: "Crypto_Mining_Wallet_Collection",
    GrossValue: double.Parse(TotalIncome_Label.Content.ToString()),
    Note: "mining income"
    );
}
// buy currency from income dividends for calculation purposes
transactions_table.AddBuyTransaction(DateTime: ((DateTime)this.IncomeDate_DatePicker.SelectedDate).AddMinutes(1),
    Symbol: this.CurrencyName_Combobox.SelectedItem.ToString()+"-USD",
    SecurityName: "",
    CashAccount: "Crypto_Mining_Wallet_Account",
    SecuritiesAccount: "Crypto_Mining_Wallet_Collection",
    Shares: CurrencyIncome,
    GrossValue: TotalIncome,
    Note: "Mining income verrechnung"
    );
// save table
{ }
transactions_table.Save($"{((DateTime)this.IncomeDate_DatePicker.SelectedDate).ToString("yyyyMMdd")}-MiningIncomeVerrechnung_PortfolioTransactions.csv");
mining_dividend_table.Save($"{((DateTime)this.IncomeDate_DatePicker.SelectedDate).ToString("yyyyMMdd")}-MiningIncome_AccountTransactions.csv");

```
