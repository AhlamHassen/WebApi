using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace webApi
{
    [ApiController]
    [Route("[controller]")] 
    public class SqlConController 
    {
        [HttpGet]
        public string TestConnection(){
            string connectionString = @"Data Source=bikestoresdb.c3raologixkl.us-east-1.rds.amazonaws.com;
            Initial Catalog=SampleDB;User ID=admin; Password=abcd1234";
            SqlConnection con = new SqlConnection(connectionString);
            
            string queryString = "Select * from Customer";

            SqlCommand command = new SqlCommand(queryString, con);
            con.Open();

            string result = "";

            using(SqlDataReader reader = command.ExecuteReader()){
                while(reader.Read())
                {
                    result += reader[0] + "|" + reader[1] + '\n'; 
                }
            }

            return result;
        }
        
    }
}