namespace BookApp.Models;

public class BookWithCategory
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; } 
}