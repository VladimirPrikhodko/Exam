namespace Exam
{
    [Serializable]
    public class Predator : Animal
    {
        public Predator() { }

        public Predator(int id, string name, string type, int count)
        {
            ID = id;
            AnimalName = name;
            FoodType = type;    
            FoodPerDay = count;
        }

        public override void CalculateFood(int days)
            => Console.WriteLine($"To feed the Animal {days} days need {FoodPerDay * days} KG of {FoodType}");

    }
}
