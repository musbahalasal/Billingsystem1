using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billingsystem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customer c1 = new customer();
            c1.id = 123;
            c1.name = "musbah";
            c1.age = 21;
            invoiceitem item1 = new invoiceitem();
            item1.productname = "keyboard";
            item1.price = 150;
            item1.quantity = 1; 
            invoice inv =new invoice();
            inv.invoiceid = 1;
            inv.item= item1;
            inv.customer = c1;
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
        public int id;
        public string name;
        public int age;
    }
    public class invoiceitem
    {
        public string productname;
        public decimal price;
        public int quantity;
    }
    public class invoice
    {
        public customer customer;
        public int invoiceid;
        public invoiceitem item;
    }
}
