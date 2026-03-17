namespace Inheritance
{
    class Staff
    {
        public int StaffId;
        public string Name;
        public int BaseSalary;

        public Staff(int id, string name, int baseSalary)
        {
            StaffId = id;
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual int CalculateSalary()
        {
            return BaseSalary;
        }
    }
    class Doctor : Staff
    {
        public int ConsulationFee;
        public Doctor(int id, string name, int baseSalary, int consulationFee) : base(id, name, baseSalary)
        {
            ConsulationFee = consulationFee;
        }

        public override int CalculateSalary()
        {
            return BaseSalary + ConsulationFee;
        }
    }
    class Nurse : Staff
    {
        public int NightShiftAllowance;
        public Nurse(int id, string name, int baseSalary, int nightShiftAllowance) : base(id, name, baseSalary)
        {
            NightShiftAllowance = nightShiftAllowance;
        }
        public override int CalculateSalary()
        {
            return BaseSalary + NightShiftAllowance;
        }
    }
    class LabTechnician : Staff
    {
        public int EquipmentAllowance;
        public LabTechnician(int id, string name, int baseSalary, int equipmentAllowance) : base(id, name, baseSalary)
        {
            EquipmentAllowance = equipmentAllowance;
        }
        public override int CalculateSalary()
        {
            return BaseSalary + EquipmentAllowance;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Staff s1 = new Doctor(1, "Dr. Raj", 50000, 15000);
            Staff s2 = new Nurse(2, "Anita", 30000, 5000);
            Staff s3 = new LabTechnician(3, "Ravi", 28000, 4000);


            Console.WriteLine("Doctor Salary: " + s1.CalculateSalary());
            Console.WriteLine("Nurse Salary: " + s2.CalculateSalary());
            Console.WriteLine("Lab Technician Salary: " + s3.CalculateSalary());*/

            /* Account m = new SavingsAccount();
             m.CalculateInterest();

             SavingsAccount s = new SavingsAccount();
             s.CalculateInterest();*/

            /*  List<Order> orders = new List<Order>();

              orders.Add(new StandardOrder(1, 2000));
              orders.Add(new ExpressOrder(2, 3500));
              orders.Add(new InternationalOrder(3, 8000));

              foreach (Order order in orders)
              {
                  order.CalculateShippingCost();
              } */

            /*
            ElectricCar ec = new ElectricCar();
            ec.VechileNumber = 1;
            ec.Brand = "Tesla";
            ec.FuelType = "Electric";
            ec.StartVehicle();

            Console.WriteLine($"Vehicle Number : {ec.VechileNumber} and Brand is {ec.Brand} And Fuel Type is {ec.FuelType}"); */


            /* Student[] students = new Student[]
            {
                new SchoolStudent(1,"Viki",45),
                new CollegeStudent(2,"Ankita",55),
                new OnlineStudent(3,"vikas",58)
            };
            foreach (Student s in students)
            {
                s.CalculateGrade();
            }
        }*/

            Console.WriteLine("Select Furniture Type");
            Console.WriteLine("1. Chair");
            Console.WriteLine("2. Cot");

            int choice = int.Parse(Console.ReadLine());

            Furniture f;

            if (choice == 1)
                f = new Chair();
            else
                f = new Cot();

            f.GetData();
            f.ShowData();
        }
    }
}
