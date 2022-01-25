using System;

namespace Zoo_Maria_Eganyan
{
    class Cow:Animal
    {
        public Cow(DateTime bday, int sizeofstomach, int timeofeed,int number) : base("Cow",7)
        {
            Birthday = bday;
            TimeOfFeed = timeofeed;
            Food = Food.Grass;
            Number = number;
        }
    }
}
