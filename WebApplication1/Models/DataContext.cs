using MySql.Data.MySqlClient;

namespace WebApplication1.Models
{
    public class DataContext
    {
        
        public string ConnectionString { get; set; }


        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }


        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Url> GetUrls()
        {
            List<Url> list = new List<Url>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from Urls", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Url()
                        {
                            Urls = reader["url"].ToString()
                        });
                    }
                }

            }
            return list;
        }

    }
}
