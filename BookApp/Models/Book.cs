using System.ComponentModel.DataAnnotations;

namespace BookApp.Models;

public class Book
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Please enter the correct price")]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be less than 0.")] // stok miktarı 0 dan küçük olamaz
    public int Stock { get; set; }
    public int CategoryID { get; set; }
    public Category? Category { get; set; }
    public bool IsDeleted { get; set; } = false; //Silinen kitabı geri getirmek için
}