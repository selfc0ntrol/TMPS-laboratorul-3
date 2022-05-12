using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.MakeCheesePizza();
            Caretaker caretaker = new Caretaker();

            caretaker.History.Push(ingredient.SaveState());

            ingredient.MakeCheesePizza();

            ingredient.RestoreState(caretaker.History.Pop());

            ingredient.MakeCheesePizza();

            Console.Read();
        }
    }

    // Originator
    class Ingredient
    {
        private int cheese = 10;

        public void MakeCheesePizza()
        {
            if (cheese > 0)
            {
                cheese--;
                Console.WriteLine("Facem pizza cu cascaval. Au rămas {0} portii de cascaval", cheese);
            }
            else
                Console.WriteLine("Cascavalul nu este in stoc");
        }

        public IngredientMemento SaveState()
        {
            Console.WriteLine("Salvarea starii. Parametri: {0} portii de cascaval", cheese);
            return new IngredientMemento(cheese);
        }


        public void RestoreState(IngredientMemento memento)
        {
            this.cheese = memento.Сheese;
            Console.WriteLine("Restabilirea starii, comanda anulata. Parametri: {0} portii de cascaval", cheese);
        }
    }

    class IngredientMemento
    {
        public int Сheese { get; private set; }

        public IngredientMemento(int cheese)
        {
            this.Сheese = cheese;
        }
    }

    class Caretaker
    {
        public Stack<IngredientMemento> History { get; private set; }
        public Caretaker()
        {
            History = new Stack<IngredientMemento>();
        }
    }
}