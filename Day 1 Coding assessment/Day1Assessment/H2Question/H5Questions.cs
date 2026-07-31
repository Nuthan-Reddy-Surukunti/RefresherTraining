// using System;

// public interface IInvestmentCalculator
// {
//     double CalculateInvestment(
//         double principal,
//         double annualRate,
//         double duration);
// }

// public class SimpleInvestmentCalculator : IInvestmentCalculator
// {
//     public double CalculateInvestment(
//         double principal,
//         double annualRate,
//         double duration)
//     {
//         double interest =
//             principal * (annualRate / 100) * duration;

//         double finalValue = principal + interest;

//         return Math.Round(finalValue, 2);
//     }
// }

// public class CompoundInvestmentCalculator : IInvestmentCalculator
// {
//     public double CalculateInvestment(
//         double principal,
//         double annualRate,
//         double duration)
//     {
//         double finalValue =
//             principal * Math.Pow(1 + annualRate / 100, duration);

//         return Math.Round(finalValue, 2);
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine(
//             "Enter Investment Type (Simple/Compound):");

//         string investmentType;

//         while (true)
//         {
//             investmentType = Console.ReadLine();

//             if (investmentType.Equals(
//                     "Simple",
//                     StringComparison.OrdinalIgnoreCase) ||
//                 investmentType.Equals(
//                     "Compound",
//                     StringComparison.OrdinalIgnoreCase))
//             {
//                 break;
//             }

//             Console.WriteLine(
//                 "Invalid investment type. Enter Simple or Compound:");
//         }


//         Console.WriteLine("Enter Principal Amount:");

//         double principal;

//         while (!double.TryParse(Console.ReadLine(), out principal) ||
//                principal <= 0)
//         {
//             Console.WriteLine(
//                 "Invalid principal. Please enter an amount greater than zero:");
//         }


//         Console.WriteLine("Enter Annual Interest Rate (%):");

//         double annualRate;

//         while (!double.TryParse(Console.ReadLine(), out annualRate) ||
//                annualRate < 0 ||
//                annualRate > 100)
//         {
//             Console.WriteLine(
//                 "Invalid rate. Please enter a percentage between 0 and 100:");
//         }


//         Console.WriteLine("Enter Duration (Years):");

//         double duration;

//         while (!double.TryParse(Console.ReadLine(), out duration) ||
//                duration <= 0)
//         {
//             Console.WriteLine(
//                 "Invalid duration. Please enter years greater than zero:");
//         }


//         IInvestmentCalculator investmentCalculator;

//         if (investmentType.Equals(
//                 "Simple",
//                 StringComparison.OrdinalIgnoreCase))
//         {
//             investmentCalculator =
//                 new SimpleInvestmentCalculator();
//         }
//         else
//         {
//             investmentCalculator =
//                 new CompoundInvestmentCalculator();
//         }


//         double projectedValue =
//             investmentCalculator.CalculateInvestment(
//                 principal,
//                 annualRate,
//                 duration);


//         Console.WriteLine($"Investment Type: {investmentType}");
//         Console.WriteLine($"Principal Amount: ₹{principal:F2}");
//         Console.WriteLine($"Annual Rate: {annualRate}%");
//         Console.WriteLine($"Duration: {duration} Years");
//         Console.WriteLine($"Projected Value: ₹{projectedValue:F2}");
//     }
// }