using System;

namespace Zoo_Maria_Eganyan
{
    [AnimalDescription("Predator animal,eat meat")]
    class Tiger:Animal
    {
        public Tiger(DateTime bday,int timeOfFeed,int number):base("Tiger",4,1000)
        {
            Birthday = bday;
            TimeOfFeed = timeOfFeed;
            FoodType = FoodType.Meat;
            Number = number;
        }


    }
    
}
