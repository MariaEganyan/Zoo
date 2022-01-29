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
            Work();
        }
        private void Work()
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Start();
            Console.ReadKey();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            WorkGuard();
        }
        public void AddAnimal(Animal animal)
        {
            for(int i = 0; i < _cages.Count; i++)
            {
               _cages[i].AddAnimal(animal);
            }
        }
        public void AddCages(Cage cage)
        {
            _cages.Add(cage);
        }
        public void WorkGuard()
        {
            
            foreach (Cage c in _cages)
            {
                Food food =new Food(c.AnimalsOfCage[0].FoodType);
               _guard.FeedAnimals(c,food);
            }
        }
    }
}
