using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyOtherStore.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public AccountInfo accountInfo = new AccountInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            accountInfo.username = Request.Form["username"];
            accountInfo.password = Request.Form["password"];


            if (AccountInfo.username.Length == 0 || AccountInfo.password.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //save new client in the database
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=myotherstore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO acc_info " +
                                 "(username, password) VALUES " +
                                 "(@username, @password);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@username", accountInfo.username);
                        command.Parameters.AddWithValue("@password", accountInfo.password);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            accountInfo.username = ""; accountInfo.password = ""; 
            successMessage = "New account created";

            Response.Redirect("/Index");
        }
    }
}
