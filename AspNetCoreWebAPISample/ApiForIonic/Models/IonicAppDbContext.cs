using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForIonic.Models
{
    public class IonicAppDbContext:DbContext
    {
        public IonicAppDbContext(DbContextOptions<IonicAppDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<CreditUnion> CreditUnions { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }

    }
}
