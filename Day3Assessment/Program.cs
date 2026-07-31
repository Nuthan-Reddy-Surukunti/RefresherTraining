public abstract class Payment
{
    public decimal Amount { get; set; }
    public abstract void ProcessPayment();
}
public class CreditCardPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine($"Processing credit card payment of {Amount:C}");
    }
}
public class UPayPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine($"Processing UPay payment of {Amount:C}");
    }
}
public class NetBankingPayment : Payment
{
    public override void ProcessPayment()
    {
        Console.WriteLine($"Processing net banking payment of {Amount:C}");
    }
}

public interface IMessageSender
{
    void Send(string message);
}

public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}

public class NotificationService
{
    private readonly IMessageSender sender;

    public NotificationService(IMessageSender sender)
    {
        this.sender = sender;
    }

    public void Notify(string message)
    {
        sender.Send(message);
    }
}

public static class Question
{
    public static void Run()
    {
        NotificationService emailNotification =
            new NotificationService(new EmailSender());

        emailNotification.Notify("Order placed successfully");

        NotificationService smsNotification =
            new NotificationService(new SmsSender());

        smsNotification.Notify("Payment successful");
    }
}
