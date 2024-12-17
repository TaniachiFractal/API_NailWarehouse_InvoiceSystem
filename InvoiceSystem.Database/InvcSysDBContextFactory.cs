﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InvoiceSystem.Database
{
    /// <summary>
    /// Генератор <see cref="InvcSysDBContext"/>
    /// </summary>
    public class InvcSysDBContextFactory : IDesignTimeDbContextFactory<InvcSysDBContext>
    {

        InvcSysDBContext IDesignTimeDbContextFactory<InvcSysDBContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InvcSysDBContext>();
            optionsBuilder.UseSqlServer($@"Server=(localdb)\mssqllocaldb;Database=MaslovaInvoiceSystem;Trusted_Connection=True;");
            return new InvcSysDBContext(optionsBuilder.Options);
        }
    }
}
