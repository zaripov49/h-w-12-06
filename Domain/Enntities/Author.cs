namespace Domain.Enntities;

public class Author
{
    public int Id { get; set; }
    public string? SSN { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }

    // navigation
    public List<BookAuthor>? BookAuthors { get; set; }
}
