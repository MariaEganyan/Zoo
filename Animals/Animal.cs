using System;
using System.Timers;
using Zoo_Maria_Eganyan.FeedAnimal;

namespace Zoo_Maria_Eganyan
{
    abstract class Animal
    {
        private Timer _timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
        private int _number;
        private string Name { get; set; }
        protected DateTime Birthday { get; set; }
        private int _sizeOfStomach;
        protected int SaveSize { get; set; }
        public Food Food { get; set; }
        private int _timeOfFeed;
        public int Number
        {
            get
            {
                return this._number;
            }
            set
            {
                if (value < 0 )
                {
                    this._number = 0;
                }
                else
                {
                    this._number = value;
                }
            }
        }
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
        protected Animal(string name, int sizeofstomach)
        {
            Name = name;
            SizeOfStomach = sizeofstomach;
            SaveSize = sizeofstomach;
            Hungry();
        }
        private void Hungry()
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Start();
            Console.ReadKey();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SaveSize--;
            Console.WriteLine(SaveSize);
            
        }
        protected AnimalStatus CanEat(Food food)
        {
            if (SaveSize < 0)
            {
                return AnimalStatus.Dead;
            }
            if(SaveSize>0 && SaveSize<=SizeOfStomach/2)
            {
                if (CheckFood(food)==1)
                {
                    return AnimalStatus.Hungry;
                }
                else
                {
                    return AnimalStatus.CannottEat;
                }
            }
            else
            {
                return AnimalStatus.Satisfied;
            }
        }
        private int CheckFood(Food food)
        {
            if (food == this.Food)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Feed(Food food)
        {
            if (CanEat(food) == AnimalStatus.Hungry)
            {
                Console.WriteLine("{0} Eat {1}",Name,food);
                SaveSize = SizeOfStomach;
            }
            else if (CanEat(food) == AnimalStatus.Dead)
            {
                Console.WriteLine("the Animal is dead");
            }
            else if (CanEat(food) == AnimalStatus.CannottEat)
            {
                Console.WriteLine("Can't eat that");
            }
            else
            {
                Console.WriteLine("don't need to eat");
            }
        }
    }
}
