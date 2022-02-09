using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan.INTERFACES
{
    interface IFeedingBowl
    {
        public int Size { get; set; }
        public Food Food { get; set; }
        public bool FullOrNot();
        public void AddFoodIn(Food food);
    }
}
