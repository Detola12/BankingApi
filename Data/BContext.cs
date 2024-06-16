using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingapi.Models;
using Microsoft.EntityFrameworkCore;

namespace bankingapi.Data
{
    public class BContext : DbContext
    {
        public BContext(DbContextOptions<BContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
    }
}