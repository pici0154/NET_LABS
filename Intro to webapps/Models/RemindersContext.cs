using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intro_to_webapps.Models
{
    public class RemindersContext : DbContext
    {
        public RemindersContext(DbContextOptions<RemindersContext> options)
            : base(options)
        {
        }

        public DbSet<ReminderItem> ReminderItems { get; set; }
    }
}
