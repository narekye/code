using MongoDB.Driver;
using System.Threading.Tasks;
namespace sharp.mongoDb.Console
{
    class Program
    {
        private static string connectionString = "mongodb://localhost:27017"; // this can be stored in app.config file as conn string

        static void Main(string[] args)
        {
            MongoClient client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("test");
            GetDatabaseNames(client).GetAwaiter();

            GetCollectionsNames(client).GetAwaiter();
            System.Console.Read();
        }

        private static async Task GetDatabaseNames(MongoClient client)
        {
            using (var cursor = await client.ListDatabasesAsync())
            {
                var databaseDocuments = await cursor.ToListAsync();
                foreach (var databaseDocument in databaseDocuments)
                {
                    System.Console.WriteLine(databaseDocument["name"]);
                }
            }
        }

        private static async Task GetCollectionsNames(MongoClient client)
        {
            using (var cursor = await client.ListDatabasesAsync())
            {
                var dbs = await cursor.ToListAsync();
                foreach (var db in dbs)
                {
                    System.Console.WriteLine("{0} db contains below collections:", db["name"]);

                    IMongoDatabase database = client.GetDatabase(db["name"].ToString());

                    using (var collCursor = await database.ListCollectionsAsync())
                    {
                        var colls = await collCursor.ToListAsync();
                        foreach (var col in colls)
                        {
                            System.Console.WriteLine(col["name"]);
                        }
                    }
                    System.Console.WriteLine();
                }
            }
        }
    }
}
