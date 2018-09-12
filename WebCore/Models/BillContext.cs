using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class BillContext: DbContext
    {
        public BillContext(DbContextOptions<BillContext> options)
            : base(options)
        {
        }

        public DbSet<ChargeInfo> ChargeInfo { get; set; } 
        public DbSet<WeekStatistics> WeekStatistics { get; set; }
        public DbSet<UpMonthStatistics> UpMonthStatistics { get; set; }
        
    }
}
