using System;

namespace modules
{
    public class Customer
    {
        public int ID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customer(int id, string firsN, string LastN){
            this.ID = id;
            this.FirstName = firsN;
            this.LastName = LastN;
        }
    }

    
}
