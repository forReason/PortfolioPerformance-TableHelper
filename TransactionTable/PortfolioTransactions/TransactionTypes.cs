using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioPerformance_TableHelper.TransactionTable.PortfolioTransactions
{
    public class TransactionTypes
    {
        private TransactionTypes(string name) { Name = name; }

        public string Name { get; private set; }

        //public static TransactionTypes Buy { get { return new TransactionTypes("Buy"); } }
        //public static TransactionTypes Sell { get { return new TransactionTypes("Sell"); } }
        public static TransactionTypes Deposit { get { return new TransactionTypes("Deposit"); } }
        public static TransactionTypes Withdraw { get { return new TransactionTypes("Removal"); } }
        public static TransactionTypes TransferInbound { get { return new TransactionTypes("Transfer (Inbound)"); } }
        public static TransactionTypes TransferOutbound { get { return new TransactionTypes("Transfer (Outbound)"); } }
        public static TransactionTypes Dividend { get { return new TransactionTypes("Dividend"); } }
        public static TransactionTypes Fees { get { return new TransactionTypes("Fees"); } }
        public static TransactionTypes FeesRefund { get { return new TransactionTypes("Fees Refund"); } }
        public static TransactionTypes Tax { get { return new TransactionTypes("Taxes"); } }
        public static TransactionTypes TaxRefund { get { return new TransactionTypes("Tax Refund"); } }
        public static TransactionTypes Interest { get { return new TransactionTypes("Interest"); } }
        public static TransactionTypes InterestCharge { get { return new TransactionTypes("Interest Charge"); } }
        public static TransactionTypes[] ToArray()
        {
            return new TransactionTypes[] { /*Buy, Sell,*/ Deposit,Withdraw,TransferInbound,TransferOutbound,Dividend,Fees,FeesRefund,Tax,TaxRefund,Interest,InterestCharge };
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
