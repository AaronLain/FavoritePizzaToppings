using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FavoritePizzaToppings.Pizzas;
using Microsoft.VisualBasic.CompilerServices;

namespace FavoritePizzaToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read our Json file and convert it to list
            var json = File.ReadAllText("../../../pizzas.json");

            var pizzas = JsonSerializer.Deserialize<List<Pizza>>(json);

            var pizza = new Pizza();

            // Create a new list and populate it with the toppings from the pizzas
            var uToppings = new List<string>();

            var allOrders = new List<PizzaOrder>();


            for (var i = 0; i < pizzas.Count; i++)
            {
                var toppings = new List<string>();

                for (var j = 0; j < pizzas[i].toppings.Count; j++)
                {
                    toppings.Add(pizzas[i].toppings[j]);
                }

                var order = new PizzaOrder("pizza" + $"{i + 1}", toppings);

                allOrders.Add(order);
            }

            var someOrder = allOrders.GetRange(0, 20);

            for (var i = 0; i < pizzas.Count; i++)
            {
                foreach (var topping in pizzas[i].toppings)
                {
                    uToppings.Add(topping);
                }
            }

            // Create a new list of unique toppings and then create new instatiation of pizza
            var uniqueToppings = uToppings.Distinct().ToList();

            // Create a new dictionary to store our toppings and their counts.
            var toppingCounts = new Dictionary<string, int>();

  
            // Iterate over our unique topping list and apply the toppingCounter method
            // which returns the count of each topping in the pizzas list
            // add the topping name as the key and the count as the value to our toppingCounts dictionary
            foreach (var topping in uniqueToppings)
            {
                var count = pizza.toppingCounter(pizzas, topping);
                toppingCounts.Add($"{topping}", count);
            }

            // use LINQ to sort the dictionary by DESCENDING values, only store the first 20
            var sortedToppings = (from topping in toppingCounts 
                                  orderby topping.Value descending 
                                  select topping).Take(20);

            // print our newly sorted, counted list
            foreach (var (topping, count) in sortedToppings)
            {
                Console.WriteLine($"{topping} was ordered {count} times.\r\n");
            };

        }
    }
}
