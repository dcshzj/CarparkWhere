using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarparkWhere.Entities;

namespace CarparkWhere.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration config)
        {
            Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(Configuration.GetConnectionString("CarparkWhere"));
        }

        public DbSet<User> Users { get; set; }
    }
}
