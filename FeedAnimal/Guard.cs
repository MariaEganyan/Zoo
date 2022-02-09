using Zoo_Maria_Eganyan.FeedAnimal;

namespace Zoo_Maria_Eganyan
{
    class Guard : IEmployee
    {
        private readonly string _firstName;
        private readonly string _lastName;
        public Guard(string fName, string lName)
        {
            _firstName = fName;
            _lastName = lName;
        }
        public void FeedAnimals(Cage cage, Food food)
        {
            if (!cage.FeedingBowl.FullOrNot())
            {
                cage.AddFood(food);
            }
        }
    }
}
