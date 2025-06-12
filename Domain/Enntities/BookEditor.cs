namespace Domain.Enntities;

public class BookEditor
{
    public int Id { get; set; }
    public int Isbn { get; set; }
    public int EditorId { get; set; }

    // navigation
    public Book? Book { get; set; }
    public Editor? Editor { get; set; }
}
