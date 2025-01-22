

MySql.Data.MySqlClient.MySqlConnection conn;
string myConnectionString;

myConnectionString = "Server=[REDACTED];port=3306;Database=[REDACTED];user=[REDACTED];password=[REDACTED];";

try
{
    conn = new MySql.Data.MySqlClient.MySqlConnection();
    conn.ConnectionString = myConnectionString;
    conn.Open();
    Console.WriteLine("Hello World?");
}
catch (MySql.Data.MySqlClient.MySqlException ex)
{
    Console.WriteLine(ex.Message);
}