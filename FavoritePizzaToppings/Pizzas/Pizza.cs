using System;
using System.Collections.Generic;
using System.Text;


namespace FavoritePizzaToppings.Pizzas
{
    class Pizza
    {

        public List<string> toppings { get; set; }

        public int toppingCounter(List<Pizza> pizza, string topping)
        {
            // iterate through each topping on each pizza, each one that matches goes
            // to the sameTopping list, which is ultimately counted
            var sameTopping = new List<string>();

            for (var i = 0; i < pizza.Count; i++)
            {
                for (var j = 0; j < pizza[i].toppings.Count; j++)
                {
                    if (pizza[i].toppings[j] == topping)
                    {
                        sameTopping.Add(topping); 
                    }
                }

            }
            return sameTopping.Count;
        }
    }
}
