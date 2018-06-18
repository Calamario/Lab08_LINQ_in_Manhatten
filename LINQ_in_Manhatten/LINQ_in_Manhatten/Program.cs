using LINQ_in_Manhatten.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace LINQ_in_Manhatten
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void ReadJSONFile()
        {
            using (StreamReader file = File.OpenText(@"./data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                Data data = (Data)serializer.Deserialize(file, typeof(Data));
            }
        }
    }
}
