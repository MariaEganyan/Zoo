using System;
using System.Collections.Generic;
using System.Text;
using Zoo_Maria_Eganyan.FeedAnimal;

namespace Zoo_Maria_Eganyan
{
    class Guard:IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guard(string fName,string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
        public void FeedAnimals(Cage cage)
        {
            cage.FeedingBowl= cage.Food;
        }
    }
}
