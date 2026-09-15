using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Billingsystem1.invoiceitem;

namespace Billingsystem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customer c1 = new customer(123, "musbah", 21);
            invoiceitem item1 = new invoiceitem("keyboard", 150, 1);
            invoice inv = new invoice(c1, 1, item1);

            Console.WriteLine("info about the invoice ");
            Console.WriteLine("Customer Name: " + inv.customer.name);
            Console.WriteLine("Product. " + inv.item.productname);
            Console.WriteLine("Price: " + inv.item.price);
            Console.WriteLine("Quantity: " + inv.item.quantity);
            Console.ReadLine();
        }
    }

    public class customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public customer(int id, string name, int age)
        {
            if (age < 0)
            {
                Console.WriteLine("note the age cant be in negative");
            }
            else
            {
                this.age = age;
            }
            this.id = id;
            this.name = name;

        }
    }
    public class invoiceitem
    {
        public string productname { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public invoiceitem(string productname, decimal price, int quantity)
        {
            this.productname = productname;
            if (price < 0)
            {

                Console.WriteLine("note the price given in negative");
                this.price = 0;
            }
            else { this.price = price; }
            if (quantity < 0)
            {
                Console.WriteLine("note:wrong quantity");
                this.quantity = 1;
            }
            else
            {
                this.quantity = quantity;
            }
        }

        public decimal Getsubtotal()
        {
            return price * quantity;
        }
        public class invoice
        {
            public int invoiceid { get; set; }
            public customer customer { get; set; }
            public invoiceitem item { get; set; }
            public invoice(int invoiceid, customer customer, invoiceitem item)
            {
                this.invoiceid = invoiceid;
                this.customer = customer;
                this.item = item;
            }
        }
    }
}
