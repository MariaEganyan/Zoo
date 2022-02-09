using System;

namespace Zoo_Maria_Eganyan
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal tiger = new Tiger(new DateTime(2005, 11, 3), 5, 2);
            Guard guard = new Guard("Ashot", "Avagyan");
            Zoo zoo = new Zoo(guard);
            Cage cage = new Cage(2,FoodType.Meat,6);
            cage.AddAnimal(tiger);
            zoo.AddCages(cage);
            zoo.AddAnimal(tiger);
            int i = 2;
            while (i >= 0)
            {
                zoo.WorkGuard();
                i--;
            }
        }
    }
}
