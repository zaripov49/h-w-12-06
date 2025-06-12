namespace Domain.Enntities;

public class BookAuthor
{
    public int Id { get; set; }
    public int Isbn { get; set; }
    public int AuthorId { get; set; }
    public string? AuthorOrder { get; set; }
    public string? Royaltyshare { get; set; }

    // navigation
    public Book? Book { get; set; }
    public Author? Author { get; set; }
}
