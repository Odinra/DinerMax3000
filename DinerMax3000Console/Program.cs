using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business;

namespace DinerMax3000Console
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodMenu summerMenu = new FoodMenu();
            summerMenu.name = "Summer menu";
            summerMenu.AddMenuItem("salmon", "Fresh Salmon", 25.50);
            summerMenu.AddMenuItem("Taco", "Taco Tuesday", 10);
            summerMenu.HospitalDirections = "Right Around the Corner";


            DrinkMenu outsideDrinks = new DrinkMenu();
            outsideDrinks.Disclaimer = "Dont drink and Drive";
            outsideDrinks.AddMenuItem("Whiskey Soda", "Jack and Coke", 10);
            outsideDrinks.AddMenuItem("Beer", "Delicious Blue Moon", 15);


            Order hungryGuestOrder = new Order();
            for(int i = 0; i <= summerMenu.items.Count - 1; i++)
            {
                MenuItem currentItem = summerMenu.items[i];
                hungryGuestOrder.items.Add(currentItem);

            }

            foreach(MenuItem currentItem in outsideDrinks.items)
            {
                hungryGuestOrder.items.Add(currentItem);
            }

            Console.WriteLine("The total is: $" + hungryGuestOrder.Total);

            try
            {
                outsideDrinks.AddMenuItem("Wine", "Can't give this crap away", 0);
            }
            catch(Exception thrownException)
            {
                Console.WriteLine(thrownException.Message);
            }


            Console.ReadKey();

        }
    }
}
