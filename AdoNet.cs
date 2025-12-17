using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
namespace ConnectionSQLAdoNet;

public class AdoNet
{
    private readonly string _connectionString =
        @"Data Source=DESKTOP-ET5TVFM\SQLEXPRESS;
        Initial Catalog=PizzaMizza2;
        Integrated Security=True;
        TrustServerCertificate=True;";

    public void SelectAll(string tableName)
    {
        using SqlConnection con = new SqlConnection(_connectionString);
        con.Open();

        string query = $"SELECT * FROM {tableName}";
        using SqlCommand cmd = new SqlCommand(query, con);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i)}: {reader[i]} | ");
            }
            Console.WriteLine();
        }
    }



    public void DeleteByID(int id)
    {

        using SqlConnection con = new SqlConnection(_connectionString);
        con.Open();
        string query = $"Delete from Names where ID={id}";
        using SqlCommand cmd=new SqlCommand(query,con);
        var affectedRows=cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Delete Successfull" : "Delete failed";
        Console.WriteLine(message);
    }
    public void DeleteByName(string name)
    {
       
        using SqlConnection con=new SqlConnection(_connectionString);
        con.Open();
        string query = $"Delete from Names where Name='{name}'";
        using SqlCommand cmd=new SqlCommand( query,con);
        var affectedRows=cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Delete successfull" : "Delete failed";
        Console.WriteLine(message);
    }
    public void InsertValue(string name,string surname)
    {
    

        using SqlConnection con=new SqlConnection(_connectionString);
        con.Open();
        string query = $"Insert into Names values('{name}','{surname}')";
        using SqlCommand cmd = new SqlCommand(query, con);
        var affectedRows=cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Inserted succesful" : "Inserted failed";
        Console.WriteLine(message);
    }
    public void InsertedByName(string name)
    {


        using SqlConnection connection=new SqlConnection(_connectionString);
        connection.Open();
        string query = $"Insert into Names(Name) values('{name}')";
        using SqlCommand cmd=new SqlCommand(query,connection);
        var affectedRows = cmd.ExecuteNonQuery();
        string message = affectedRows > 0 ? "Inserted name succesful" : "Inserted failed";
        Console.WriteLine(message);
    }

    public void AddColumn(string tableName, string columnName, string dataType)
    {

        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
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

        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            string query = $"Drop table {tableName} ";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Droped table succesfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Droped failed" + ex.Message);
        }
    }
    public void UpdateTableByName(string tableName,string newname,string oldname)
    {

        try
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();

            string query = $"UPDATE {tableName} SET Name = '{newname}' WHERE Name = '{oldname}'";
            using SqlCommand cmd = new SqlCommand(query, conn);

            int rowsAffected = cmd.ExecuteNonQuery();
            string message = rowsAffected > 0 ? "Updated succesfully" : "Updated failed,not found";
            Console.WriteLine(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Update failed: " + ex.Message);
        }
    }

    public void TruncateTable(string tableName)
    {
        try
        {
            using SqlConnection conn=new SqlConnection(_connectionString);
            conn.Open();

            string query=$"TRUNCATE TABLE {tableName}";
            using SqlCommand cmd = new SqlCommand(query, conn);
            var affectedRows = cmd.ExecuteNonQuery();
            string message=affectedRows>-2? "Truncated succesfully" : "Truncated failed";
            Console.WriteLine(message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Truncated failed: "+ex.Message);
        }
    }
}
