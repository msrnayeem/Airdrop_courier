using DA.Context;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repos
{
    public class CustomerRepo
    {
        static AirdropContext db;
        static CustomerRepo()
        {
            db = new AirdropContext();
        }

        public static int AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.Id;
        }

        public static bool DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            return db.SaveChanges() > 0;
        }
        public static Customer GetCustomer(int id)
        {
            return db.Customers.Find(id);
        }
        public static List<Customer> GetCustomers()
        {
            return db.Customers.ToList();
        }

        public static bool UpdateCustomer(Customer customer)
        {
            var oldCustomer = db.Customers.Find(customer.Id);
            oldCustomer.Name = customer.Name;
            oldCustomer.Address = customer.Address;
            oldCustomer.Phone = customer.Phone;
            return db.SaveChanges() > 0;
        }   
    }
}
