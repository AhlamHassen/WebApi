using System;

namespace modules
{
    public class Products
    {
        public string Prodname { get; set; }
        public decimal Unitprice { get; set; }
        public string Suppliername { get; set; }

        public Products(string pname, decimal price, string supplier){
            this.Prodname = pname;
            this.Unitprice = price;
            this.Suppliername = supplier;
        }
        
    }
}