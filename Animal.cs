using System.Xml.Serialization;

namespace Exam
{
    [XmlInclude(typeof(Omnivore))]
    [XmlInclude(typeof(Predator))]
    [XmlInclude(typeof(Herbivore))]
    public abstract class Animal : IComparable<Animal>
    {
        public int ID { get; set; } = 0;
        public string AnimalName { get; set; } = string.Empty;
        public string FoodType { get; set; } = string.Empty;
        public int FoodPerDay { get; set; } = 0;

        public abstract void CalculateFood(int days);

        public int CompareTo(Animal? other)
        {
            if(FoodPerDay == other?.FoodPerDay)
            {
                return AnimalName.CompareTo(other?.AnimalName);
            }
            else
            {
                if (FoodPerDay < other?.FoodPerDay)
                    return 1;
                else                // if equals - compare by name
                    return -1;  
            }
        }

        public void PrintAnimal()
        {
            Console.WriteLine($"Animal ID: {ID}, Animal Name: {AnimalName}, " +
                $"Food type: {FoodType}, Food per day: {FoodPerDay} \n");
        }
    }
}
