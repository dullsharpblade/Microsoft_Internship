using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using myStore.Entities;
using myStore.Helpers;


namespace myStore.Pages
{
    public class CustomersModel : PageModel
    {
        public readonly IConfiguration _configuration;
        public CustomersModel (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<Customer> Customers { get; set; }


        public void OnGet()
        {
            // Mapping the configuration from appsettings.json
            string myStoreConnection = _configuration.GetConnectionString("MyStoreConnectionString");

            LoadCustomer(myStoreConnection);
        }

        public void LoadCustomer(string ConnectionString)
        {
            SQLHelpers sqlHelpers = new SQLHelpers(ConnectionString);

            Customers = sqlHelpers.GetCustomersList();
        }
    }
}
