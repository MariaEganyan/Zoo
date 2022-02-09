using System;
using System.Timers;
using Zoo_Maria_Eganyan.FeedAnimal;
using Zoo_Maria_Eganyan.LogInfo;
using Zoo_Maria_Eganyan.ZOO;

namespace Zoo_Maria_Eganyan
{
    abstract class Animal
    {
        private ILoger _loger;
        private Cage _myCage { get; set; }
        private Timer _timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
        private int _number;
        private string _name { get; set; }
        protected DateTime Birthday { get; set; }
        private int _saveSize { get; set; }
        //ստեղ մի հատ հարց ա առաջացել եթե ես ուզում եմ որ իմ կենդանու foodtype-ը 
        //լինի readonly ես իրան ստեղ չեմ կարում հայտարարեմ ու օրինակ tiger-ի կանստրուկտրում 
        //կանչեմ դրա համար ամեն կենդանում մեջ իրանը պետքա ունենամ բայց էտ դեպքում էլ կոդի կրկնություն
        //կլինի չէ էտ պահը ոնց ա ճիշտ անել 
        public  FoodType FoodType;
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
        private int _sizeOfStomach;
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
            _name = name;
            SizeOfStomach = sizeofstomach;
            _saveSize = sizeofstomach;
            _loger = MyLoger.GetInstance();
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
            _saveSize--;
            if (_saveSize < SizeOfStomach / 2)
            {
                _loger.LogWarning("Animal will be dead");
            }
        }
        private AnimalStatus CanEat(Food food)
        {
            if (_saveSize < 0)
            {
                _loger.LogInformation("Animal died");
                return AnimalStatus.Dead;
            }
            if(_saveSize>0 && _saveSize<=SizeOfStomach/2)
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
            if (food.ChackFoodType(this.FoodType))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        
        private void _eat(Food food)
        {
            if (CanEat(food) == AnimalStatus.Hungry)
            {
                Console.WriteLine("{0} Eat {1}",_name,food.FoodType);
                _saveSize = SizeOfStomach;
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
        public void SetCage(Cage cage)
        {
            _myCage = cage;
            _myCage.FoodArived += _food_of_animal_arived;
        }
        private void _food_of_animal_arived(object sender,MyEventArgs e)
        {
            Food food = _myCage.FeedingBowl.Food;
            if (_myCage.FeedingBowl.FullOrNot())
            {
                _eat(food);
                _myCage.FeedingBowl.Food.Weight--;
            }
        }
    }
}
