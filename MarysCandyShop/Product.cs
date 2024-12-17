namespace MarysCandyShop;

internal class Product
{
    internal int Id { get; }
    internal string Name { get; set; }
    internal decimal Price { get; set; } 

    //constructor
    public Product(int id)
    {
        Id = id;
    }


    //private string name;

    //internal string Name
    //{
    //    get
    //    {
    //        return name.ToUpper();
    //    }

    //    set
    //    {
    //        //check if input is not empty
    //        if(!string.IsNullOrWhiteSpace(value)) 
    //        {
    //            name = value;
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid name. Must be a non-empty string");
    //        }
    //    }
    //}

    //Get/Set methods
    //internal string GetName()
    //{
    //    return name;
    //}

    //internal void SetName(string value)
    //{
    //    name = value;
    //}
   
}
