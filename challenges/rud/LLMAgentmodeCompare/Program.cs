// Fibonacci non-LLM generated from: https://dotnettutorials.net/lesson/fibonacci-series-in-csharp/
// Transform to iterative using GHCP in VS with agent mode and Claude Sonnet 4
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
            FibonacciSeries(number);
            Console.ReadKey();
        }
        public static void FibonacciSeries(int number)
        {
            int firstNumber = 0;
            int secondNumber = 1;
            
            for (int counter = 1; counter <= number; counter++)
            {
                Console.Write(firstNumber + " ");
                int nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
        }
    }
}