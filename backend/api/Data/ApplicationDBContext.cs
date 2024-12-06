using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Budget>()
                .HasIndex(budget => new { budget.UserId, budget.BudgetLimit })
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasMany(category => category.Expenses)
                .WithOne(expense => expense.Category)
                .HasForeignKey(expense => expense.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public required DbSet<User> User { get; set; }
        public required DbSet<Category> Category { get; set; }
        public required DbSet<Expense> Expense { get; set; }
        public required DbSet<Budget> Budget { get; set; }
    }
}