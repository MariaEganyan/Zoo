using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Zoo_Maria_Eganyan
{
    abstract class Animal
    {
        public Timer timer = new Timer(2000);
        public string Name { get; set; }
        protected DateTime Birthday { get; set; }
        private int _sizeOfStomach;
        protected int SaveSize { get; set; }
        private DateTime _eatingtTime { get; set; }
        public Food Food { get; set; }
        private int _timeOfFeed;
        public int TimeOfFeed
        {
            get
            {
                return _timeOfFeed;
            }
            set
            {
                if (value <= 0)
                {
                    _timeOfFeed = 1;
                }
                else
                {
                    _timeOfFeed = value;
                }
            }
        }
        public int SizeOfStomach
        {
            get
            {
                return _sizeOfStomach;
            }
            set
            {
                if (value <= 0)
                {
                    this._sizeOfStomach = 1;
                }
                else
                {
                    _sizeOfStomach = value;
                }
            }
        }
        public Animal(string name)
        {
            Name = name;
            
        }
        public void Hungry()
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            Console.ReadKey();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SaveSize--;
            Console.WriteLine(SaveSize);
            
        }

        protected int CanEat(Food food)
        {
            if (SaveSize < 0)
            {
                return -1;
            }
            if(DateTime.Now.Second - _eatingtTime.Second >= TimeOfFeed)
            {
                if (food==this.Food)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 2;
            }
        }
        public void Feed(Food food)
        {
            if (CanEat(food) == 1)
            {
                Console.WriteLine("{0} Eat {1}",Name,food);
                _eatingtTime = DateTime.Now;
                SaveSize = SizeOfStomach;
                Hungry();
            }
            else if (CanEat(food) == -1)
            {
                Console.WriteLine("the Animal is dead");
            }
            else if (CanEat(food) == 0)
            {
                Console.WriteLine("Can't eat that");
                Hungry();
            }
            else
            {
                Console.WriteLine("don't need to eat");
                Hungry();
            }
        }
    }
}
