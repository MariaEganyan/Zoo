using System;
using System.Threading;

namespace Zoo_Maria_Eganyan
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal tiger = new Tiger(new DateTime(2005, 11, 3), 5, 2);
            Animal Cow = new Cow(new DateTime(2000), 4, 3);
            Guard guard = new Guard("Ashot", "Avagyan");
            Zoo zoo = new Zoo(guard);
            Cage cage = new Cage(2, FoodType.Meat, 6);
            Cage cage1 = new Cage(3, FoodType.Grass, 6);
            cage.AddAnimal(tiger);
            cage1.AddAnimal(Cow);
            zoo.AddCages(cage);
            //zoo.AddCages(cage1);
            int i = 2;
            while (2 >= 0)
            {
                Thread.Sleep(2000);
                zoo.WorkGuard();
                i--;
            }
            
        }
    }
}
