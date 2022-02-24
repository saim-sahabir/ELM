using System.Diagnostics.SymbolStore;

namespace ELM.Organization.Entities;

public class Notification
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? Status { get; set; }
    public DateTime Date { get; set; }
    public bool IsActive { get; set; }
}