## Claim
The problem is the very poor integration with VS, half of the time GitHub copilot is not capable of extracting the code part from what Claude says and so you have to copy paste things yourselves.

 “Edit this function to use iteration instead of being recursive”
-> 4.1 will perfectly edit the source file
-> Claude will chat a lot, suggest the solution in the Chat but will not edit the source file

## Test
Take non-llm generated recursive fibonnaci code, prompt LLM to convert to an iterative approach, compare results of using GPT4.1 and Claude Sonnet 4 using agent mode in Visual Studio.

## Result
Both Claude Sonnet 4 and ChatGPT 4.1 solved answered the prompt correctly.  Claim disproved :-)

## Code
**GPT4.1 GHCP Visual Studio:**

`git show 18f00deb14aa11cad2943b5992d1f24d1fef6d8e`:

```
❯ git show 18f00deb14aa11cad2943b5992d1f24d1fef6d8e
commit 18f00deb14aa11cad2943b5992d1f24d1fef6d8e
Author: James Clarke (WinExp Microsoft Store) <jeclarke@ntdev.microsoft.com>
Date:   Tue Jul 1 11:20:47 2025 -0700

    Transform to iterative using GHCP in VS with agent mode and GPT-4.1

diff --git a/challenges/rudy/LLMAgentmodeCompare/Program.cs b/challenges/rudy/LLMAgentmodeCompare/Program.cs
index 55c2e24..a8ff7b6 100644
--- a/challenges/rudy/LLMAgentmodeCompare/Program.cs
+++ b/challenges/rudy/LLMAgentmodeCompare/Program.cs
@@ -1,4 +1,7 @@
-﻿// Vibonacci non-LLM generated from: https://dotnettutorials.net/lesson/fibonacci-series-in-csharp/
+﻿// Fibonacci non-LLM generated from: https://dotnettutorials.net/lesson/fibonacci-series-in-csharp/
+
+// Transform to iterative using GHCP in VS with agent mode and GPT-4.1
+// Prompt: "rewrite the recursive FibonacciSeries funciton using an iterative approach"

 using System;
 namespace LogicalPrograms
@@ -14,10 +17,14 @@ namespace LogicalPrograms
         }
         public static void FibonacciSeries(int firstNumber, int secondNumber, int counter, int number)
         {
-            Console.Write(firstNumber + " ");
-            if (counter < number)
+            // Iterative approach to print Fibonacci series
+            int a = firstNumber, b = secondNumber;
+            for (int i = 1; i <= number; i++)
             {
-                FibonacciSeries(secondNumber, firstNumber + secondNumber, counter + 1, number);
+                Console.Write(a + " ");
+                int temp = a + b;
+                a = b;
+                b = temp;
             }
         }
     }
```

**Claude Sonnet 4 GHCP Visual Studio:**

```
❯ git show 86eae23c6b84f632f57c10b1127b26e73cf8e4fe
commit 86eae23c6b84f632f57c10b1127b26e73cf8e4fe
Author: James Clarke (WinExp Microsoft Store) <jeclarke@ntdev.microsoft.com>
Date:   Tue Jul 1 11:27:23 2025 -0700

    Transform to iterative using GHCP in VS with agent mode and Claude Sonnet 4

diff --git a/challenges/rudy/LLMAgentmodeCompare/Program.cs b/challenges/rudy/LLMAgentmodeCompare/Program.cs
index a8ff7b6..517922f 100644
--- a/challenges/rudy/LLMAgentmodeCompare/Program.cs
+++ b/challenges/rudy/LLMAgentmodeCompare/Program.cs
@@ -1,8 +1,6 @@
 ﻿// Fibonacci non-LLM generated from: https://dotnettutorials.net/lesson/fibonacci-series-in-csharp/
-
-// Transform to iterative using GHCP in VS with agent mode and GPT-4.1
+// Transform to iterative using GHCP in VS with agent mode and Claude Sonnet 4
 // Prompt: "rewrite the recursive FibonacciSeries funciton using an iterative approach"
-
 using System;
 namespace LogicalPrograms
 {
@@ -12,19 +10,20 @@ namespace LogicalPrograms
         {
             Console.Write("Please enter the Length of the Fibonacci Series : ");
             int number = int.Parse(Console.ReadLine());
-            FibonacciSeries(0, 1, 1, number);
+            FibonacciSeries(number);
             Console.ReadKey();
         }
-        public static void FibonacciSeries(int firstNumber, int secondNumber, int counter, int number)
+        public static void FibonacciSeries(int number)
         {
-            // Iterative approach to print Fibonacci series
-            int a = firstNumber, b = secondNumber;
-            for (int i = 1; i <= number; i++)
+            int firstNumber = 0;
+            int secondNumber = 1;
+
+            for (int counter = 1; counter <= number; counter++)
             {
-                Console.Write(a + " ");
-                int temp = a + b;
-                a = b;
-                b = temp;
+                Console.Write(firstNumber + " ");
+                int nextNumber = firstNumber + secondNumber;
+                firstNumber = secondNumber;
+                secondNumber = nextNumber;
             }
         }
     }
```

## Output

Sonnet
Please enter the Length of the Fibonacci Series : 20
0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181

GPT4.1 output
Please enter the Length of the Fibonacci Series : 20
0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181