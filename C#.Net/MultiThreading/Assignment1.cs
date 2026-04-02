using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int[] partialSums = new int[5];

    static void Process(object obj)
    {
        var data = (Tuple<List<int>, int>)obj;
        List<int> numbers = data.Item1;
        int threadIndex = data.Item2;

        int sum = 0;

        Console.WriteLine($"Thread {threadIndex + 1} processing:");

        foreach (var num in numbers)
        {
            Console.Write(num + " ");
            sum += num;
        }

        Console.WriteLine();
        partialSums[threadIndex] = sum;
        Console.WriteLine($"Thread {threadIndex + 1} Sum: {sum}");
    }

    static void Main()
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 50; i++)
            numbers.Add(i);

        int partSize = 10; // 50 / 5
        Thread[] threads = new Thread[5];

        for (int i = 0; i < 5; i++)
        {
            List<int> part = numbers.GetRange(i * partSize, partSize);
            threads[i] = new Thread(Process);
            threads[i].Start(Tuple.Create(part, i));
        }

        // Wait for all threads
        foreach (var t in threads)
            t.Join();

        int finalSum = 0;
        foreach (var s in partialSums)
            finalSum += s;

        Console.WriteLine("Final Sum: " + finalSum);
    }
}