ِusing System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billingsystem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            customer c1 = new customer(123, "musbah", 21);


NormalItem item1 = new NormalItem("keyboard", 150, 1);
            MedicalItem item2 = new MedicalItem("panadol", 50, 2);

            invoice inv1 = new invoice(1, c1, item1);
            invoice inv2 = new invoice(2, c1, item2);

            Console.WriteLine("info about the Normal Item");
            Console.WriteLine("Customer Name: " + inv1.customer.name);
            Console.WriteLine("Product: " + inv1.item.productname);
            Console.WriteLine("Price: " + inv1.item.price);
            Console.WriteLine("Quantity: " + inv1.item.quantity);
            Console.WriteLine("Subtotal: " + inv1.item.Getsubtotal());

            Console.WriteLine();

            Console.WriteLine("info about the Medical Item");
            Console.WriteLine("Customer Name: " + inv2.customer.name);
            Console.WriteLine("Product: " + inv2.item.productname);
            Console.WriteLine("Price: " + inv2.item.price);
            Console.WriteLine("Quantity: " + inv2.item.quantity);
            Console.WriteLine("Subtotal: " + inv2.item.Getsubtotal());

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
            else
            {
                this.price = price;
            }

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
    }

    public interface InvoiceItem
    {
        string productname { get; set; }
        decimal price { get; set; }
        int quantity { get; set; }

        decimal Getsubtotal();
    }

    public class NormalItem : InvoiceItem
    {
        public string productname { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        public NormalItem(string productname, decimal price, int quantity)
        {
            this.productname = productname;
            this.price = price;
            this.quantity = quantity;
        }

        public decimal Getsubtotal()
        {
            return (price * quantity) * 1.16m;
        }
    }

    public class MedicalItem : InvoiceItem
    {
        public string productname { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        public MedicalItem(string productname, decimal price, int quantity)
        {
            this.productname = productname;
            this.price = price;
            this.quantity = quantity;
        }

        public decimal Getsubtotal()
        {
            return (price * quantity) * 1.04m;
        }
    }

    public class invoice
    {
        public int invoiceid { get; set; }
        public customer customer { get; set; }
        public InvoiceItem item { get; set; }

        public invoice(int invoiceid, customer customer, InvoiceItem item)
        {
            this.invoiceid = invoiceid;
            this.customer = customer;
            this.item = item;
        }
    }

}

