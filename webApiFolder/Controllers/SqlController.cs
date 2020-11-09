using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using modules;

namespace webApi
{
    [ApiController]
    [Route("[controller]")] 
    public class SqlConController 
    {
        List<Customer> customers = new List<Customer>();
        List<Products> products = new List<Products>();
        
        [HttpGet]
        public List<Products> TestConnection(){
            string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;
            Initial Catalog=SampleDB;User ID=admin; Password=abcd1234";
            SqlConnection con = new SqlConnection(connectionString);
            
            string queryString = "Select p.ProductName, o.UnitPrice, s.CompanyName from ((Product p inner join Supplier s on p.supplierId = s.id) inner join OrderItem o on p.Id = o.ProductId)";

            SqlCommand command = new SqlCommand(queryString, con);
            con.Open();

            string result = "";

            using(SqlDataReader reader = command.ExecuteReader()){
                while(reader.Read())
                {
                    result += reader[0] + "|" + reader[1] + '\n'; 
                    products.Add(
                        new Products(reader[0].ToString(), (decimal)reader[1], reader[2].ToString())
                    );
                }
            }

            return products;
        }

        [HttpGet("Delete")]
        public string delete(){
            string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;
            Initial Catalog=SampleDB;User ID=admin; Password=abcd1234";

            SqlConnection con = new SqlConnection(connectionString);

            string queryString = "delete from Customer where Id=90";

            SqlCommand command = new SqlCommand(queryString, con);
            con.Open();
            try{
                var result = command.ExecuteNonQuery();
                return result.ToString();
            }catch(SqlException sq){
                return "can not delete" + sq.Message;
            }
            

            
            
        }
        
    }
}