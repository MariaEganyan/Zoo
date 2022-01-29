using System.Collections.Generic;
using Zoo_Maria_Eganyan.LogInfo;

namespace Zoo_Maria_Eganyan
{
    public delegate void Action();
    class Cage
    {
        private MyLoger _logerCage;
        public event Action FoodArived;
        private readonly int _number;
        public List<Animal> AnimalsOfCage { get; set; }
        public Food FeedingBowl { get; set; }
        public Cage(int number)
        {
            this._number = number;
            AnimalsOfCage = new List<Animal>();
            _logerCage = MyLoger.GetInstance();
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
            this.FeedingBowl = food;
            FoodArived?.Invoke();
        }
    }
}
