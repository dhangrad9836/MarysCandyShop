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
            AddProduct("User chose A");
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


void UpdateProduct(string message)
{
    Console.WriteLine(message);
}

void ViewProduct(string message)
{
    Console.WriteLine(message);
}

void DeleteProduct(string message)
{
    Console.WriteLine(message);
}

void AddProduct(string message)
{
    Console.WriteLine(message);
}

//use method GetMenu and store it inside a string
string GetMenu()
{
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

void PrintHeader()
{
    //Variables
    var title = "Mary's Candy Shop";
    var divide = "---------------------------------";
    var dateTime = DateTime.Now;
    var daysSinceOpening = GetDaysSinceOpening();
    var todaysProfit = 5.5m;
    var targetAchieved = false;
    var menu = GetMenu();

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


Console.ReadLine();
