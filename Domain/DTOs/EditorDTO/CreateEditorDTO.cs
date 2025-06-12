namespace Domain.DTOs.EditorDTO;

public class CreateEditorDTO
{
    public string? SSN { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? EditorPosition { get; set; }
    public decimal Salary { get; set; }
}
