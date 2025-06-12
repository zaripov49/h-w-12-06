namespace Domain.Enntities;

public class Publisher
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }

    // navigation
    public List<Book>? Books { get; set; }
}
