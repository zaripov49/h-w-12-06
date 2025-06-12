using Domain.Enntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Editor> Editors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookEditor> BookEditors { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookAuthors)
            .WithOne(ba => ba.Book)
            .HasForeignKey(ba => ba.Isbn);

        modelBuilder.Entity<Book>()
            .HasMany(b => b.BookEditors)
            .WithOne(ba => ba.Book)
            .HasForeignKey(ba => ba.Isbn);

        modelBuilder.Entity<Author>()
            .HasMany(b => b.BookAuthors)
            .WithOne(ba => ba.Author)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<Publisher>()
            .HasMany(b => b.Books)
            .WithOne(ba => ba.Publisher)
            .HasForeignKey(ba => ba.PublisherId);
    }
}
