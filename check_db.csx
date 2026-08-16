using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAMS.Infrastructure.Persistence.Contexts;
using QAMS.Infrastructure.Persistence.Configurations;

var optionsBuilder = new DbContextOptionsBuilder<QamsDbContext>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=qams_db;Username=postgres;Password=postgres123");

using var context = new QamsDbContext(optionsBuilder.Options);

var plans = context.Set<QAMS.Domain.Entities.TestPlan>().Include(p => p.Criteria).ToList();
foreach(var p in plans) {
    Console.WriteLine($"Plan: {p.Name} (Id: {p.Id})");
    foreach(var c in p.Criteria) {
        Console.WriteLine($"  Criteria: {c.Id} - {c.Description} - {c.IsMet}");
    }
}
