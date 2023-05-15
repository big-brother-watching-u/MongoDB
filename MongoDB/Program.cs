using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.DB();
            Console.ReadKey();
        }
        async void DB()
        {

            MongoClient client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("test");
            //await db.CreateCollectionAsync("people"); //создать коллекции people
            //----------------------------------------------------------------------------------------------------------------------------------------

            //await db.RenameCollectionAsync("people", "users"); //переименовать коллекцию из people в users
            //----------------------------------------------------------------------------------------------------------------------------------------

            //await db.DropCollectionAsync("users");  //удалить коллекцию users
            //----------------------------------------------------------------------------------------------------------------------------------------

            /*
            var collections = await db.ListCollectionsAsync();
            foreach (var collection in collections.ToList())
            {
                Console.WriteLine(collection); //Получение и вывод в консоль списка коллекций 
            }
            */
            //----------------------------------------------------------------------------------------------------------------------------------------

            /*
            BsonDocument doc = new BsonDocument
            {
                {"name","Tom"},

                {"age", 38},

                {"company", new BsonDocument{
                    {"initial", new BsonDocument{ //Создание документа  и его последующий вывод
                        {"name", "Microsoft"}
                    }}
                }},
                {"languages", new BsonArray{"english", "german", "spanish" } }
            };
            Console.WriteLine(doc["company"]["initial"]["name"]);
            */
            //----------------------------------------------------------------------------------------------------------------------------------------


        }
    }
    class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
    }
    class Company
    {
        public string Name { get; set; }
    }
}
