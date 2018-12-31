using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC3.Models
{
    public class CheeseData
    {
        //static List with Cheese class so can be used anywhere in code without creating an object/instance
        static private List<Cheese> cheeses = new List<Cheese>();

        // GetAll
        //Return cheeses from list above
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        //Add
        //take in newCheese and Add it to cheeses list above
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        //GetById
        //.Single() will query the list for a single item where the CheeseId == to id(id = input from form
        //If find more than one CheeseId == id will through an exception

        public static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.CheeseId == id);
        }

        //Remove
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            cheeses.Remove(cheeseToRemove);
        }
    }
}