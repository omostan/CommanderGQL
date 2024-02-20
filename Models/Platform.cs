using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }

    public required string? Name { get; set; }

    public string LicenseKey { get; set; } = string.Empty;

    public ICollection<Command> Commands { get; set; } = new List<Command>();
}