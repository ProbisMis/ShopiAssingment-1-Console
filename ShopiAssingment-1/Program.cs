using System;
using System.Collections.Generic;
using CsvHelper.Configuration;


namespace ShopiAssingment_1
{   
    class Program
    {      
        static void Main(string[] args)
        {
            
            try
            {
                DataController controller = new DataController();
                var result = controller.Index().GetAwaiter().GetResult();
                if (result !=null)
                {
                    result = controller.Create().GetAwaiter().GetResult();
                }
                Console.WriteLine($"\nResult is:  {result}");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey(true);
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine($"Caught ArgumentException: {aex.Message}");
            }
       
        }
    }

    public sealed class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Map(m => m.BaseProductCode).Index(0).Default(null);
            Map(m => m.ColorVariantCode).Index(1).Default(null);
            Map(m => m.Sku).Index(2).Default(null);
            Map(m => m.StockAmount).Index(3).Default(null);
            Map(m => m.Ean).Index(4).Default(null);
            Map(m => m.TaxRate).Index(5).Default(null);
            Map(m => m.Size).Index(6).Default(null);
            Map(m => m.Title).Index(7).Default(null);
            Map(m => m.Description).Index(8).Default(null);
            Map(m => m.MainCategory).Index(9).Default(null);
            Map(m => m.FirstSellingVat).Index(10).Default(null);
            Map(m => m.LastSellingVat).Index(11).Default(null);
            Map(m => m.Color).Index(12).Default(null);
            Map(m => m.Image1Link).Index(13).Default(null);
            Map(m => m.Image2Link).Index(14).Default(null);
            Map(m => m.Image3Link).Index(15).Default(null);
            Map(m => m.Image4Link).Index(16).Default(null);
            Map(m => m.Image5Link).Index(17).Default(null);
            Map(m => m.WebCategory).Index(18).Default(null);
        }
    }

    
}
