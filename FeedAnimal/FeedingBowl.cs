using System;
using Zoo_Maria_Eganyan.INTERFACES;

namespace Zoo_Maria_Eganyan.FeedAnimal
{
    class FeedingBowl:IFeedingBowl
    {
        public FoodType Type { get; set; }
        public Food Food { get; set; }
        private int _size;

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value < 0)
                {
                    _size = 0;
                }
                else
                {
                    _size = value;
                }
            }
        }

        public FeedingBowl(int size, FoodType type)
        {
            Type = type;
            Size = size;
            Food = new Food(Type);
        }

        public bool FullOrNot()
        {
            if(Food.Weight>=Size/2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddFoodIn(Food food)
        {
            Food = food;
        }
    }
}
