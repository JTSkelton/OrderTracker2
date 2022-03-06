using System.Collections.Generic;
using System; 

namespace OrderTracker.Models
{
  public class Order
  {
    public string Description { get; set; }
    public int Id { get; }
    public int Pastery { get; set; }
    public int Bread { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    private static List<Order> _instances = new List<Order> { };

    public Order(string description, int pastery, int bread)
    {
      Description = description;
      Pastery = pastery;
      Bread = bread;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
