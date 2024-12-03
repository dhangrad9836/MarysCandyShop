//using statements
using System.Collections.Generic;

//save data to filesystem
string docPath = @"C:\Users\dhang\Desktop\c_repos\MarysCandyShop\MarysCandyShop\history.txt";

string[] candyNames = { "Rainbow Lillipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamroree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };
//Dictonary of products we will add the candynames here and have an index
var products = new Dictionary<int, string>();

//function call to SeedData to populate the products array
//SeedData();
var divide = "---------------------------------";

if (File.Exists(docPath))
{
    LoadData();
}

//set isMenuRunning to true if in the selection user chooses to quit
//then the isMenuRunning will be false and it will break out of the code block
var isMenuRunning = true;


while (isMenuRunning)
{
    PrintHeader();

    //we have the .Trim() to remove any white spaces that the user might have entered
    var usersChoice = Console.ReadLine().Trim().ToUpper();
    var menuMessage = "Press Any Key To Go Back to Menu";

    switch (usersChoice)
    {
        case "A":
            AddProduct();
            break;
        case "D":
            DeleteProduct("User chose D");
            break;
        case "V":
            ViewProduct("User chose V");
            break;
        case "U":
            Console.WriteLine("User chose U");
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

//methods
//manual entered data from the candyNames array to the seedData method
void SeedData()
{
    //for loop to add the cand names to the products list
    for (int i = 0; i < candyNames.Length; i++)
    {
        products.Add(i, candyNames[i]);
    }
}
void UpdateProduct(string message)
{
    Console.WriteLine(message);
}

void ViewProduct(string message)
{
    Console.WriteLine(divide);
    foreach (var product in products)
    {
        Console.WriteLine($"{product}");
    }
}

void DeleteProduct(string message)
{
    Console.WriteLine(message);
}

void AddProduct()
{
    Console.WriteLine("Product name:");
    var product = Console.ReadLine();
    var index = products.Count();
    products.Add(index, product.Trim());
}

//use method GetMenu and store it inside a string
string GetMenu()
{
    //return the string menu when it's called
    return "Choose one option:\n"
     + 'V' + " to view products\n"
     + 'A' + " to add products\n"
     + 'D' + " to delete products\n"
     + 'U' + " to update products\n"
     + 'Q' + " to quit the program\n";
}

int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    TimeSpan timeDifference = DateTime.Now - openingDate;

    return timeDifference.Days;
}

//save data to file system
void SaveProducts()
{
    //you will have to use the StreamWriter class in a using statement
    using (StreamWriter outputFile = new StreamWriter(docPath))
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

void PrintHeader()
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

void LoadData()
{
    //use StreamReader to read in a file called docPath
    using (StreamReader reader = new(docPath))
    {
        //when each line is read from the StreamReader it will be stored inside the 'line' variable below
        var line = reader.ReadLine();
        

        //while loop
        while(line != null)
        {
            //after the line of data is stored inside 'line' we will use the Split method seperate out the data every time a comma is found it will be stored inside the parts array
            string[] parts = line.Split(',');

            products.Add(int.Parse(parts[0]), parts[1]);
            line = reader.ReadLine();
        }
    }
}





Console.ReadLine();
