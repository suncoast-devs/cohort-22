using System;
using System.Text.Json.Serialization;

namespace OneListClient
{
  public class Item
  {
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("complete")]
    public bool Complete { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public string CompletedStatus
    {
      get
      {
        return Complete ? "Completed" : "Not Completed";

        // if (complete)
        // {
        //   return "Completed";
        // }
        // else
        // {
        //   return "Not Completed";
        // }
      }
    }
  }
}