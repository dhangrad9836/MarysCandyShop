namespace MarysCandyShop
{
    internal class DataSeed
    {
        string[] candyNames = { "Rainbow Lillipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamroree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };
        void SeedData()
        {
            //for loop to add the cand names to the products list
            for (int i = 0; i < candyNames.Length; i++)
            {
                products.Add(i, candyNames[i]);
            }
        }
    }
}
