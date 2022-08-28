using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPerformance_TableHelper.TransactionTable.AccountTransactions
{
    public partial class Table
    {
        public Table()
        {
            MyTable = new CSV_Helper_Project.Table();
            MyTable.SetColumnNames(TableHeaders.ToStringArray());
        }
        public CSV_Helper_Project.Table MyTable { get; set; }
        public void Save(string FileName)
        {
            MyTable.WriteTableToFile(FileName);
        }
    }
}
