namespace Domain.Enntities;

public class Editor
{
    public int Id { get; set; }
    public string? SSN { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? EditorPosition { get; set; }
    public decimal Salary { get; set; }

    // navigation
    public List<BookEditor>? BookEditors { get; set; }
}
