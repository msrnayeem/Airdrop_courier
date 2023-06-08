using DA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Context
{
    public class AirdropContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
    }
}
