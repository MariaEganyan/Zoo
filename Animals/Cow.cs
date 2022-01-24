using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    class Cow:Animal
    {
        public Cow(DateTime bday, int sizeofstomach, int timeofeed) : base("Cow",7)
        {
            Birthday = bday;
            TimeOfFeed = timeofeed;
            Food = Food.Grass;
        }
    }
}
