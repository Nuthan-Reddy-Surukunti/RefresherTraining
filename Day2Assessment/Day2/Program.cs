using System;
using System.Collections.Generic;

public static class FinancialCalculator
{
    public static decimal CalculateCompoundInterest(decimal principal, decimal rate, int time)
    {
        return principal * (decimal)Math.Pow((double)(1 + rate), time);
    }

    public static decimal CalculateCompoundInterest(decimal principal, decimal rate, int time, int compoundingFrequency = 1)
    {
        return principal * (decimal)Math.Pow((double)(1 + rate / compoundingFrequency), compoundingFrequency * time);
    }

    public static void Run()
    {
        decimal principal = 10000m;
        decimal rate = 0.05m;
        int time = 10;
        int compoundingFrequency = 12;

        decimal compoundInterest1 = CalculateCompoundInterest(principal, rate, time);
        Console.WriteLine($"Compound Interest (without compounding frequency): {compoundInterest1:C}");

        decimal compoundInterest2 = CalculateCompoundInterest(principal, rate, time, compoundingFrequency: compoundingFrequency);
        Console.WriteLine($"Compound Interest (with monthly compounding): {compoundInterest2:C}");
    }
}

public static class Question2
{
    public static bool TryProcessOrder(out List<string> validISBNs, params string[] ISBNs)
    {
        validISBNs = new List<string>();

        foreach (var ISBN in ISBNs)
        {
            if (TryParseISBN(ISBN, out string parsedISBN))
            {
                validISBNs.Add(parsedISBN);
            }
        }

        return validISBNs.Count > 0;
    }

    public static bool TryParseISBN(string ISBN, out string parsedISBN)
    {
        parsedISBN = ISBN.Replace("-", "").Trim();
        return parsedISBN.Length == 13;
    }

    public static void Run()
    {
        bool success = TryProcessOrder(
            out List<string> validISBNs,
            "978-3-16-148410-0",
            "1234567890123",
            "invalid-isbn",
            "978-1-4028-9462-6"
        );

        Console.WriteLine($"Success: {success}");

        foreach (var isbn in validISBNs)
        {
            Console.WriteLine(isbn);
        }
    }
}

public enum LogLevel
{
    Info,
    Warning,
    Error
}

public static class Question3
{
    public static bool ParseLogLine(in string logLine, out DateTime timestamp, out LogLevel logLevel, ref int counter)
    {
        counter++;

        timestamp = default;
        logLevel = LogLevel.Info;

        string dateText = logLine.Substring(0, 19);

        if (!DateTime.TryParse(dateText, out timestamp))
        {
            return false;
        }

        if (logLine.Contains("ERROR"))
        {
            logLevel = LogLevel.Error;
        }
        else if (logLine.Contains("WARNING"))
        {
            logLevel = LogLevel.Warning;
        }
        else if (logLine.Contains("INFO"))
        {
            logLevel = LogLevel.Info;
        }

        return true;
    }

    public static void Run()
    {
        string logLine = "2023-10-27 14:30:00 ERROR: Disk full";
        int counter = 0;

        bool success = ParseLogLine(in logLine, out DateTime timestamp, out LogLevel logLevel, ref counter);

        Console.WriteLine($"Success: {success}");
        Console.WriteLine($"Timestamp: {timestamp}");
        Console.WriteLine($"Log Level: {logLevel}");
        Console.WriteLine($"Counter: {counter}");
    }
}

public static class Question4
{
    public static double CalculateArea(double radius, int decimals = 2)
    {
        return Math.Round(Math.PI * radius * radius, decimals);
    }

    public static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    public static double CalculateArea(double baseLength, double height, bool isTriangle)
    {
        return 0.5 * baseLength * height;
    }

    public static void Run()
    {
        Console.WriteLine($"Circle Area: {CalculateArea(5)}");
        Console.WriteLine($"Rectangle Area: {CalculateArea(4.0, 6.0)}");
        Console.WriteLine($"Triangle Area: {CalculateArea(3, 7, true)}");
        Console.WriteLine($"Circle Area: {CalculateArea(radius: 5, decimals: 4)}");
    }
}

public static class MathOperations
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Add(params int[] numbers)
    {
        int result = 0;

        foreach (var number in numbers)
        {
            result += number;
        }

        return result;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Multiply(params int[] numbers)
    {
        int result = 1;

        foreach (var number in numbers)
        {
            result *= number;
        }

        return result;
    }

    public static void Run()
    {
        Console.WriteLine(Add(5, 10));
        Console.WriteLine(Add(1, 2, 3, 4, 5));
        Console.WriteLine(Multiply(2, 3));
        Console.WriteLine(Multiply(2, 3, 4, 5));
    }
}

public interface IConfigurationSource
{
    bool TryLoad(out Dictionary<string, string> configuration);
}

public class EnvironmentVariableSource : IConfigurationSource
{
    public bool TryLoad(out Dictionary<string, string> configuration)
    {
        configuration = new Dictionary<string, string>();
        return false;
    }
}

public class JsonFileSource : IConfigurationSource
{
    public bool TryLoad(out Dictionary<string, string> configuration)
    {
        configuration = new Dictionary<string, string>();
        return false;
    }
}

public class DatabaseSource : IConfigurationSource
{
    public bool TryLoad(out Dictionary<string, string> configuration)
    {
        configuration = new Dictionary<string, string>
        {
            { "ConnectionString", "DatabaseConnection" },
            { "Environment", "Production" }
        };

        return true;
    }
}

public static class ConfigurationLoader
{
    public static bool Load(out Dictionary<string, string> configuration, params IConfigurationSource[] sources)
    {
        foreach (var source in sources)
        {
            if (source.TryLoad(out configuration))
            {
                Console.WriteLine($"Successfully loaded configuration from {source.GetType().Name}");
                return true;
            }
        }

        configuration = new Dictionary<string, string>();
        return false;
    }

    public static void Run()
    {
        IConfigurationSource environment = new EnvironmentVariableSource();
        IConfigurationSource json = new JsonFileSource();
        IConfigurationSource database = new DatabaseSource();

        bool success = Load(out Dictionary<string, string> configuration, environment, json, database);

        Console.WriteLine($"Success: {success}");

        foreach (var item in configuration)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}

public class TreeNode
{
    public string Value { get; set; }
    public List<TreeNode> Children { get; set; } = new List<TreeNode>();

    public TreeNode(string value)
    {
        Value = value;
    }
}

public static class QuestionH2
{
    public static List<string> FlattenTree(params TreeNode[] roots)
    {
        List<string> result = new List<string>();

        void Traverse(TreeNode node, ref int depth)
        {
            result.Add(node.Value);
            Console.WriteLine($"{node.Value}: depth {depth}");

            foreach (var child in node.Children)
            {
                depth++;
                Traverse(child, ref depth);
                depth--;
            }
        }

        foreach (var root in roots)
        {
            int depth = 0;
            Traverse(root, ref depth);
        }

        return result;
    }

    public static void Run()
    {
        TreeNode root1 = new TreeNode("A");
        root1.Children.Add(new TreeNode("A1"));
        root1.Children.Add(new TreeNode("A2"));

        TreeNode root2 = new TreeNode("B");
        TreeNode b1 = new TreeNode("B1");
        b1.Children.Add(new TreeNode("B1a"));
        b1.Children.Add(new TreeNode("B1b"));
        root2.Children.Add(b1);

        TreeNode root3 = new TreeNode("C");

        List<string> result = FlattenTree(root1, root2, root3);

        Console.WriteLine(string.Join(", ", result));
    }
}

public static class QuestionH3
{
    public static string FormatLogMessage(string template, params object[] arguments)
    {
        string ProcessArguments()
        {
            string result = template;

            for (int i = 0; i < arguments.Length; i++)
            {
                string value;

                if (arguments[i] is int)
                {
                    int.TryParse(arguments[i].ToString(), out int parsed);
                    value = parsed.ToString();
                }
                else if (arguments[i] is DateTime dateTime)
                {
                    value = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    value = arguments[i]?.ToString() ?? "";
                }

                result = result.Replace($"{{{i}}}", value);
            }

            return result;
        }

        return ProcessArguments();
    }

    public static void Run()
    {
        string message = FormatLogMessage(
            "User {0} logged in from {1} at {2}",
            "JohnDoe",
            "192.168.1.1",
            new DateTime(2026, 7, 29, 14, 30, 0)
        );

        Console.WriteLine(message);
    }
}

public class Transaction
{
    public string Id { get; set; }
    public List<Transaction> Dependencies { get; set; } = new List<Transaction>();

    public Transaction(string id)
    {
        Id = id;
    }
}

public static class QuestionH4
{
    public static int CalculateRiskScore(string transactionId, Transaction transaction, int depthLimit = 1000)
    {
        if (!TryParseTransactionId(transactionId, out int id))
        {
            return -1;
        }

        int depth = 0;

        int Traverse(Transaction current, ref int currentDepth)
        {
            if (currentDepth >= depthLimit)
            {
                return -1;
            }

            int score = 1;

            foreach (var dependency in current.Dependencies)
            {
                currentDepth++;

                int result = Traverse(dependency, ref currentDepth);

                currentDepth--;

                if (result == -1)
                {
                    return -1;
                }

                score += result;
            }

            return score;
        }

        return Traverse(transaction, ref depth);
    }

    public static bool TryParseTransactionId(string transactionId, out int id)
    {
        id = 0;

        if (string.IsNullOrWhiteSpace(transactionId))
        {
            return false;
        }

        string value = transactionId.Replace("TX", "");

        return int.TryParse(value, out id);
    }

    public static void Run()
    {
        Transaction t1 = new Transaction("TX001");
        Transaction t2 = new Transaction("TX002");
        Transaction t3 = new Transaction("TX003");

        t1.Dependencies.Add(t2);
        t2.Dependencies.Add(t3);
        t3.Dependencies.Add(t1);

        int result = CalculateRiskScore("TX001", t1, 10);

        Console.WriteLine($"Risk Score: {result}");
    }
}

public class QueryBuilder
{
    private readonly List<string> clauses = new List<string>();

    public void AddWhereClause(string clause)
    {
        clauses.Add(clause);
    }

    public void AddWhereClause(params Action<QueryBuilder>[] conditions)
    {
        int indentation = 0;

        void ProcessConditions(Action<QueryBuilder>[] nestedConditions, ref int level)
        {
            level++;

            foreach (var condition in nestedConditions)
            {
                QueryBuilder nestedBuilder = new QueryBuilder();
                condition(nestedBuilder);

                string indentationText = new string(' ', level * 4);

                clauses.Add($"{indentationText}(");

                foreach (var clause in nestedBuilder.clauses)
                {
                    clauses.Add($"{indentationText}    {clause}");
                }

                clauses.Add($"{indentationText})");
            }

            level--;
        }

        ProcessConditions(conditions, ref indentation);
    }

    public string Build()
    {
        if (clauses.Count == 0)
        {
            return "";
        }

        return "WHERE " + string.Join(Environment.NewLine + "AND ", clauses);
    }
}

public static class QuestionH5
{
    public static void Run()
    {
        QueryBuilder builder = new QueryBuilder();

        builder.AddWhereClause("Status = 'Active'");

        builder.AddWhereClause(b =>
        {
            b.AddWhereClause("Age > 18");
            b.AddWhereClause("Age < 65");
        });

        Console.WriteLine(builder.Build());
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        // FinancialCalculator.Run();
        // Question2.Run();
        // Question3.Run();
        // Question4.Run();
        // MathOperations.Run();
        // ConfigurationLoader.Run();
        // QuestionH2.Run();
        // QuestionH3.Run();
        // QuestionH4.Run();
        // QuestionH5.Run();
    }
}