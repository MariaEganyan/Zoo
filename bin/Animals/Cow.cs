using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    class Cow:Animal
    {
        public Cow(DateTime bday, int sizeofstomach, int timeofeed) : base("Cow")
        {
            Birthday = bday;
            SizeOfStomach = sizeofstomach;
            TimeOfFeed = timeofeed;
            SaveSize = sizeofstomach;
            Food = Food.Grass;
        }
    }
}
