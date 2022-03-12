using System;

namespace Zoo_Maria_Eganyan
{
    [AnimalDescription("Herbivorous animal,eat grass")]
    class Cow:Animal
    {
         
        public Cow(DateTime bday, int timeofeed,int number) : base("Cow",5,2000)
        {
            Birthday = bday;
            TimeOfFeed = timeofeed;
            FoodType = FoodType.Grass;
            Number = number;
        }
    }
}
