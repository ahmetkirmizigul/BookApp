using BookApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BookApp.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<BookWithCategory> BooksWithCategories { get; set; }//Mapleme
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookWithCategory>().HasNoKey();

        base.OnModelCreating(modelBuilder);   
    }

    public void AddBook(Book book)
    {
        Database.ExecuteSqlRaw("EXEC AddBook @Title, @Author, @Price, @Stock, @CategoryID",
            new SqlParameter("@Title", book.Title),
            new SqlParameter("@Author", book.Author),
            new SqlParameter("@Price", book.Price),
            new SqlParameter("@Stock", book.Stock),
            new SqlParameter("@CategoryID", book.CategoryID));
    }

    public void UpdateBook(Book book)
    {
        Database.ExecuteSqlRaw("EXEC UpdateBook @BookID, @Title, @Author, @Price, @Stock, @CategoryID",
            new SqlParameter("@BookID", book.BookID),
            new SqlParameter("@Title", book.Title),
            new SqlParameter("@Author", book.Author),
            new SqlParameter("@Price", book.Price),
            new SqlParameter("@Stock", book.Stock),
            new SqlParameter("@CategoryID", book.CategoryID));
    }
   
    public void DeleteBook(int bookId)
    {
        Database.ExecuteSqlRaw("EXEC DeleteBook @BookID",
            new SqlParameter("@BookID", bookId));
    }

    public List<BookWithCategory> GetAllBooks()
    {
        return BooksWithCategories.FromSqlRaw("EXEC GetAllBooks").ToList();
    }

   

}