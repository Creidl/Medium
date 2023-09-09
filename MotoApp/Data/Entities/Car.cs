namespace MotoApp.Data.Entities;

public class Car : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal StandardCost { get; set; }
    public decimal LastPrice { get; set; }
    public string Type { get; set; }

    //calculated properties:
    public int? NameLenght { get; set; }
    public decimal? TotalSales { get; set; }

    public override string ToString()
    {
        return $"Name : {Name}, Type: {Type}, Color: {Color}, Cost: {StandardCost} ...";
    }
}