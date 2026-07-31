public interface IBillCalculator
{
    double CalculateBill(int unitsConsumed, double ratePerUnit, double fixedCharges);
}
public class ResidentialBillCalculator:IBillCalculator
{
    public double CalculateBill(int unitsConsumed, double ratePerUnit, double fixedCharges)
    {
       double EnergyCharge = Math.Round(unitsConsumed * ratePerUnit, 2);
       double FinalBill = Math.Round(EnergyCharge + fixedCharges, 2);
       return FinalBill;
    }
}
public class CommercialBillCalculator:IBillCalculator
{
    public double CalculateBill(int unitsConsumed, double ratePerUnit, double fixedCharges)
    {
        double EnergyCharge = Math.Round(unitsConsumed * ratePerUnit, 2);
        double Surcharge = Math.Round(EnergyCharge * 10 / 100, 2);
        double FinalBill = Math.Round(EnergyCharge + Surcharge + fixedCharges, 2);
        return FinalBill;
    }
}
public static class Program
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("Enter the type of consumer (Residential/Commercial): ");
        string consumerType;
        while (true)
        {
            consumerType = Console.ReadLine();
            if (consumerType.Equals("Residential", StringComparison.OrdinalIgnoreCase) || consumerType.Equals("Commercial", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid consumer type. Please enter 'Residential' or 'Commercial':");
            }
        }

        Console.WriteLine("Enter Units Consumed: ");
       int units;
        while(!int.TryParse(Console.ReadLine(), out units) || units < 0)
        {
            Console.WriteLine("Invalid units. Please enter a valid number of units consumed:");
        }
        Console.WriteLine("Enter the Rate per Unit: ");
        double rate;
        while(!double.TryParse(Console.ReadLine(), out rate) || rate < 0)
        {
            Console.WriteLine("Invalid rate. Please enter a valid rate per unit:");
        }
        Console.WriteLine("Enter the Fixed Charges: ");
        double fixedCharges;
        while(!double.TryParse(Console.ReadLine(), out fixedCharges) || fixedCharges < 0)
        { 
            Console.WriteLine("Invalid fixed charges. Please enter a valid amount:");
        }
        ResidentialBillCalculator residentialBillCalculator = new ResidentialBillCalculator();
        CommercialBillCalculator commercialBillCalculator = new CommercialBillCalculator();
        double finalBill;
        if (consumerType.Equals("Residential", StringComparison.OrdinalIgnoreCase))
        {
            finalBill = residentialBillCalculator.CalculateBill(units, rate, fixedCharges);
        }
        else
        {
            finalBill = commercialBillCalculator.CalculateBill(units, rate, fixedCharges);
        }
        Console.WriteLine($"Consumer Type: {consumerType}");
        Console.WriteLine($"Units Consumed: {units}");
        Console.WriteLine($"Rate per Unit: {rate}");
        Console.WriteLine($"Fixed Charges: {fixedCharges}");
        Console.WriteLine($"Final Bill Amount: {finalBill}");
        
    }
}