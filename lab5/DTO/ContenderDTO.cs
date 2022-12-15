using Newtonsoft.Json;

namespace lab5.DTO;

public class ContenderDTO
{
    [JsonProperty("name")]
    public string? name{ get; set; }

    public ContenderDTO(string? name)
    {
        Console.WriteLine("name : " + name);
        if (name != null)
        {
            this.name = name;
        }
    }
}