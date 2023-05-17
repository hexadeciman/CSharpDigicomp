using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCCSharp.Models;

namespace MVCCSharp.Data
{
    public class MVCCSharpContext : DbContext
    {
        public MVCCSharpContext (DbContextOptions<MVCCSharpContext> options)
            : base(options)
        {
        }

        public DbSet<MVCCSharp.Models.Book> Book { get; set; } = default!;
    }
}
