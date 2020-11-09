using System;
using Newtonsoft.Json;

namespace modules
{
    public class Customer
    {
        [JsonProperty("ID")]
        public int ID { get; set; } 

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        public Customer(){
            this.FirstName = "unknown";
            this.LastName = "unknown";
        }

        public Customer(int id, string firsN, string LastN){
            this.ID = id;
            this.FirstName = firsN;
            this.LastName = LastN;
        }
    }

    
}
