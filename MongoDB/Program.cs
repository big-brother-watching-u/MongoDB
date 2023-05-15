using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //await db.CreateCollectionAsync("people"); //создание коллекции people
            //await db.RenameCollectionAsync("people", "users"); //переименовать из people в users
            var collections = await db.ListCollectionsAsync();
            foreach (var collection in collections.ToList())
            {
                Console.WriteLine(collection);
            }

        }
    }
}
