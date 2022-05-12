using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject TomatoPizza = new Subject("TomatoPizza", 100, "Epuizat.");
            Observer user1 = new Observer("Anastasia", TomatoPizza);
            Observer user2 = new Observer("Ana", TomatoPizza);


            Console.WriteLine(" TomatoPizza starea: " + TomatoPizza.getAvailability());
            Console.WriteLine();
            TomatoPizza.setAvailability("Disponibil");
            Console.Read();
        }
    }
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
    public class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string ProductName { get; set; }
        private int ProductPrice { get; set; }
        private string Availability { get; set; }
        public Subject(string productName, int productPrice, string availability)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Availability = availability;
        }

        public string getAvailability()
        {
            return Availability;
        }
        public void setAvailability(string availability)
        {
            this.Availability = availability;
            Console.WriteLine(" Disponibilitatea s-a schimbat de la Epuizat la disponibil.");
            NotifyObservers();
        }
        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine(" A fost adaugat un client: " + ((Observer)observer).UserName);
            observers.Add(observer);
        }
        public void AddObservers(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            Console.WriteLine(" Numele produsului:"
                            + ProductName + ",Pretul produsului: "
                            + ProductPrice + ",disponibil pentru comanda.Anuntam clientii.");
            Console.WriteLine();
            foreach (IObserver observer in observers)
            {
                observer.update(Availability);
            }
        }
    }
    public interface IObserver
    {
        void update(string availability);
    }
    public class Observer : IObserver
    {
        public string UserName { get; set; }

        public Observer(string userName, ISubject subject)
        {
            UserName = userName;
            subject.RegisterObserver(this);
        }

        public void update(string availabiliy)
        {
            Console.WriteLine(" Salut " + UserName + ",produs " + availabiliy + " pentru comanda.");
        }
    }
}