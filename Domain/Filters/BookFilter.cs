namespace Domain.Filters;

public class BookFilter : ValidFilter
{
    public string? Title { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}
