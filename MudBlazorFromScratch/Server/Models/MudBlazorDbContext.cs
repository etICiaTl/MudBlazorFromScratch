using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MudBlazorFromScratch.Shared;

namespace MudBlazorFromScratch.Server.Models
{
    public class MudBlazorDbContext : DbContext
    {
        public MudBlazorDbContext(DbContextOptions<MudBlazorDbContext> options) : base(options)
        {

        }

        public DbSet<Location> Location { get; set; }
    }
}
