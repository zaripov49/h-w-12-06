namespace Domain.DTOs.BookAuthorDTO;

public class CreateBookAuthorDTO
{
    public int Isbn { get; set; }
    public int AuthorId { get; set; }
    public string? AuthorOrder { get; set; }
    public string? Royaltyshare { get; set; }
}
