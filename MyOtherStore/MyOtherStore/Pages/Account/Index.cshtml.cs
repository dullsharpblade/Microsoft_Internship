using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyOtherStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<AccountInfo> listAccounts = new List<AccountInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=myotherstore;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AccountInfo accountInfo = new AccountInfo();
                                accountInfo.user_id = "" + reader.GetInt32(0);
                                accountInfo.username = reader.GetString(1);
                                accountInfo.password = reader.GetString(2);
                                
                                listAccounts.Add(accountInfo);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }


    public class AccountInfo
    {
        public String user_id;
        public String username;
        public String password;
    }
}
