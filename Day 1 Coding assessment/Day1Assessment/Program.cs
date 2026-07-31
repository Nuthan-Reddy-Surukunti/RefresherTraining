using System;

public class Program
{
    public static void Main()
    { 
        
        Program program = new Program();
        program.Question5();

    }
    public static void Question1()
    {
        Console.WriteLine("Enter the price:");
        double price;
        while (!double.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price. Please enter a valid price:");
        }
        Console.WriteLine("Enter the quantity:");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid quantity. Please enter a valid quantity:");
        }
        Console.WriteLine("Enter the discount percentage:");
        double discountPercentage; 
        while(!double.TryParse(Console.ReadLine(),out discountPercentage))
        {
            Console.WriteLine("Invalid discount percentage. Please enter a valid discount percentage:");
        }

        double subtotal = price* quantity;
        double discountedAmount = Math.Round(subtotal * discountPercentage/100,2);
        double total = subtotal-discountedAmount;
        Console.WriteLine("Discounted amount: " + discountedAmount);
        Console.WriteLine($"Total Amount : {total}");
    }
    public  void Question2()
    {
        Console.WriteLine("Enter Your Weight(Kg):");
        int weight;
        while(!int.TryParse(Console.ReadLine(), out weight) || weight <= 0)
        {
            
            Console.WriteLine("Invalid weight. Please enter a valid weight:");
        }

        Console.WriteLine("Enter Your Height(M):");
        double height;
        while(!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            
            Console.WriteLine("Invalid height. Please enter a valid height:");
        }

        double bmi = Math.Round(weight / (height * height), 2);
        Console.WriteLine($"Your BMI is: {bmi}");
        
    }
    public void Question3()
    {
        Console.WriteLine("Enter the Length:");
        double length;
        while(!double.TryParse(Console.ReadLine(), out length) || length <= 0)
        {
            Console.WriteLine("Invalid length. Please enter a valid length:");
        }
        Console.WriteLine("Enter the Width:");
        double width;
        while(!double.TryParse(Console.ReadLine(), out width) || width <= 0)
        {
            Console.WriteLine("Invalid width. Please enter a valid width:");
        }
        Console.WriteLine("Enter the Height:");
        double height;
        while(!double.TryParse(Console.ReadLine(), out height) || height <= 0)
        {
            Console.WriteLine("Invalid height. Please enter a valid height:");
        }
        double volume = Math.Round(length * width * height, 2);
        Console.WriteLine($"The volume of the package is: {volume}");
    }
    public void Question4()
    {
        Console.WriteLine("Enter the Opening Balance:");
        double openingBalance;
        while(!double.TryParse(Console.ReadLine(), out openingBalance) || openingBalance < 0)
        {
            Console.WriteLine("Invalid opening balance. Please enter a valid opening balance:");
        }
        Console.WriteLine("Enter total Deposits:");
        double totalDeposits;
        while(!double.TryParse(Console.ReadLine(), out totalDeposits) || totalDeposits < 0)
        {
            Console.WriteLine("Invalid total deposits. Please enter a valid total deposits:");
        }
        Console.Write("Enter Total Withdrawals: ");
        double withdrawals;

        while (!double.TryParse(Console.ReadLine(), out withdrawals) || withdrawals < 0)
        {
            Console.Write("Invalid input. Withdrawals cannot be negative. Enter again: ");
        }

        double availableBalance = openingBalance + totalDeposits;
        if (withdrawals > availableBalance)
        {
            Console.WriteLine("Error: Withdrawal exceeds available funds.");
            Console.WriteLine($"Available Balance: ₹{availableBalance:F2}");
        }
        else
        {
            double finalBalance = availableBalance - withdrawals;

            Console.WriteLine($"Final Balance: ₹{finalBalance:F2}");
        }

    }
    public void Question5()
    {
        Console.WriteLine("Enter marks for Subject 1:");
        double mark1;
        while (!double.TryParse(Console.ReadLine(), out mark1) || mark1 < 0 || mark1 > 100)
        {
            Console.WriteLine("Invalid marks. Please enter marks between 0 and 100:");
        }

        Console.WriteLine("Enter marks for Subject 2:");
        double mark2;
        while (!double.TryParse(Console.ReadLine(), out mark2) || mark2 < 0 || mark2 > 100)
        {
            Console.WriteLine("Invalid marks. Please enter marks between 0 and 100:");
        }

        Console.WriteLine("Enter marks for Subject 3:");
        double mark3;
        while (!double.TryParse(Console.ReadLine(), out mark3) || mark3 < 0 || mark3 > 100)
        {
            Console.WriteLine("Invalid marks. Please enter marks between 0 and 100:");
        }

        Console.WriteLine("Enter marks for Subject 4:");
        double mark4;
        while (!double.TryParse(Console.ReadLine(), out mark4) || mark4 < 0 || mark4 > 100)
        {
            Console.WriteLine("Invalid marks. Please enter marks between 0 and 100:");
        }

        Console.WriteLine("Enter marks for Subject 5:");
        double mark5;
        while (!double.TryParse(Console.ReadLine(), out mark5) || mark5 < 0 || mark5 > 100)
        {
            Console.WriteLine("Invalid marks. Please enter marks between 0 and 100:");
        }

        double total = mark1 + mark2 + mark3 + mark4 + mark5;
        double average = total / 5;
        double percentage = Math.Round((total / 500) * 100, 2);

        Console.WriteLine($"Total Marks: {total}");
        Console.WriteLine($"Average Marks: {average:F2}");
        Console.WriteLine($"Percentage: {percentage}%");
    }
}
