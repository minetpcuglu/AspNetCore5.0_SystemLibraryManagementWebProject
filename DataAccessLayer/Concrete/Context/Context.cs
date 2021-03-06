using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Context
{
   public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-RQ8KHFA;database=LibraryManagementDb;integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.UserSender)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Message>()
              .HasOne(x => x.ReceiverUser)
              .WithMany(y => y.UserReceiver)
              .HasForeignKey(z => z.ReceiverId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder); //identity migration hata çözümü
        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Punishment> Punishments { get; set; }
        public DbSet<Till> Tills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
