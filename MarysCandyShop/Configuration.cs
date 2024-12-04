using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarysCandyShop
{
    //this class is static so it cannot be instantiated
    internal static class Configuration
    {
        //the configuration file is stored here and in the code use the qualified path of Configuration.docPath
        internal static string docPath = @"C:\Users\dhang\Desktop\c_repos\MarysCandyShop\MarysCandyShop\products.txt";
    }
}
