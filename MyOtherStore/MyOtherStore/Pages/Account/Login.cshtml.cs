using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyOtherStore.Pages.Account
{
    public class BaseModel : PageModel
    {
        public bool InitialStatus { get; set; } = false;
    }
    public class LoginModel : BaseModel
    {
        private readonly StatusService _statusService;

        public LoginModel(StatusService statusService)
        {
            _statusService = statusService;
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnPost()
        {
            bool isUsernameValid = CheckUsername();
            bool isPasswordValid = false;

            if (isUsernameValid)
            {
                isPasswordValid = CheckPassword();

                if (isPasswordValid)
                {
                    InitialStatus = true;
                    Message = "Logged in";
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

