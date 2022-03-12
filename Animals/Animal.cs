using System;
using System.Timers;
using Zoo_Maria_Eganyan.FeedAnimal;
using Zoo_Maria_Eganyan.LogInfo;
using Zoo_Maria_Eganyan.ZOO;
using System.Threading;

namespace Zoo_Maria_Eganyan
{
    abstract class Animal
    {
        private static ILoger _loger;
        public Thread AnimalThread = new Thread(new ParameterizedThreadStart(Hungry));
        private Cage _myCage { get; set; }
        //private Timer _timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
        private int _number;
        private string _name { get; set; }
        protected DateTime Birthday { get; set; }
        private static int _saveSize { get; set; }

        public FoodType FoodType;
        private int _timeOfFeed;
        public int Number
        {
            get
            {
                return this._number;
            }
            set
            {
                if (value < 0)
                {
                    this._number = 0;
                }
                else
                {
                    this._number = value;
                }
            }
        }
        protected int TimeOfFeed
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
        private static int _sizeOfStomach;
        public static int SizeOfStomach
        {
            get
            {
                return _sizeOfStomach;
            }
            set
            {
                if (value <= 0)
                {
                    _sizeOfStomach = 1;
                }
                else
                {
                    _sizeOfStomach = value;
                }
            }
        }
        protected Animal(string name, int sizeofstomach, int time)
        {
            _name = name;
            SizeOfStomach = sizeofstomach;
            _saveSize = sizeofstomach;
            _loger = MyLoger.GetInstance();
            AnimalThread.Start(time);
        }
       
        private static void Hungry(object a)
        {
            while (true)
            {
                _saveSize--;
                Thread.Sleep((int)a);
            }
              
        }
        private AnimalStatus CanEat(Food food)
        {
            if (_saveSize < 0)
            {
                _loger.LogInformation("Animal died");
                return AnimalStatus.Dead;
            }
            if (_saveSize > 0 && _saveSize <= SizeOfStomach / 2)
            {
                if (CheckFood(food) == 1)
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
            if (food.ChackFoodType(this.FoodType))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private bool _eat(Food food)
        {
            if (CanEat(food) == AnimalStatus.Hungry)
            {
                Console.WriteLine("{0} Eat {1}", _name, food.FoodType);
                _saveSize = SizeOfStomach;
                return true;
            }
            else if (CanEat(food) == AnimalStatus.Dead)
            {
                Console.WriteLine("the Animal is dead");
                return false;
            }
            else if (CanEat(food) == AnimalStatus.CannottEat)
            {
                Console.WriteLine("Can't eat that");
                return false;
            }
            else
            {
                Console.WriteLine("don't need to eat");
                return false;
            }
        }
        public void SetCage(Cage cage)
        {
            _myCage = cage;
            _myCage.FoodArived += _food_of_animal_arived;
        }
        private void _food_of_animal_arived(object sender, MyEventArgs e)
        {

            if (_myCage.FeedingBowl.FullOrNot())
            {
                if (_eat(e.Food))
                {
                    _myCage.FeedingBowl.Food.Weight--;
                }
                
            }
        }
    }
}
