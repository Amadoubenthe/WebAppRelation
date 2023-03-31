using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security;
using WebAppRelation.Models;

namespace WebAppRelation.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>(o =>
            {
                o.HasKey(c => c.Id);

                /*o.HasOne(p => p.Student)
                .WithMany(p => p.Absences)
                .HasForeignKey(e => e.StudentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

                o.HasOne(p => p.SessionCourse)
                .WithMany(p => p.Absences)
                .HasForeignKey(e => e.SessionCourseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);*/
            });
 
        }
    }
}
