using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    class Tiger:Animal
    {
        public Tiger(DateTime bday,int timeOfFeed):base("Tiger",4)
        {
            Birthday = bday;
            TimeOfFeed = timeOfFeed;
            Food = Food.Meat;
        }
    }
}
