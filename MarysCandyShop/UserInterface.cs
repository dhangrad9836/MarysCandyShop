using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarysCandyShop
{
    internal static class UserInterface
    {
        internal const string divide = "---------------------------------";
        internal static void RunMainMenu()
        {
            //set isMenuRunning to true if in the selection user chooses to quit
            //then the isMenuRunning will be false and it will break out of the code block
            var isMenuRunning = true;

            //create instance of ProductsController to use the AddProduct() method
            var productsController = new ProductController();

            while (isMenuRunning)
            {
                PrintHeader();

                //we have the .Trim() to remove any white spaces that the user might have entered
                var usersChoice = Console.ReadLine().Trim().ToUpper();
                var menuMessage = "Press Any Key To Go Back to Menu";

                switch (usersChoice)
                {
                    case "A":
                        productsController.AddProduct();
                        break;
                    case "D":
                        productsController.DeleteProduct("User chose D");
                        break;
                    case "V":
                        ViewProduct("User chose V");
                        break;
                    case "U":
                        productsController.UpdateProduct("User chose U");
                        break;
                    case "Q":
                        //we change the menuMessage to "Goodbye" instead of go back to menu
                        //as we are quitting the program here
                        menuMessage = "Goodbue";
                        //call to SaveProducts() to save the data to file
                        SaveProducts();
                        isMenuRunning = false;
                        break;
                    default:
                        UpdateProduct("Invalid choice. Please choose one of the above.");
                        break;
                }//end switch statement

                Console.WriteLine(menuMessage);
                Console.ReadLine();
                Console.Clear();

            }
        }

        internal static void ViewProduct(string message)
        {
            Console.WriteLine(divide);
            foreach (var product in products)
            {
                Console.WriteLine($"{product}");
            }
        }
        internal static void PrintHeader()
        {
            //Variables
            var title = "Mary's Candy Shop";
            var divide = "---------------------------------";
            var dateTime = DateTime.Now;
            var daysSinceOpening = GetDaysSinceOpening();
            var todaysProfit = 5.5m;
            var targetAchieved = false;
            var menu = GetMenu();   //call to the GetMenu()

            //create a header for the candy shop
            //use string interpolation $ and verbatim strings @
            Console.WriteLine($@"{title}
{divide}
Todays date: {dateTime}
Days since opening: {daysSinceOpening}
Todays profit: {todaysProfit}$
Todays target achieved: {targetAchieved}
{divide}
{menu}");
        }

        //use method GetMenu and store it inside a string
        //it's also private since we are only using it here
        private static string GetMenu()
        {
            //return the string menu when it's called
            return "Choose one option:\n"
             + 'V' + " to view products\n"
             + 'A' + " to add products\n"
             + 'D' + " to delete products\n"
             + 'U' + " to update products\n"
             + 'Q' + " to quit the program\n";
        }
    }
}
