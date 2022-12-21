using System.Text.Json.Serialization;
using Lombok.NET;

namespace lab5.DTO;

[ToString]
public partial class ContenderDTO
{
    public ContenderDTO(string? name)
    {
        if (name != null) this.name = name;
    }

    [JsonPropertyName("name")] public string? name { get; set; }
}