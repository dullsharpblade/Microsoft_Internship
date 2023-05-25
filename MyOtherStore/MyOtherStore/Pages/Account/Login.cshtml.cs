using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyOtherStore.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }
        public bool InitialStatus { get; set; } = false;

        public void OnPost()
        {
            bool isUsernameValid = CheckUsername();
            bool isPasswordValid = false;

            if (isPasswordValid)
            {
                isPasswordValid = CheckPassword();

                if (isPasswordValid)
                {
                    InitialStatus = true;
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
                command.Parameters.AddWithValue("@usename", Username);
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
                SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM acc_info WHERE Password = @pasword", connection);
                command.Parameters.AddWithValue("@password", Password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}

