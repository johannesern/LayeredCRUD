using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredCRUD
{
    internal class Controller
    {

        IDAO database;
        IStringIO io;

        public Controller(IDAO database, IStringIO io)
        {
            this.database = database;
            this.io = io;
        }

        public void Start()
        {
            bool isOn = true;

            while(isOn)
            {
                io.Output("Välj vad du vill göra genom att ange en bokstav:\n" +
                          "c - create\n" +
                          "r - read\n" +
                          "u - update\n" +
                          "d - delete\n" +
                          "e - exit");

                string input = io.Input();
                switch (input)
                {
                    case "c":
                        AddProduct();
                        break;
                    case "r":
                        GetProducts();
                        break;
                    case "u":
                        UpdateProduct();
                        break;
                    case "d":
                        DeleteProduct();
                        break;
                    case "e":
                        io.Output("Tack för idag!");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                    default:
                        io.Output("Fel input, försök igen");
                        break;
                }
            }
        }

        public void AddProduct()
        {
            io.Output("Skriv in produktnamn:");
            string name = io.Input();

            int price = 0;
            bool run = true;
            while(run )
            {
                io.Output("Sätt varans pris:");
                bool i = int.TryParse(io.Input(), out price);
                if (i)
                {
                    run = false;                    
                }
                else
                {
                    io.Output("Du måste skriva in en siffra, försök igen");
                    run = true;
                }
            }

            int quantity = 0;
            run = true;
            while (run)
            {
                io.Output("Sätt antal varor:");
                bool i = int.TryParse(io.Input(), out quantity);
                if (i)
                {
                    run = false;
                }
                else
                {
                    io.Output("Du måste skriva in en siffra, försök igen");
                    run = true;
                }
            }

            io.Output("Skriv in en beskrivning:");
            string desc = io.Input();

            var document = new BsonDocument
            {
                {"Name", name},
                {"Price", price},
                {"Quantity", quantity},
                {"Description", desc}
            };           

            try
            {
                database.Create(document);
            }
            catch (Exception ex)
            {
                io.Output(ex.Message);
                io.Input();
            }
        }

        public void GetProducts()
        {
            var products = database.Read();

            foreach (var product in products)
            {
                io.Output(product.ToString());
            }
        }

        public void UpdateProduct()
        {
            io.Output("Ange id för produkten du vill uppdatera");
            string id = io.Input();
            io.Output("Ange nytt pris för produkten");
            string newPrice = io.Input();
            database.UpdatePrice(id, newPrice);
        }

        public void DeleteProduct()
        {
            io.Output("Ange ID för produkten du vill ta bort:");
            string id = io.Input();
            if (!String.IsNullOrWhiteSpace(id))
            {
                try
                {
                    database.Delete(id);
                }
                catch (Exception ex)
                {
                    io.Output($"Kunde inte ta bort {id}\n- Felmeddelande: {ex.Message}");
                }
            }
            else
            {
                io.Output("Felaktigt ID, återgår till menyn\n");
            }
        }
    }
}
