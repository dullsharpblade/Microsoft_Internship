using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using myStore.Entities;
using myStore.Helpers;


namespace myStore.Pages
{
    public class ProductModel : PageModel
    {
        public readonly IConfiguration _configuration;
        public ProductModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Product> Products { get; set; }


        public void OnGet()
        {
            // Mapping the configuration from appsettings.json
            string myStoreConnection = _configuration.GetConnectionString("MyStoreConnectionString");

            LoadProduct(myStoreConnection);
        }

        public void LoadProduct(string ConnectionString)
        {
            SQLHelpers sqlHelpers = new SQLHelpers(ConnectionString);

            Products = sqlHelpers.GetProductsList();
        }
    }
}
