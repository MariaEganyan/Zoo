using System;
using System.Collections.Generic;
using Zoo_Maria_Eganyan.FeedAnimal;
using Zoo_Maria_Eganyan.INTERFACES;
using Zoo_Maria_Eganyan.LogInfo;
using Zoo_Maria_Eganyan.ZOO;

namespace Zoo_Maria_Eganyan
{
    class Cage
    {
        private ILoger _logerCage;
        public event EventHandler<MyEventArgs> FoodArived;
        private readonly int _number;
        public List<Animal> AnimalsOfCage { get; set; }
        public IFeedingBowl FeedingBowl { get; set; }
       
        public Cage(int number,FoodType type,int size)
        {
            this._number = number;
            AnimalsOfCage = new List<Animal>();
            _logerCage = MyLoger.GetInstance();
            FeedingBowl = new FeedingBowl(size,type);
           
        }

        public void AddAnimal(Animal animal)
        {
            if (CheckNumber(animal))
            {
                AnimalsOfCage.Add(animal);
                animal.SetCage(this);
            }
        }

        private bool CheckNumber(Animal animal)
        {
            if (animal.Number == _number)
            {
                return true;
            }
            else
            {
                _logerCage.LogError("The numbers of cage and animal do not match");
                return false;
            }
        }
        
        public void AddFood(Food food)
        {
            FeedingBowl.AddFoodIn(food);
            MyEventArgs args = new MyEventArgs();
            args.Food = this.FeedingBowl.Food;
            OnFeedingBowl(args);
        }
        private void OnFeedingBowl(MyEventArgs e)
        {
            FoodArived?.Invoke(this, e);
        }
    }
}
