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
        /// <summary>
        /// buing an asser
        /// </summary>
        public static TransactionTypes Buy { get { return new TransactionTypes("Buy"); } }
        /// <summary>
        /// Selling an asset
        /// </summary>
        public static TransactionTypes Sell { get { return new TransactionTypes("Sell"); } }
        /// <summary>
        /// Transferring an asset (from self)
        /// </summary>
        public static TransactionTypes TransferInbound { get { return new TransactionTypes("Transfer (Inbound)"); } }
        /// <summary>
        /// transferring an asset (to self)
        /// </summary>
        public static TransactionTypes TransferOutbound { get { return new TransactionTypes("Transfer (Outbound)"); } }
        /// <summary>
        /// receiving asset from third party
        /// </summary>
        public static TransactionTypes DeliveryInbound { get { return new TransactionTypes("Delivery (Inbound)"); } }
        /// <summary>
        /// giving asset to third party
        /// </summary>
        public static TransactionTypes DeliveryOutbound { get { return new TransactionTypes("Delivery (Outbound)"); } }
        public static TransactionTypes[] ToArray()
        {
            return new TransactionTypes[] { Buy, Sell,TransferInbound,TransferOutbound, DeliveryInbound, DeliveryOutbound };
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
