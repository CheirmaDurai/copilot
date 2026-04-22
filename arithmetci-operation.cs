using System;
using System.Collections.Generic;

namespace Copilot.Arithmetic
{
    /// <summary>
    /// Interface for polymorphic arithmetic operations
    /// </summary>
    public interface IArithmeticOperation
    {
        double Execute(double a, double b);
        string OperationName { get; }
    }

    /// <summary>
    /// Addition operation
    /// </summary>
    public class Add : IArithmeticOperation
    {
        public string OperationName => "Addition";

        public double Execute(double a, double b)
        {
            return a + b;
        }
    }

    /// <summary>
    /// Subtraction operation
    /// </summary>
    public class Subtract : IArithmeticOperation
    {
        public string OperationName => "Subtraction";

        public double Execute(double a, double b)
        {
            return a - b;
        }
    }

    /// <summary>
    /// Multiplication operation
    /// </summary>
    public class Multiply : IArithmeticOperation
    {
        public string OperationName => "Multiplication";

        public double Execute(double a, double b)
        {
            return a * b;
        }
    }

    /// <summary>
    /// Division operation with zero-division handling
    /// </summary>
    public class Division : IArithmeticOperation
    {
        public string OperationName => "Division";

        public double Execute(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero. Divisor must be non-zero.");
            }
            return a / b;
        }
    }

    /// <summary>
    /// Demonstration of polymorphic arithmetic operations
    /// </summary>
    public class ArithmeticCalculator
    {
        public static void Main(string[] args)
        {
            // Create list of polymorphic operations
            List<IArithmeticOperation> operations = new List<IArithmeticOperation>
            {
                new Add(),
                new Subtract(),
                new Multiply(),
                new Division()
            };

            double operand1 = 20;
            double operand2 = 5;

            Console.WriteLine($"Performing arithmetic operations on {operand1} and {operand2}:\n");

            // Execute each operation polymorphically
            foreach (var operation in operations)
            {
                try
                {
                    double result = operation.Execute(operand1, operand2);
                    Console.WriteLine($"{operation.OperationName}: {operand1} → {operand2} = {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"{operation.OperationName}: Error - {ex.Message}");
                }
            }

            // Example with division by zero handling
            Console.WriteLine("\n--- Testing Division by Zero ---");
            var divisionOp = new Division();
            try
            {
                divisionOp.Execute(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Caught Exception: {ex.Message}");
            }
        }
    }
}
