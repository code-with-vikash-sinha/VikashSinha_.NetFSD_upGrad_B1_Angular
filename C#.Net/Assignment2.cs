using System;

class Program
{
    static void Main(string[] args)
    {

        /*-------------------------------------------------
        1. Display message
        -------------------------------------------------*/
        Console.WriteLine("Welcome to the world of C#");



        /*-------------------------------------------------
        2. Command line argument greeting
        -------------------------------------------------*/
        if(args.Length > 0)
        {
            Console.WriteLine("Hi! " + args[0]);
            Console.WriteLine("Welcome to the world of C#");
        }



        /*-------------------------------------------------
        3. Display numbers between two command arguments
        -------------------------------------------------*/
        if(args.Length >= 2)
        {
            int a = int.Parse(args[0]);
            int b = int.Parse(args[1]);

            for(int i = a+1; i < b; i++)
            {
                Console.WriteLine(i);
            }
        }



        /*-------------------------------------------------
        4. Odd or Even number
        -------------------------------------------------*/
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());

        if(num % 2 == 0)
            Console.WriteLine("Even number");
        else
            Console.WriteLine("Odd number");



        /*-------------------------------------------------
        5. Count total odd and even numbers
        -------------------------------------------------*/
        int even=0, odd=0;

        Console.WriteLine("Enter numbers (enter 0 to stop)");

        while(true)
        {
            int n = int.Parse(Console.ReadLine());
            if(n == 0) break;

            if(n % 2 == 0)
                even++;
            else
                odd++;
        }

        Console.WriteLine("Even count = " + even);
        Console.WriteLine("Odd count = " + odd);



        /*-------------------------------------------------
        6. Fahrenheit to Celsius
        -------------------------------------------------*/
        Console.Write("Enter temperature in Fahrenheit: ");
        double f = double.Parse(Console.ReadLine());

        double c = (f - 32) * 5 / 9;

        Console.WriteLine("Temperature in Celsius = " + c);



        /*-------------------------------------------------
        7. Shopkeeper total price
        -------------------------------------------------*/
        double total = 0;

        Console.WriteLine("Enter product number (1-3) and quantity, 0 to stop");

        while(true)
        {
            int product = int.Parse(Console.ReadLine());
            if(product == 0) break;

            int qty = int.Parse(Console.ReadLine());

            switch(product)
            {
                case 1: total += 22.5 * qty; break;
                case 2: total += 44.5 * qty; break;
                case 3: total += 9.98 * qty; break;
            }
        }

        Console.WriteLine("Total Price = " + total);



        /*-------------------------------------------------
        8. Series 0,1,4,9,16,...625
        -------------------------------------------------*/
        for(int i=0;i<=25;i++)
        {
            Console.Write((i*i) + " ");
        }



        /*-------------------------------------------------
        9. Factorial
        -------------------------------------------------*/
        Console.Write("\nEnter number for factorial: ");
        int factNum = int.Parse(Console.ReadLine());

        int fact = 1;

        for(int i=1;i<=factNum;i++)
        {
            fact *= i;
        }

        Console.WriteLine("Factorial = " + fact);



        /*-------------------------------------------------
        10. Fibonacci till 40
        -------------------------------------------------*/
        int a1=0,b1=1;

        Console.WriteLine("Fibonacci series:");

        while(a1 <= 40)
        {
            Console.Write(a1 + " ");
            int temp = a1 + b1;
            a1 = b1;
            b1 = temp;
        }



        /*-------------------------------------------------
        11. Multiplication table till 20
        -------------------------------------------------*/
        Console.Write("\nEnter number: ");
        int table = int.Parse(Console.ReadLine());

        for(int i=1;i<=20;i++)
        {
            Console.WriteLine(table + " x " + i + " = " + table*i);
        }



        /*-------------------------------------------------
        12. Numbers divisible by 7 between 200 and 300
        -------------------------------------------------*/
        for(int i=200;i<=300;i++)
        {
            if(i % 7 == 0)
                Console.Write(i + " ");
        }



        /*-------------------------------------------------
        13. Largest of three numbers
        -------------------------------------------------*/
        Console.WriteLine("\nEnter 3 numbers");

        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int z = int.Parse(Console.ReadLine());

        int largest = Math.Max(x, Math.Max(y,z));

        Console.WriteLine("Largest = " + largest);



        /*-------------------------------------------------
        14. Smallest of five numbers
        -------------------------------------------------*/
        Console.WriteLine("Enter 5 numbers");

        int min = int.MaxValue;

        for(int i=0;i<5;i++)
        {
            int n = int.Parse(Console.ReadLine());

            if(n < min)
                min = n;
        }

        Console.WriteLine("Smallest = " + min);



        /*-------------------------------------------------
        15. Marks calculation
        -------------------------------------------------*/
        int[] marks = new int[10];
        int totalMarks = 0;

        Console.WriteLine("Enter 10 marks");

        for(int i=0;i<10;i++)
        {
            marks[i] = int.Parse(Console.ReadLine());
            totalMarks += marks[i];
        }

        double avg = totalMarks / 10.0;

        Array.Sort(marks);

        Console.WriteLine("Total = " + totalMarks);
        Console.WriteLine("Average = " + avg);
        Console.WriteLine("Min = " + marks[0]);
        Console.WriteLine("Max = " + marks[9]);

        Console.WriteLine("Ascending order:");
        foreach(int m in marks)
            Console.Write(m + " ");

        Console.WriteLine("\nDescending order:");
        for(int i=9;i>=0;i--)
            Console.Write(marks[i] + " ");



        /*-------------------------------------------------
        16. Length of word
        -------------------------------------------------*/
        Console.Write("\nEnter word: ");
        string word = Console.ReadLine();

        Console.WriteLine("Length = " + word.Length);



        /*-------------------------------------------------
        17. Reverse word
        -------------------------------------------------*/
        char[] arr = word.ToCharArray();
        Array.Reverse(arr);

        Console.WriteLine("Reverse = " + new string(arr));



        /*-------------------------------------------------
        18. Compare two words
        -------------------------------------------------*/
        Console.WriteLine("Enter first word");
        string w1 = Console.ReadLine();

        Console.WriteLine("Enter second word");
        string w2 = Console.ReadLine();

        if(w1 == w2)
            Console.WriteLine("Both words are same");
        else
            Console.WriteLine("Words are different");



        /*-------------------------------------------------
        19. Palindrome check
        -------------------------------------------------*/
        string rev = new string(word.Reverse().ToArray());

        if(word == rev)
            Console.WriteLine("Palindrome");
        else
            Console.WriteLine("Not Palindrome");

    }
}