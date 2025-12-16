using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
namespace ConnectionSQLAdoNet;

public class AdoNet
{

    public void SelectAll()
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";
       using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string query = "Select * from Names";
            using(SqlCommand cmd = new SqlCommand(query,con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ID"]}-{reader["Name"]} {reader["Surname"]}");
                    }
                }
            }
        }
    }
    public void DeleteByID(int id)
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";

        using SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        string query = $"Delete from Names where ID={id}";
        using SqlCommand cmd=new SqlCommand(query,con);
        var affectedRows=cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Delete Successfull" : "Delete failed";
        Console.WriteLine(message);
    }
    public void DeleteByName(string name)
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";

        using SqlConnection con=new SqlConnection(connectionString);
        con.Open();
        string query = $"Delete from Names where Name='{name}'";
        using SqlCommand cmd=new SqlCommand( query,con);
        var affectedRows=cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Delete successfull" : "Delete failed";
        Console.WriteLine(message);
    }

    public void InsertValue(string name,string surname)
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";

        using SqlConnection con=new SqlConnection( connectionString);
        con.Open();
        string query = $"Insert into Names values('{name}','{surname}')";
        using SqlCommand cmd = new SqlCommand(query, con);
        var affectedRows=cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Inserted succesful" : "Inserted failed";
        Console.WriteLine(message);
    }
    public void InsertedByName(string name)
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";

        using SqlConnection connection=new SqlConnection(connectionString);
        connection.Open();
        string query = $"Insert into Names(Name) values('{name}')";
        using SqlCommand cmd=new SqlCommand(query,connection);
        var affectedRows = cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Inserted name succesful" : "Inserted failed";
        Console.WriteLine(message);
    }

    public void AddColumn(string tableName, string columnName, string dataType)
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";
        try
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = $"Alter table {tableName} add  {columnName} {dataType}";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Added succesfully");
        }
        catch (Exception ex)
        {
            {
                Console.WriteLine("Added failed"+ex.Message);
            }
        }
    }
    public void DropTable(string tableName)
    {
        string connectionString =
       @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
       Initial Catalog=PizzaMizza2;
       Integrated Security=True;
       TrustServerCertificate=True;";
        try
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = $"Drop table {tableName} ";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Droped table succesfully");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Droped failed"+ex.Message);
        }
    }
}
