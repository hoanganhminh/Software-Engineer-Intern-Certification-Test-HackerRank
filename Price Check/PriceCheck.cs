using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'priceCheck' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING_ARRAY products
     *  2. FLOAT_ARRAY productPrices
     *  3. STRING_ARRAY productSold
     *  4. FLOAT_ARRAY soldPrice
     */

    public static int priceCheck(List<string> products, List<float> productPrices, List<string> productSold, List<float> soldPrice)
    {
        Dictionary<string, float> priceMap = new Dictionary<string, float>();
        int count = 0;

        for (int i = 0; i < products.Count; i++)
        {
            if (!priceMap.ContainsKey(products[i]))
            {
                priceMap.Add(products[i], productPrices[i]);
            }
        }

        for (int j = 0; j < productSold.Count; j++)
        {
            string productName = productSold[j];
            if (priceMap.ContainsKey(productName) && priceMap[productName] != soldPrice[j])
            {
                count++;
            }
        }

        return count;
    }


}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int productsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> products = new List<string>();

        for (int i = 0; i < productsCount; i++)
        {
            string productsItem = Console.ReadLine();
            products.Add(productsItem);
        }

        int productPricesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<float> productPrices = new List<float>();

        for (int i = 0; i < productPricesCount; i++)
        {
            float productPricesItem = Convert.ToSingle(Console.ReadLine().Trim());
            productPrices.Add(productPricesItem);
        }

        int productSoldCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> productSold = new List<string>();

        for (int i = 0; i < productSoldCount; i++)
        {
            string productSoldItem = Console.ReadLine();
            productSold.Add(productSoldItem);
        }

        int soldPriceCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<float> soldPrice = new List<float>();

        for (int i = 0; i < soldPriceCount; i++)
        {
            float soldPriceItem = Convert.ToSingle(Console.ReadLine().Trim());
            soldPrice.Add(soldPriceItem);
        }

        int result = Result.priceCheck(products, productPrices, productSold, soldPrice);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}