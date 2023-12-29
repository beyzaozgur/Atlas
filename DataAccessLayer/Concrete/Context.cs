using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context: DbContext
	{
		// connection string - instead of webconfig / appconfig classes in mvc, .net framework

		// add-migration mig1

		// update-database

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=localhost;database=CoreBlogDB;Trusted_Connection=True;TrustServerCertificate=True;");
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Message>()
				.HasOne("Sender")
				.WithMany("SentMessages")
				.HasForeignKey("SenderID")
				.OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne("Receiver")
                .WithMany("ReceivedMessages")
                .HasForeignKey("ReceiverID")
				.OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<About> Abouts { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<BlogRating> BlogRatings { get; set; }
		public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Message { get; set; }

    }
}
