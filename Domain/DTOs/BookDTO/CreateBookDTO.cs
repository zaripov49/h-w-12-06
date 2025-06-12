namespace Domain.DTOs.BookDTO;

public class CreateBookDTO
{
    public string? Title { get; set; }
    public string? Type { get; set; }
    public int PublisherId { get; set; }
    public decimal Price { get; set; }
    public string? Advance { get; set; }
    public decimal Ytdsales { get; set; }
    public DateTime PubDate { get; set; }
}
