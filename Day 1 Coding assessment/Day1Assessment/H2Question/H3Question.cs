// using System;

// public interface IShippingCalculator
// {
//     double CalculateShippingCost(double weight, double distance);
// }

// public class StandardShippingCalculator : IShippingCalculator
// {
//     public double CalculateShippingCost(double weight, double distance)
//     {
//         double shippingCost = weight * distance / 100 * 5;

//         return Math.Round(shippingCost, 2);
//     }
// }

// public class ExpressShippingCalculator : IShippingCalculator
// {
//     public double CalculateShippingCost(double weight, double distance)
//     {
//         double shippingCost = weight * distance / 100 * 8 + 100;

//         return Math.Round(shippingCost, 2);
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
//         // Package Type
//         Console.WriteLine("Enter Package Type (Standard/Express):");

//         string packageType;

//         while (true)
//         {
//             packageType = Console.ReadLine();

//             if (packageType.Equals("Standard", StringComparison.OrdinalIgnoreCase) ||
//                 packageType.Equals("Express", StringComparison.OrdinalIgnoreCase))
//             {
//                 break;
//             }

//             Console.WriteLine(
//                 "Invalid package type. Please enter Standard or Express:");
//         }


//         Console.WriteLine("Enter Package Weight (kg):");

//         double weight;

//         while (!double.TryParse(Console.ReadLine(), out weight) ||
//                weight <= 0 ||
//                weight > 1000)
//         {
//             Console.WriteLine(
//                 "Invalid weight. Please enter a weight between 0 and 1000 kg:");
//         }


//         Console.WriteLine("Enter Shipping Distance (km):");

//         double distance;

//         while (!double.TryParse(Console.ReadLine(), out distance) ||
//                distance <= 0 ||
//                distance > 10000)
//         {
//             Console.WriteLine(
//                 "Invalid distance. Please enter a distance between 0 and 10000 km:");
//         }


//         IShippingCalculator shippingCalculator;

//         if (packageType.Equals("Standard", StringComparison.OrdinalIgnoreCase))
//         {
//             shippingCalculator = new StandardShippingCalculator();
//         }
//         else
//         {
//             shippingCalculator = new ExpressShippingCalculator();
//         }


//         double shippingCost =
//             shippingCalculator.CalculateShippingCost(weight, distance);


//         Console.WriteLine($"Package Type: {packageType}");
//         Console.WriteLine($"Weight: {weight} kg");
//         Console.WriteLine($"Distance: {distance} km");
//         Console.WriteLine($"Shipping Cost: ₹{shippingCost:F2}");
//     }
// }