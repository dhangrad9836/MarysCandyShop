﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarysCandyShop
{
    internal class ProductController
    {
        //we made accessiblity to 'internal' so it's not viewed as private but internal so it's accessible to other parts
        internal void DeleteProduct(string message)
        {
            Console.WriteLine(message);
        }

        internal void AddProduct()
        {
            Console.WriteLine("Product name:");
            var product = Console.ReadLine();
            var index = products.Count();
            products.Add(index, product.Trim());
        }

        internal void UpdateProduct(string message)
        {
            Console.WriteLine(message);
        }

        void LoadData()
        {
            //try/catch block
            try
            {
                //use StreamReader to read in a file called docPath and store it in a variable called reader
                using (StreamReader reader = new(Configuration.docPath))
                {
                    //when each line is read from the StreamReader it will be stored inside the 'line' variable below
                    var line = reader.ReadLine();


                    //while loop
                    while (line != null)
                    {
                        //after the line of data is stored inside 'line' we will use the Split method seperate out the data every time a comma is found it will be stored inside the parts array
                        string[] parts = line.Split(',');

                        //we need to parse the first parts[0] to an integer as that is the index number which is an int
                        products.Add(int.Parse(parts[0]), parts[1]);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(divide);
            }


        }

        //save data to file system
        void SaveProducts()
        {
            //try/catch
            try
            {
                //you will have to use the StreamWriter class in a using statement
                using (StreamWriter outputFile = new StreamWriter(Configuration.docPath))
                {
                    //use foreach loop to loop through the products list and store it in the outputFile 
                    //note that we changed our foreach from a string to a var b/c we changed the List from string to a Dictionary which is now a key/value pair so the var picks up as a KeyValuePair, but we then changed to the actual data type KeyValuePair<int, string>
                    foreach (KeyValuePair<int, string> product in products)
                    {
                        //outputFile.WriteLine(product);
                        //here we will store the produce.key which is the index and the produce.value which is the candy string name
                        outputFile.WriteLine($"{product.Key}, {product.Value}");
                    }
                }
                //output that the products are saved when end of list is reached
                Console.WriteLine("Products saved");
            }
            catch (Exception ex)
            {

                Console.WriteLine("There was an error saving products:" + ex.Message);
                Console.WriteLine(divide);
            }


        }
    }//end ProductController()
}
