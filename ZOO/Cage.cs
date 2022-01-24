using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    class Cage
    {
        public int Number { get; set; }
        private List<Animal> animalsOfCage { get; set; }
        public Food Food { get => animalsOfCage[0].Food; }
        public Food FeedingBowl { get; set; }
        public Cage(int number)
        {
            this.Number = number;
            animalsOfCage = new List<Animal>();
        }
        
        public void AddAnimal(Animal animal)
        {
            animalsOfCage.Add(animal);
        }
        public bool CheckNumber(Animal animal)
        {
            if (animal.Number == Number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AnimalsEating()
        {
            foreach(Animal a in animalsOfCage)
            {
                a.Feed(FeedingBowl);
            }
            FeedingBowl = default;
        }
    }
}
