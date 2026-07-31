// public class Employee
// {
//     public string Name { get; set; }
//     public double TotalHoursWorked { get; set; }
//     public double HourlyRate { get; set; }
//     public Employee(string name, double totalHoursWorked, double hourlyRate)
//     {
//         Name = name;
//         TotalHoursWorked = totalHoursWorked;
//         HourlyRate = hourlyRate;
//     }
// }
// public class PayrollCalculator
// {
//     public double ReguralPay(double totalHoursWorked, double hourlyRate)
//     {
//         double overtimeHours = Math.Max(0, totalHoursWorked - 40);
//         double regularHours = totalHoursWorked - overtimeHours;
//         return Math.Round(regularHours * hourlyRate, 2);
//     }
//     public double OvertimePay(double totalHoursWorked, double hourlyRate)
//     {
//         double overtimeHours = Math.Max(0, totalHoursWorked - 40);
//         return Math.Round(overtimeHours * hourlyRate * 1.5, 2);
//     }
//     public double GrossSalary(double ReguralPay, double OvertimePay)
//     {
//         return Math.Round(ReguralPay + OvertimePay, 2);
//     }
    
// }
// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter Your Name: ");
//         string EmployeeName = Console.ReadLine();

//         Console.WriteLine("Enter Your total Hourly worked: ");
//         double totalHoursWorked;
//         while(!double.TryParse(Console.ReadLine(), out totalHoursWorked) || totalHoursWorked < 0|| totalHoursWorked > 168)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid number of hours worked:");
//         }
//         Console.WriteLine("Enter Your Hourly Rate: ");
//         double hourlyRate;
//         while(!double.TryParse(Console.ReadLine(), out hourlyRate) || hourlyRate <= 0)
//         {
//             Console.WriteLine("Invalid input. Please enter a valid hourly rate:");
//         }
//         Employee employee = new Employee(EmployeeName, totalHoursWorked, hourlyRate);
//         PayrollCalculator payrollCalculator = new PayrollCalculator();
//         double regularPay = payrollCalculator.ReguralPay(employee.TotalHoursWorked, employee.HourlyRate);
//         double overtimePay = payrollCalculator.OvertimePay(employee.TotalHoursWorked, employee.HourlyRate);
//         double grossSalary = payrollCalculator.GrossSalary(regularPay, overtimePay);
//         Console.WriteLine($"Employee Name: {employee.Name}");
//         Console.WriteLine($"Total Hours Worked: {employee.TotalHoursWorked}");
//         Console.WriteLine($"Hourly Rate: {employee.HourlyRate}");
//         Console.WriteLine($"Regular Pay: {regularPay}");
//         Console.WriteLine($"Overtime Pay: {overtimePay}");
//         Console.WriteLine($"Gross Salary: {grossSalary}");

//     }
// }