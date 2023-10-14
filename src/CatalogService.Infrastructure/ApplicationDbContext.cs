using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //    base.OnModelCreating(builder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(ConfigureCategory);
            modelBuilder.Entity<Item>(ConfigureItem);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureCategory(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.HasOne(e => e.ParentCategory).WithMany().HasForeignKey(e => e.ParentCategoryId);
            builder.HasMany(e => e.Items).WithOne(e => e.Category).OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureItem(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(e => e.ItemId);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.CategoryId).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Items).HasForeignKey(e => e.CategoryId);
            builder.Property(e => e.Price).IsRequired();
            builder.Property(e => e.Amount).IsRequired();
        }
    }
}