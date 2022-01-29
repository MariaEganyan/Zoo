using System;

namespace Zoo_Maria_Eganyan
{
    class Tiger:Animal
    {
        public Tiger(DateTime bday,int timeOfFeed,int number):base("Tiger",4)
        {
            Birthday = bday;
            TimeOfFeed = timeOfFeed;
            FoodType = FoodType.Meat;
            Number = number;
        }
    }
}
