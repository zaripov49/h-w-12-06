using System.ComponentModel.DataAnnotations;

namespace Domain.Enntities;

public class Book
{
    [Key]
    public int Isbn { get; set; }
    public string? Title { get; set; }
    public string? Type { get; set; }
    public int PublisherId { get; set; }
    public decimal Price { get; set; }
    public string? Advance { get; set; }
    public decimal Ytdsales { get; set; }
    public DateTime PubDate { get; set; }

    // navigation
    public Publisher? Publisher { get; set; }
    public List<BookEditor>? BookEditors { get; set; }
    public List<BookAuthor>? BookAuthors { get; set; }
}
