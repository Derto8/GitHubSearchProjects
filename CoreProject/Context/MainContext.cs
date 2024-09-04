using CoreProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Context
{
    public class MainContext : DbContext
    {
        public DbSet<SearchResult> SearchResult { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
