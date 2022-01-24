using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    class Tiger:Animal
    {
        public Tiger(DateTime bday,int sizeofstomach,int timeOfFeed):base("Tiger")
        {
            Birthday = bday;
            SizeOfStomach = sizeofstomach;
            TimeOfFeed = timeOfFeed;
            SaveSize = sizeofstomach;
            Food = Food.Meat;
        }
    }
}
