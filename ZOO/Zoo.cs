using System;
using System.Collections.Generic;
using System.Timers;
using Zoo_Maria_Eganyan.FeedAnimal;

namespace Zoo_Maria_Eganyan
{
    public delegate void Worker();
    class Zoo
    {
        private Timer _timer = new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds);
        private List<Cage> Cages { get; set; }
        private IEmployee Guard { get; set; }
       
        public Zoo(IEmployee guard)
        {
            Cages = new List<Cage>();
            Guard = guard;
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
            for(int i = 0; i < Cages.Count; i++)
            {
                if (Cages[i].CheckNumber(animal))
                {
                    Cages[i].AddAnimal(animal);
                }
            }
        }
        public void AddCages(Cage cage)
        {
            Cages.Add(cage);
        }
        public void WorkGuard()
        {
            foreach (Cage c in Cages)
            {
               Guard.FeedAnimals(c);
            }
        }

        public void WorkZoo()
        {
            foreach (Cage c in Cages)
            {
                c.Event += new Worker(WorkGuard);
                c.AnimalsEating();
            }
        }
    }
}
