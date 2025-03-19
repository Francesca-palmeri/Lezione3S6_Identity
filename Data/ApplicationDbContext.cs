using AjaxMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace AjaxMvc.Data {

    // la classe ApplicationDbContext eredita da DbContext che è la classe "base" di EFC utilizzata per la gestione del database
    public class ApplicationDbContext  : IdentityDbContext <ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        // costruttore che accetta un ogetto di tipo DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /* rappresenta la tabella Student all'interno del database. Grazie a EFC questa proprietà permette di eseguire query sulla
         * tabella Student come se fosse una collezione di ogetti in memoria 
         */
        public DbSet<Student> Students { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.User).WithMany(u => u.ApplicationUserRole).HasForeignKey(ur => ur.UserId).IsRequired();

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.Role).WithMany(r => r.ApplicationUserRole).HasForeignKey(ur => ur.RoleId).IsRequired();
        }

    }
}




