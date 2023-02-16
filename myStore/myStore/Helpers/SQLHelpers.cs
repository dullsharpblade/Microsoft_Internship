using myStore.Entities;
using System.Data.SqlClient;

namespace myStore.Helpers
{
    public class SQLHelpers
    {
        private string SqlConnectionString { get; set; }

        public SQLHelpers(string ConnectionString)
        {
            this.SqlConnectionString = ConnectionString;
        }


        public List<Customer> GetCustomersList()
        {
            List<Customer> customerList = new List<Customer>();

            string query = "select * from Customer";
            using (SqlConnection conn = new SqlConnection(this.SqlConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer cust = new Customer()
                    {
                        Customerid = Convert.ToInt32(reader["customerid"]),
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        State = reader["state"].ToString(),
                        Zipcode = reader["zipcode"].ToString(),
                        //Phonenumber = reader["phonenumber"].ToString(),
                        Country = reader["country"].ToString()
                    };

                    customerList.Add(cust);
                }
            }

            return customerList;
        }

    }
}
