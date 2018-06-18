using LINQ_in_Manhatten.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace LINQ_in_Manhatten
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadJSONFile();
            Console.ReadLine();
        }

        public static void ReadJSONFile()
        {
            // read file into a string and deserialize JSON to a type
            var obj = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText("../../../data.json"));

            // grabs all the neighborhood values and store in allHoods
            var allHoods = from i in obj.features
                           select i.properties.neighborhood;

            // Show it on Console
            foreach (var item in allHoods)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Here, we found all the possible neighborhoods");
            Console.WriteLine("Hit any key to filter out all the neighborhoods that do not have any name");
            Console.ReadLine();
            Console.Clear();

            // Find all neighborhoods that are not empty strings
            var validHoods = from i in allHoods
                             where i != ""
                             select i;

            foreach (var item in validHoods)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("We just found all the neighborhoods that do have names");
            Console.WriteLine("Hit any key to filter out duplicates");
            Console.ReadLine();
            Console.Clear();

            //Filter out the duplicates
            var noDupeHoods = validHoods.Distinct();
            foreach (var item in noDupeHoods)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("We just filtered out all the duplicates");
            Console.WriteLine("We do the same thing again but all in one query");
            Console.ReadLine();
            Console.Clear();

            // Does the other three in one query
            var distinctHood = obj.features .Where(i => i.properties.neighborhood != "")
                                            .GroupBy(g => g.properties.neighborhood)
                                            .Select(m => m.Key);

            foreach (var item in distinctHood)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("We just filtered out all the duplicates");
            Console.WriteLine("We will now do a simple query with lambda");
            Console.ReadLine();
            Console.Clear();

            // using Lambda exp for filtering out empty strings 
            var lambdaHood = allHoods.Where(x => x != "");

            foreach (var item in lambdaHood)
            {
                Console.WriteLine(item);
            }
        }


    }
}
