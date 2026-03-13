namespace Assignments
{ 
   
 /* question 1
  * public class Patient
    {
        public int patientId;
        public string name;
        public int age;
        public string Disease;

        public void Display() {
           Console.WriteLine($"PatientId: {patientId} Name: {name} Age: {age} Disease: {Disease}");

        }
    } */
      
    /* Question 2
    public class Doctor
    {
        public int DoctorId;
        public string DoctorName;
        public string Specialization;
        public float ConsulationFee;

        public void display()
        {
            Console.WriteLine($"DoctorId : {DoctorId}, DoctorName : {DoctorName} , Specialization : {Specialization} , Consulation Fees : {ConsulationFee}");
        }
    }
    */
    /*
     * assisgnment 3

    class Hosipital
    {
        public static string HospitalName = "ss+" ;
        public static string HospitalAddress = "pune";
        public string PatientName;
        public void display()
        {
            Console.WriteLine($"PateintName :{PatientName} HospitalName: {HospitalName} HospitalAddress : {HospitalAddress} ");
        }
    }
    */
   /*  
    //Assignment - 4
    class Appointment
    {
        public int AppointmentId;
        public string PatientName;
        public string DoctorName;
        public string AppointmentDate;

        public Appointment()
        {
            AppointmentId = 0;
            PatientName = "Saurab";
            DoctorName = "Sujit";
            AppointmentDate = "12-2-2026";
        }
    } */

    /*
    //Assignment - 5
    class MedicialTest
    {
        public int TestId;
        public string TestName;
        public float TestCost;

        public MedicialTest(int testId , string name , float testCost) 
        {
            TestId = testId;
            TestName = name;
            TestCost = testCost;
        }

    } */ 
/*
    //Asisgnement 6 
    class Biling
    {
        public string PatientName;
        public void CalculatetotalBill(int ConsulationFee, int TestCharges)
        {
            int Total_Bills = ConsulationFee + TestCharges;
            Console.WriteLine($" your total bill is {Total_Bills}");
        }

    } 
*/
/*
//assignment - 7 
    class Nurse {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string Department {  get; set; }   
    }
*/ 
class PatientRecord
    {
        public int PatientId { get; set; }
        public string PatientName;
        public int Age;
        public string Disease;
        public static string HospitalName = "Apollo Hospital";

        public  PatientRecord(string patientName , int age , string disease)
        {
            PatientName = patientName;
            Age = age;
            Disease = disease;
        }
        public void DisplayPateintRecord()
        {
            Console.WriteLine($"{PatientId},{HospitalName},{PatientName}, {Age},{Disease}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Patient p = new Patient();
             p.patientId = 1;
             p.name = "vishnu teja";
             p.age = 30;
             p.Disease = "viral fever";
             p.Display();*/

            /*
            Doctor d1 = new Doctor();
            d1.DoctorId = 1;
            d1.DoctorName = "Test";
            d1.ConsulationFee = 0;
            d1.Specialization = "Surgen";
            d1.display();
            Console.WriteLine();
            Doctor d2 = new Doctor();
            d2.DoctorId = 2;
            d2.DoctorName = "Test";
            d2.ConsulationFee = 0;
            d2.Specialization = "Helper";
            d2.display();
            */
            /*
                Hosipital h1 = new Hosipital();
                h1.PatientName = "haris";
                h1.display();
                Hosipital h2 = new Hosipital();
                h2.PatientName = "viki";
                h2.display();
                Hosipital h3 = new Hosipital();
                h3.PatientName = "sumi";
                h3.display();
            */

            /*  Appointment a = new Appointment();
              Console.WriteLine($"Appointment id is : {a.AppointmentId} , Patient Name is {a.PatientName} , Doctor Name is : {a.DoctorName} , Appointment Date is : {a.AppointmentDate}"); */
            /*

            MedicialTest m1 = new MedicialTest(1, "Blood Test", (float)12.24);
            MedicialTest m2 = new MedicialTest(2, "x-ray",(float) 34.45);
            Console.WriteLine(m1.TestId + " " + m1.TestName + " " + m1.TestCost );
            Console.WriteLine(m2.TestId + " " + m2.TestName + " " + m2.TestCost); */
/*
            Biling b = new Biling();
            b.PatientName = "vikas";
            Console.WriteLine(b.PatientName);
            b.CalculatetotalBill(3000,200);
            */
/*
            Nurse n = new Nurse();
            n.NurseId = 1;
            n.NurseName = "vendita";
            n.Department = "d-block";

            Console.WriteLine($"Nurse id : {n.NurseId} , Nurse Name : {n.NurseName} , Department : {n.Department}");
*/

            PatientRecord r = new PatientRecord("arjun",19,"sugar");
            r.PatientId = 1;
            PatientRecord r2 = new PatientRecord("viki", 29, "sugar");
            r2.PatientId = 2;
            PatientRecord r3 = new PatientRecord("vijun", 39, "sugar");
            r3.PatientId = 3;
            r.DisplayPateintRecord();
            r2.DisplayPateintRecord();
            r3.DisplayPateintRecord();

        }
    }
}
