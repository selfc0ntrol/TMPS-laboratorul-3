using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Select Payment Type : CreditCard or Cash");
            string PaymentType = Console.ReadLine();
            Console.WriteLine("Payment type is : " + PaymentType);
            Console.WriteLine("\nPlease enter Amount to Pay : ");

            double Amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Amount is : " + Amount);
            PaymentContext context = new PaymentContext();

            if ("creditcard".Equals(PaymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                context.SetPaymentStrategy(new CreditCardPaymentStrategy());
            }
            else if ("cash".Equals(PaymentType, StringComparison.InvariantCultureIgnoreCase))
            {
                context.SetPaymentStrategy(new CashPaymentStrategy());
            }
            context.Pay(Amount);
            Console.ReadKey();
        }
    }
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Customer pays " + amount + " MD using Credit Card");
        }
    }
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Customer pays " + amount + " MD by Cash");
        }
    }
    public class PaymentContext
    {
        private IPaymentStrategy PaymentStrategy;
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            this.PaymentStrategy = strategy;
        }
        public void Pay(double amount)
        {
            PaymentStrategy.Pay(amount);
        }
    }
}