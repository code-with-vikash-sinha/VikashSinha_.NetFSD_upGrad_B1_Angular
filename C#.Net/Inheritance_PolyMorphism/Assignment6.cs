using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Furniture
    {
        public int OrderId;
        public string OrderDate;
        public string FurnitureType;
        public int Qty;
        public double TotalAmt;
        public string PaymentMode;

        public virtual void GetData()
        {
            Console.WriteLine("Enter Order Id:");
            OrderId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Order Date:");
            OrderDate = Console.ReadLine();

            Console.WriteLine("Enter Quantity:");
            Qty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Payment Mode (Credit/Debit):");
            PaymentMode = Console.ReadLine();
        }

        public virtual void ShowData()
        {
            Console.WriteLine("Order Id: " + OrderId);
            Console.WriteLine("Order Date: " + OrderDate);
            Console.WriteLine("Quantity: " + Qty);
            Console.WriteLine("Payment Mode: " + PaymentMode);
            Console.WriteLine("Total Amount: " + TotalAmt);
        }
    }

    class Chair : Furniture
    {
        public string ChairType;
        public string Purpose;
        public string MaterialDetail;
        public double Rate;

        public override void GetData()
        {
            base.GetData();

            FurnitureType = "Chair";

            Console.WriteLine("Enter Chair Type (Wood/Steel/Plastic):");
            ChairType = Console.ReadLine();

            Console.WriteLine("Enter Purpose (Home/Office):");
            Purpose = Console.ReadLine();

            if (ChairType == "Wood")
            {
                Console.WriteLine("Enter Wood Type (Teak Wood/Rose Wood):");
                MaterialDetail = Console.ReadLine();
            }
            else if (ChairType == "Steel")
            {
                Console.WriteLine("Enter Steel Type (Gray/Green/Brown Steel):");
                MaterialDetail = Console.ReadLine();
            }
            else if (ChairType == "Plastic")
            {
                Console.WriteLine("Enter Plastic Color (Green/Red/Blue/White):");
                MaterialDetail = Console.ReadLine();
            }

            Console.WriteLine("Enter Rate:");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            base.ShowData();

            Console.WriteLine("Furniture Type: " + FurnitureType);
            Console.WriteLine("Chair Type: " + ChairType);
            Console.WriteLine("Purpose: " + Purpose);
            Console.WriteLine("Material Detail: " + MaterialDetail);
            Console.WriteLine("Rate: " + Rate);
        }
    }

    class Cot : Furniture
    {
        public string CotType;
        public string Capacity;
        public double Rate;

        public override void GetData()
        {
            base.GetData();

            FurnitureType = "Cot";

            Console.WriteLine("Enter Cot Type (Wood/Steel):");
            CotType = Console.ReadLine();

            Console.WriteLine("Enter Capacity (Single/Double):");
            Capacity = Console.ReadLine();

            Console.WriteLine("Enter Rate:");
            Rate = double.Parse(Console.ReadLine());

            TotalAmt = Qty * Rate;
        }

        public override void ShowData()
        {
            base.ShowData();

            Console.WriteLine("Furniture Type: " + FurnitureType);
            Console.WriteLine("Cot Type: " + CotType);
            Console.WriteLine("Capacity: " + Capacity);
            Console.WriteLine("Rate: " + Rate);
        }
    }
}
