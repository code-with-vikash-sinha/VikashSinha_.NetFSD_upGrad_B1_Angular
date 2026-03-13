using System;

namespace Input
{
    internal class Program
    {
        static void question1()
        {
            Console.WriteLine("Enter the first number");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Quotient is " + a / b);
        }

        static void question2()
        {
            Console.WriteLine("Enter km to convert into meter");
            int km = int.Parse(Console.ReadLine());

            Console.WriteLine("Distance in meter: " + km * 1000);
        }

        static void question3()
        {
            Console.WriteLine("Enter the Five Number ");
            string[] inp = Console.ReadLine().Split();
            int a = int.Parse(inp[0]);
            int b = int.Parse(inp[1]);
            int c = int.Parse(inp[2]);  
            int d = int.Parse(inp[3]);
            int e = int.Parse(inp[4]);
            int sum = a + b + c + d + e;
            Console.WriteLine(sum);
            int avg = sum / 5;           
            Console.WriteLine(avg);
        }

        static void question4() {
            Console.WriteLine("Enter the number to check Even or odd");
            int n = int.Parse((Console.ReadLine()));
            if(n % 2 == 0)
            {
                Console.WriteLine("Even Number");
            }else
            {
                Console.WriteLine("Odd Number");
             }
        }

        static void question5() {
            Console.WriteLine("Enter the First Number");
            int a = int.Parse((Console.ReadLine()));
            Console.WriteLine("Enter the Second Number");
            int b = int.Parse((Console.ReadLine()));
            if (a > b)
            {
                Console.WriteLine((a + " is greater then "+ b));
            }
            else
            {
                Console.WriteLine((b + " is greater then " + a));
            }
        }

        static void question6()
        {
            Console.WriteLine("What Area you want Rectangle or Square ");
            string s = Console.ReadLine();
            if (s == "Rectangle")
            {
                Console.WriteLine("enter the length of rectangle");
                int l = int.Parse((Console.ReadLine()));
                Console.WriteLine("Enter the Width of rectangle");
                int w = int.Parse((Console.ReadLine()));
                Console.WriteLine("Area of Rectangle is " + l * w);
            }
            else if (s == "Square")
            {
                Console.WriteLine("Enter the Side of Square");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Area of Square is :" + a * a);
            }
            else
            {
                Console.WriteLine("Out of Chosen Feild");
            }

        }

        static void question7()
        {
            Console.WriteLine("Enter the Distance in km");
            int D = int.Parse((Console.ReadLine()));
            Console.WriteLine("Enter the Speed in hour");
            int S = int.Parse((Console.ReadLine()));
            float T = D / S;
            Console.WriteLine("The time taken is " + T + "km/h");
        }

        static void question8()
        {
            Console.WriteLine("Write a letter to see that third word is Vowel or Consonant");
            {
                Console.WriteLine("Enter a word:");
                string word = Console.ReadLine();

                char third = word[2]; 

                if (third == 'a' || third == 'e' || third == 'i' || third == 'o' || third == 'u' ||
                    third == 'A' || third == 'E' || third == 'I' || third == 'O' || third == 'U')
                {
                    Console.WriteLine("Third letter is a vowel: " + third);
                }
                else
                {
                    Console.WriteLine("Third letter is a consonant: " + third);
                }
            }
        }
        static void Main(string[] args)
        {
            question8();
        }
    }
}