using PortfolioPerformanceTableHelper.Objects;
using PortfolioPerformanceTableHelper.Objects;
using QuickCsv.Net.Table_NS;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace PortfolioPerformanceTableHelper
{
    public partial class PortfolioTransactionsTable
    {
        /// <summary>
        /// tries to receive the spot price most close by from the stored table
        /// </summary>
        /// <remarks>as of right now, only checks the closest Month</remarks>
        /// <param name="spotDate">The requested DateTime of the SpotPrice.</param>
        /// <param name="baseCurrency">The date of the transfer.</param>

        public decimal? FetchClosestSpotPrice(DateTime spotDate, Security baseCurrency)
        {
            Table table = GetTable(spotDate);
            // try to fetch index
            int? startIndex = FetchIndexForRecordInsert(spotDate);
            if (startIndex == null)
            {
                startIndex = table.Length-1;
            }
            // try to find closest spot to determined index
            int checkLength = Math.Max(table.Length - startIndex.Value, table.Length - (table.Length - startIndex.Value));
            for (int i = 0; i < checkLength; i++)
            {
                // check above
                int rightIndex = startIndex.Value + i;
                if (rightIndex < table.Length)
                {
                    string securityString = table.GetCell(rightIndex, PortfolioTableHeaders.SecurityName.ToString());
                    if (baseCurrency.Name.Equals(securityString))
                    {
                        decimal value = decimal.Parse(table.GetCell(rightIndex, PortfolioTableHeaders.Value.ToString()));
                        decimal shares = decimal.Parse(table.GetCell(rightIndex, PortfolioTableHeaders.ShareAmount.ToString()));
                        return value/shares;
                    }
                }
                // check below
                int leftIndex = startIndex.Value - i;
                if (leftIndex >= 0)
                {
                    string securityString = table.GetCell(leftIndex, PortfolioTableHeaders.SecurityName.ToString());
                    if (baseCurrency.Name.Equals(securityString))
                    {
                        decimal value = decimal.Parse(table.GetCell(leftIndex, PortfolioTableHeaders.Value.ToString()));
                        decimal shares = decimal.Parse(table.GetCell(leftIndex, PortfolioTableHeaders.ShareAmount.ToString()));
                        return value / shares;
                    }
                }
            }
            return null;
        }
    }
}
