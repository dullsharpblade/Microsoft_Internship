using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyOtherStore.Pages.Account
{

    public class LoginModel : PageModel
    {
        public String errorMessage = "";

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("Username") != null)
            {
                string temp = HttpContext.Session.GetString("Username"); 
            }
        }
        
        public void OnPost()
 
        {
            if (string.IsNullOrWhiteSpace(Request.Form["Password"]) || string.IsNullOrWhiteSpace(Request.Form["Username"]))
            {
                errorMessage = "Missing Field";
                return;
            }
            bool isUsernameValid = CheckUsername();
            bool isPasswordValid = false;

            if (isUsernameValid)
            {
                isPasswordValid = CheckPassword();

                if (isPasswordValid)
                {
//                    InitialStatus = true;
                    Message = "Logged in";
                    HttpContext.Session.SetString("Username", Username);
                    Response.Redirect("/Account/Index");
                }
                else
                {
                    Message = "Password is incorrect";
                }
            }
            else
            {
                Message = "User does not exist";
            }
        }
        private bool CheckUsername()
        {
            String connectionString = "Data Source=localhost;Initial Catalog=myotherstore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM acc_info WHERE Username = @username", connection);
                command.Parameters.AddWithValue("@username", Username);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        private bool CheckPassword()
        {
            String connectionString = "Data Source=localhost;Initial Catalog=myotherstore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM acc_info WHERE Password = @password", connection);
                command.Parameters.AddWithValue("@password", Password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

