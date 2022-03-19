using System;
using System.Threading;

namespace Zoo_Maria_Eganyan
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal tiger = new Tiger(new DateTime(2005, 11, 3), 5, 2);
            Animal tiger1 = new Tiger(new DateTime(2000, 10, 5), 4, 3);

            Guard guard = new Guard("Ashot", "Avagyan");
            Zoo zoo = new Zoo(guard);
            Cage cage = new Cage(2, FoodType.Meat, 6);
            Cage cage1 = new Cage(3, FoodType.Grass, 6);
            cage.AddAnimal(tiger);
            cage1.AddAnimal(tiger1);
            zoo.AddCages(cage);
            zoo.AddCages(cage1);



            Thread.Sleep(300);
            zoo.WorkGuard();



        }
    }
}
