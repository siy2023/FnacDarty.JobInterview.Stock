using System;
using System.Collections.Generic;

namespace FnacDarty.JobInterview.Stock
{
    public class Order : BaseEntity
    {
        public Order()
        {

        }

        public Order(IReadOnlyList<OrderDetail> orderDetails, string userName, decimal orderTotal,
            decimal orderDiscount, decimal netTotal, decimal amountPaid, decimal balance)
        {
            OrderDetails = orderDetails;
            Username = userName;
            OrderTotal = orderTotal;
            OrderDiscount = orderDiscount;
            NetTotal = netTotal;
            AmountPaid = amountPaid;
            Balance = balance;
        }

        public DateTime OrderDate { get; set; }
        public IReadOnlyList<OrderDetail> OrderDetails { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal OrderDiscount { get; set; } = 0;
        public decimal NetTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
        public string Username { get; set; }

        public decimal GetTotal()
        {
            return NetTotal - OrderDiscount;
        }

        public decimal GetBalance()
        {
            return AmountPaid - (NetTotal - OrderDiscount);
        }
    }
}
