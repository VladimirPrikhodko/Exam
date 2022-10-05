using System.Linq;
using System.Xml.Serialization;

namespace Exam
{
    public class Program
    {
        static void Main(string[] args)
        {
            Predator cat = new Predator(10, "Murka", "Fish", 2);
            Predator tiger = new Predator(5, "Claw", "Meat", 5);

            Herbivore goat = new Herbivore(3, "Bella", "Grass", 3); 
            Herbivore cow = new Herbivore(8, "Burenka", "Hey", 4);

            Omnivore bear = new Omnivore(7, "Miha" ,"DifferentFood", 7);
            Omnivore squirrel = new Omnivore(2, "Shustrik", "Nuts", 1);

            List<Animal> animals = new List<Animal> {cat, tiger, goat, cow, bear, squirrel};

            Console.WriteLine("\tSource: ");
            foreach (var animal in animals)
            {
                animal.PrintAnimal();
            }

            animals.Sort();

            Console.WriteLine("-------------------------------------------------- \n\tAfter sort: ");
            foreach (var animal in animals)
            {
                animal.PrintAnimal();
            }

            Console.WriteLine("-------------------------------------------------- \n\tFirst 5 names: ");
            var first5Names = animals
                .Take(5)
                .Select(x => x.AnimalName);
            foreach (var animalName in first5Names)
            {
                Console.WriteLine(animalName);
            }

            Console.WriteLine("-------------------------------------------------- \n\tLast 3 indices: ");
            var last3Indeces = animals
                .TakeLast(3)
                .Select(x => x.ID);
            foreach (var animalIdx in last3Indeces)
            {
                Console.WriteLine(animalIdx);
            }

            SaveAnimals(animals);
            animals.Clear();
            LoadAnimals(ref animals);

            Console.WriteLine("\n-------------------------------------------------- " +
                "\n\tAfter Save/Clear/Load List: ");
            foreach (var animal in animals)
            {
                animal.PrintAnimal();
            }
        }

        static void SaveAnimals(List<Animal> animals)
        {
            Console.Write("\nInput path to save file (D:\\Animals):");
            string? path = Console.ReadLine();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>));
                using (Stream stream = File.OpenWrite(path))
                {
                    serializer.Serialize(stream, animals);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void LoadAnimals(ref List<Animal> animals)
        {
            Console.Write("\nInput path to load file (D:\\Animals):");
            string? path = Console.ReadLine();

            FileInfo pathInfo = new FileInfo(path);

            if(!pathInfo.Exists)                        // check path
            {
                Console.WriteLine("\nInvalid file path or file not exist!");
                Environment.Exit(-1);
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Animal>));
                using (Stream stream = File.OpenRead(path))
                {
                    animals = (List<Animal>)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
