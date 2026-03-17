using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
   
    class Order
    {
        public int OrderId;
        public double OrderAmount;

        public Order(int id, double amount)
        {
            OrderId = id;
            OrderAmount = amount;
        }

        public virtual void CalculateShippingCost()
        {
            Console.WriteLine("Shipping Cost: 50");
        }
    }

    class StandardOrder : Order
    {
        public StandardOrder(int id, double amount) : base(id, amount) { }

        public override void CalculateShippingCost()
        {
            Console.WriteLine("Standard Order Shipping Cost: 50");
        }
    }

    class ExpressOrder : Order
    {
        public ExpressOrder(int id, double amount) : base(id, amount) { }

        public override void CalculateShippingCost()
        {
            Console.WriteLine("Express Order Shipping Cost: 100");
        }
    }

    class InternationalOrder : Order
    {
        public InternationalOrder(int id, double amount) : base(id, amount) { }

        public override void CalculateShippingCost()
        {
            Console.WriteLine("International Order Shipping Cost: 500");
        }
    }

}
