public class Patient
{
    
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Temperature { get; set; }

    public double CalculateBMI()
    {
        return Math.Round(Weight / (Height * Height), 2);
    }

    public Patient(string name, int age, double weight, double height,double temperature)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Height = height;
        Temperature = temperature;
    }
}
public class Validator
{
    public static bool ValidateName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }
    public static bool ValidateAge(int age)
    {
        return age > 0 && age < 120;
    }

    public static bool ValidateWeight(double weight)
    {
        return weight > 0 && weight <= 300;
    }

    public static bool ValidateHeight(double height)
    {
        return height > 0 && height < 2.5;
    }

    public static bool ValidateTemperature(double temperature)
    {
        return temperature >= 35 && temperature <= 45;
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Your Name:");
        string name = Console.ReadLine();
        while (!Validator.ValidateName(name))
        {
            Console.WriteLine("Invalid name. Please enter a valid name:");
            name = Console.ReadLine();
        }

        Console.WriteLine("Enter Your Age:");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age) || !Validator.ValidateAge(age))
        {
            Console.WriteLine("Invalid age. Please enter a valid age:");
        }

        Console.WriteLine("Enter Your Weight (Kg):");
        double weight;
        while (!double.TryParse(Console.ReadLine(), out weight) || !Validator.ValidateWeight(weight))
        {
            Console.WriteLine("Invalid weight. Please enter a valid weight:");
        }

        Console.WriteLine("Enter Your Height (M):");
        double height;
        while (!double.TryParse(Console.ReadLine(), out height) || !Validator.ValidateHeight(height))
        {
            Console.WriteLine("Invalid height. Please enter a valid height:");
        }

        Console.WriteLine("Enter Your Temperature (°C):");
        double temperature;
        while (!double.TryParse(Console.ReadLine(), out temperature) || !Validator.ValidateTemperature(temperature))
        {
            Console.WriteLine("Invalid temperature. Please enter a valid temperature:");
        }
        Patient patient = new Patient(name, age, weight, height, temperature);
        Console.WriteLine("---- Patient Information ---");
        Console.WriteLine($"Name: {patient.Name}");
        Console.WriteLine($"Age: {patient.Age}");
        Console.WriteLine($"Weight: {patient.Weight} kg");
        Console.WriteLine($"Height: {patient.Height} m");
        Console.WriteLine($"Temperature: {patient.Temperature} °C");
        Console.WriteLine($"BMI: {patient.CalculateBMI()}");
    }
}