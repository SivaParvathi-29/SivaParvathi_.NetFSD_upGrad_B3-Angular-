using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

public class ProductDAL
{
    private readonly string connectionString;

    public ProductDAL()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        connectionString = config.GetConnectionString("DefaultConnection");
    }

    // INSERT
    public void InsertProduct(Product product)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_InsertProduct", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
            da.SelectCommand.Parameters.AddWithValue("@Category", product.Category);
            da.SelectCommand.Parameters.AddWithValue("@Price", product.Price);

            DataTable dt = new DataTable();
            da.Fill(dt); // executes
        }
    }

    // GET ALL
    public DataTable GetAllProducts()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_GetAllProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }

    // UPDATE
    public void UpdateProduct(Product product)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_UpdateProduct", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@ProductId", product.ProductId);
            da.SelectCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
            da.SelectCommand.Parameters.AddWithValue("@Category", product.Category);
            da.SelectCommand.Parameters.AddWithValue("@Price", product.Price);

            DataTable dt = new DataTable();
            da.Fill(dt);
        }
    }

    // DELETE
    public void DeleteProduct(int id)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_DeleteProduct", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@ProductId", id);

            DataTable dt = new DataTable();
            da.Fill(dt);
        }
    }
}