using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OnlineShoppingWPF
{
    public enum DeliverStatus
    {
        NoOrder,
        Delayed,
        Lost,
        Delivered
    }
    public class TransportVehicle
    {
        public TransportVehicle()
        {
            Name = string.Empty;
            OrderNumber = 0;
        }
        public string Name { get; set; }
        public int OrderNumber { get; private set; }
        private static Random random = new Random();

        public bool LoadOrder(Order order)
        {
            if (OrderNumber == 0 && order.Status == OrderStatus.ReadyToSend)
            {
                if (order.SetStatus(OrderStatus.Delivering))
                {
                    OrderNumber = order.OrderNumber;
                    return true;
                }
            }
            return false;
        }

        public DeliverStatus TryDeliverOrder()
        {
            if (OrderNumber != 0)
            {
                if (random.NextDouble() < 0.15)
                {
                    OrderNumber = 0;
                    return DeliverStatus.Lost;
                }
                else if (random.NextDouble() < 0.3)
                {
                    return DeliverStatus.Delayed;
                }
                OrderNumber = 0;
                return DeliverStatus.Delivered;
            }
            return DeliverStatus.NoOrder;
        }

    }
}
