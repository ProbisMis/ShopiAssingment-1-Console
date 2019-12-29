using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShopiAssingment_1
{
    class DataController
    {
        private static readonly HttpClient client = new HttpClient();

        List<Product> ProductList = new List<Product>();

        string PostProduct = "http://dev.shopiconnect.com/api/productImport/ImportDeltaProducts";


        // GET: Data
        public async Task<string> Index()
        {
            ProductList.Clear(); //reset list

            using (var reader = new StreamReader("C:/Users/Burak/source/repos/WebApplication1/WebApplication1/App_Data/sample.csv"))

            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.Delimiter = "|";
                csv.Configuration.RegisterClassMap<ProductMap>(); //mapping Auto
                csv.Configuration.MissingFieldFound = null; //sets missing field to null

                csv.Read();
                csv.ReadHeader(); //skip header

                while (csv.Read())
                {
                    var record = csv.GetRecord<Product>();
                    ProductList.Add(record); //Final list
                }

            }

            string serializedObject = JsonConvert.SerializeObject(new
            {
                ProductList = ProductList,
            });
            return serializedObject;
        }

        // GET: Data/Create
        public async Task<string> Create()
        {
            // client.DefaultRequestHeaders
            //.Accept
            //.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT/Content-Type

            string serializedObject = JsonConvert.SerializeObject(new
            {
                ProductList = ProductList,
            });

            StringContent httpContent = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(PostProduct, httpContent);

            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
