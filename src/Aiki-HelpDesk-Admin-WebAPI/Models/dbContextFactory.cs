using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AIKI.CO.HelpDesk.WebAPI.Models
{
    public class dbContextFactory : IDesignTimeDbContextFactory<dbContext>
    {
        public dbContext CreateDbContext(string[] args)
        {
            var cn = String.Format(
                "Host={0};Database=aiki-helpdesk;Username={1};Password={2}",
                "localhost", "postgres", "123456");

            var optionsBuilderObject = new DbContextOptionsBuilder<dbContext>();
            optionsBuilderObject.UseNpgsql(cn);

            return new dbContext(optionsBuilderObject.Options, null, null, null, null);
        }
    }
}
