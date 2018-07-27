using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PreQual.Models
{
    public class PreQualContext : DbContext
    {
        public PreQualContext (DbContextOptions<PreQualContext> options)
            : base(options)
        {
        }

        public DbSet<PreQual.Models.Customer> Customer { get; set; }
    }
}
