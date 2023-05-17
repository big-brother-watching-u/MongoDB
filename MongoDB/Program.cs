using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.CreateCollections();
            program.CreateDocument();
            Console.ReadKey();
        }
        async void CreateCollections()
        {

            MongoClient client = new MongoClient("mongodb://localhost:27017");//Создать бд
            var db = client.GetDatabase("test");//Получить бд
            //await db.CreateCollectionAsync("people"); //Создать коллекцию people

            //----------------------------------------------------------------------------------------------------------------------------------------

            //await db.RenameCollectionAsync("people", "users"); //Переименовать коллекцию из people в users

            //----------------------------------------------------------------------------------------------------------------------------------------

            //await db.DropCollectionAsync("users");  //Удалить коллекцию users

            //----------------------------------------------------------------------------------------------------------------------------------------

            /*
            var collections = await db.ListCollectionsAsync();
            foreach (var collection in collections.ToList())
            {
                Console.WriteLine(collection); //Получить и выести в консоль список коллекций 
            }
            */
        }
        void CreateDocument()
        {

            MongoClient client = new MongoClient("mongodb://localhost:27017");//Создать бд
            var db = client.GetDatabase("test");//Получить бд
            /*
            BsonDocument doc = new BsonDocument
            {
                {"name","Tom"},

                {"age", 38},

                {"company", new BsonDocument{
                    {"initial", new BsonDocument{ //Создать документ  и в последствии вывести его
                        {"name", "Microsoft"}
                    }}
                }},
                {"languages", new BsonArray{"english", "german", "spanish" } }
            };
            Console.WriteLine(doc["company"]["initial"]["name"]);
            */
            //----------------------------------------------------------------------------------------------------------------------------------------
            /*
            var doc = new BsonDocument
            {
                {"PersonId",1 },
                {"Name","Tom"},
                {"Age", 38},
                {"Email", "tom@somemail.com"},
                {"Company", new BsonDocument{ {"Name" , "Microsoft"}} },
                {"Languages", new BsonArray{"english", "german", "spanish"} }
            };
            Person person = BsonSerializer.Deserialize<Person>(doc);//Создать документ как объект Person
            Console.WriteLine(person.ToJson());
            */
            /*
            PersonAtributes tom = new PersonAtributes { PersonId = 1, Name = "Tom", Language = "Russian", Email = "tom@somemail.com", YearsInTheCompany = 3 };
            Console.WriteLine(tom.ToBsonDocument()); //Создать документ как объект PersonAtributes
            */
            /*
            BsonClassMap.RegisterClassMap<PersonAtributes>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(p => p.Name).SetElementName("username");
            });
            PersonAtributes tom = new PersonAtributes { Name = "Tom", Age = 38 }; //свойство Name будет сопоставляется с полем username.
            Console.WriteLine(tom.ToBsonDocument());
            */
        }
    }
    /*
    class Person
    {
        //класс Person
        public int PersonId { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
        public Company Company { get; set; }
        public List<string> Languages { get; set; } = new List<string>();
    }
    */

    class PersonAtributes
    {
        //Класс PersonAttributes
        [BsonId]//Атрибут ID
        public int PersonId { get; set; }
        public string Name { get; set; } = "";
        [BsonIgnore]//Исключение свойств
        public string Language { get; set; } = "";
        [BsonElement("Login")]//Изменение названия
        public string Email { get; set; } = "";
        [BsonIgnoreIfDefault]//Игнорировать значения по умолчанию
        public int Age { get; set; }
        [BsonRepresentation(BsonType.String)]//Изменение представления свойства
        public int YearsInTheCompany { get; set; }
        [BsonIgnoreIfNull]//Игнорировать null
        public Company Company { get; set; }
    }


    class Company
    {
        public string Name { get; set; }//Привязан к классам Person и Person Attributes
    }


}
