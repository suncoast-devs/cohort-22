using System;

namespace OneListClient
{
  public class Item
  {
    public int id { get; set; }
    public string text { get; set; }
    public bool complete { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    public string CompletedStatus
    {
      get
      {
        return complete ? "Completed" : "Not Completed";

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