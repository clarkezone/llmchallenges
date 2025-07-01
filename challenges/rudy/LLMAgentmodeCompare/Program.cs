// Fibonacci non-LLM generated from: https://dotnettutorials.net/lesson/fibonacci-series-in-csharp/

// Transform to iterative using GHCP in VS with agent mode and GPT-4.1
// Prompt: "rewrite the recursive FibonacciSeries funciton using an iterative approach"

using System;
namespace LogicalPrograms
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the Length of the Fibonacci Series : ");
            int number = int.Parse(Console.ReadLine());
            FibonacciSeries(0, 1, 1, number);
            Console.ReadKey();
        }
        public static void FibonacciSeries(int firstNumber, int secondNumber, int counter, int number)
        {
            // Iterative approach to print Fibonacci series
            int a = firstNumber, b = secondNumber;
            for (int i = 1; i <= number; i++)
            {
                Console.Write(a + " ");
                int temp = a + b;
                a = b;
                b = temp;
            }
        }
    }
}