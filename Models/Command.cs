using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models;

public class Command
{
    [Key]
    public int Id { get; set; }

    public required string HowTo { get; set; } = string.Empty;

    public required string CommandLine { get; set; } = string.Empty;

    public required int PlatformId { get; set; }

    public Platform? Platform { get; set; }
}