namespace Exam
{
    [Serializable]
    public class Omnivore : Animal
    {
        public Omnivore() { }

        public Omnivore(int id, string name, string type, int count)
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
