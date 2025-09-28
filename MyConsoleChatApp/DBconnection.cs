using System;
using System.Data.SqlClient; // ✅ For .NET Framework (or install Microsoft.Data.SqlClient in .NET Core/6+)

public class DbConnection
{
    private string ConnectionString { get; set; }
    private SqlConnection SqlConnect { get; set; }

    public DbConnection(string conn)
    {
        ConnectionString = conn;
        SqlConnect = new SqlConnection(ConnectionString); // ✅ Corrected
    }

    public void Open()
    {
        try
        {
            SqlConnect.Open();
            Console.WriteLine("✅ Connection Opened Successfully!");

            // Example query
            string query = "SELECT * FROM Users";

            using (SqlCommand cmd = new SqlCommand(query, SqlConnect))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"UserID: {reader["UserID"]}, Messages: {reader["Messages"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("❌ Error: " + ex.Message);
        }
    }
    public void Close()
    {
        if (SqlConnect.State == System.Data.ConnectionState.Open)
        {
            SqlConnect.Close();
            Console.WriteLine("🔒 Connection Closed!");
        }
    }
}
