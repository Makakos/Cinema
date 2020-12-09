using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Services;
using Cinema.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Film> Films { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

      



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());


            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "User",
                NormalizedName = "USER"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "Makakos",
                NormalizedUserName = "MAKAKOS",
                Email = "maximgaber65@gmail.com",
                NormalizedEmail = "MAXIMGABER65@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "qwerty1337"),
                PhoneNumber = "+380974675806",
                SecurityStamp = string.Empty
            });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });


        }

    }



    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasOne(x => x.User).WithMany(y => y.Tickets).HasForeignKey(z => z.UserId);
            builder.HasOne(x => x.Session).WithMany(y => y.Tickets).HasForeignKey(z => z.SessionId);
        }
    }

    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasOne(x => x.Film).WithMany(y => y.Sessions).HasForeignKey(z => z.FilmId);
        }
    }
}
