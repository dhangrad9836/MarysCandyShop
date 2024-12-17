using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarysCandyShop
{
    internal class ProductController
    {
        internal List<Product> GetProduct()
        {
            //we initialize an empty list to hold our list of candy
            var products = new List<Product>();

            //try/catch block
            try
            {
                //use StreamReader to read in a file called docPath and store it in a variable called reader
                using (StreamReader reader = new(Configuration.docPath))
                {
                    //when each line is read from the StreamReader in the text file of products.txt it will be stored inside the 'line' variable below
                    var line = reader.ReadLine();


                    //while loop
                    while (line != null)
                    {
                        //after the line of data is stored inside 'line' we will use the Split method seperate out the data every time a comma is found it will be stored inside the parts array
                        string[] parts = line.Split(',');

                        //here we are taking the first part of the 'parts' variable pass it to the Product constructor from the Product class which is the id and parsing the string to an int, also for the .Name and .Price
                        //Extract from parts [0] [1] [2] and store it in product
                        var product = new Product(int.Parse(parts[0]));
                        product.Name = parts[1];
                        product.Price = decimal.Parse(parts[2]);

                        //we need to parse the first parts[0] to an integer as that is the index number which is an int
                        //products.Add(int.Parse(parts[0]), parts[1]);
                        //line is a product from the text file that we use in our docpath of products.txt
                        products.Add(product);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(UserInterface.divide);
            }

            return products;
        }

        //we made accessiblity to 'internal' so it's not viewed as private but internal so it's accessible to other parts
        internal void DeleteProduct(string message)
        {
            Console.WriteLine(message);
        }

        internal void AddProduct()
        {
            var id = GetProduct().Count;
            //user enter input of product name
            Console.WriteLine("Product name:");
            var name = Console.ReadLine();

            //enter Price of product
            Console.WriteLine("Produce price: ");
            var price = decimal.Parse(Console.ReadLine());
            //try/catch
            try
            {
                //you will have to use the StreamWriter class in a using statement
                //true is a bool to append to the file and not override the current content
                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath, true))
                {
                    
                    {
                        //outputFile.WriteLine(product);
                        //here we will store the produce.key which is the index and the produce.value which is the candy string name, we also have a bool of true which will append to the file
                        outputFile.WriteLine($"{id}, {name}, {price}");
                    }
                }
                //output that the products are saved when end of list is reached
                Console.WriteLine("Products saved");
            }
            catch (Exception ex)
            {

                Console.WriteLine("There was an error saving products:" + ex.Message);
            }
        }

        //second AddProduct with different signature take in a list of strings
        internal void AddProduct(List<Product> products)
        {
            //try/catch
            try
            {
                //you will have to use the StreamWriter class in a using statement
                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
                {

                    {
                        foreach(var product in products)
                        {
                            //here it will write a line to the text file
                            outputFile.WriteLine($"{product.Id}, {product.Name}, " +
                                $"{product.Price}");
                        }
                        
                    }
                }
                //output that the products are saved when end of list is reached
                Console.WriteLine("Products saved");
            }
            catch (Exception ex)
            {

                Console.WriteLine("There was an error saving products:" + ex.Message);
            }
        }

        internal void UpdateProduct(string message)
        {
            Console.WriteLine(message);
        }       

        
        
    }//end ProductController()
}
