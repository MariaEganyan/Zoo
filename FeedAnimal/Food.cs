using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    public class Food
    {
        public readonly FoodType FoodType;
        private int _weight;
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value < 0)
                    _weight = 0;
                else
                    _weight = value;
            }
        }
        public Food(FoodType food)
        {
            FoodType = food;
            Weight = 0;
        }
        public bool ChackFoodType(FoodType food)
        {
            if (this.FoodType == food)
                return true;
            return false;
        }

    }
}
