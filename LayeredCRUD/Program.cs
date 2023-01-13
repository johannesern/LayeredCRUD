// See https://aka.ms/new-console-template for more information
using LayeredCRUD;


string connectionString = ""/*File.ReadAllText(@"connection.txt")*/;
string db = "Store";

IDAO database = new MongoDAO(connectionString, db);
IStringIO io = new StringIO();

Controller c = new Controller(database, io);

c.Start();
