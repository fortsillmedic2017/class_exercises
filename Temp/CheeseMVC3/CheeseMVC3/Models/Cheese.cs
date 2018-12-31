using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC3.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Taste { get; set; }
        public CheeseType Type { get; set; }    //Made in the CheeseType enum Class

        public int CheeseId { get; set; }      //helps make each object unique
        private static int nextId = 1;

        public Cheese()                                //Default Constructor
        {
            CheeseId = nextId;       //This insure every object has a unique Id
            nextId++;                //change nexId by 1 each time
        }
    }
}