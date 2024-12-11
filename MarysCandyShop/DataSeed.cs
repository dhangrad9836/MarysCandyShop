namespace MarysCandyShop
{
    internal class DataSeed
    {
        string[] candyNames = { "Rainbow Lillipops", "Cotton Candy Clouds", "Choco-Caramel Delights", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamroree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rock Candy Crystals" };
        void SeedData()
        {
            var productsController = new ProductController();

            productsController.AddProduct(candyNames.ToList());
        }
    }
}
