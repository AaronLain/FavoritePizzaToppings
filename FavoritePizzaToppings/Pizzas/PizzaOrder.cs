using System;
using System.Collections.Generic;
using System.Text;

namespace FavoritePizzaToppings.Pizzas
{
    class PizzaOrder
    {
        public List<string> PizzaToppings { get; set; }

        public string Order { get; set; }

        public PizzaOrder(string order, List<string> pizzaToppings)
        {

            Order = order;
            PizzaToppings = pizzaToppings;

        }
    }
}
