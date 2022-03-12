using System;
using System.Collections.Generic;
using System.Timers;
using Zoo_Maria_Eganyan.FeedAnimal;

namespace Zoo_Maria_Eganyan
{
    class Zoo
    {
        private Timer _timer = new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds);
        private List<Cage> _cages { get; set; }
        private IEmployee _guard { get; set; }
       
        public Zoo(IEmployee guard)
        {
            _cages = new List<Cage>();
            _guard = guard;
        }
     
        public void AddCages(Cage cage)
        {
            _cages.Add(cage);
        }
        public void WorkGuard()
        {
            foreach (Cage c in _cages)
            {
                Food food = new Food(c.AnimalsOfCage[0].FoodType);
                food.Weight = c.FeedingBowl.Size;
                try
                {
                    _guard.FeedAnimals(c, food);
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
