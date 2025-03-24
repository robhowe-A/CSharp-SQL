/*
 * Description: This script connects to a MySQL server via connection string.
 * Date: 3-24-2025
 * Author: Robert Howell
 */


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