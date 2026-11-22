namespace EntityFramework_Session04.Models;

public class Manager
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateOnly HireDate { get; set; }

    public string BranchCode { get; set; } = string.Empty;
    public Branch Branch { get; set; } = null!;
}