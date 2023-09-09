using MotoApp.Data.Entities;

namespace MotoApp.Components.DataProviders;

public interface ICarsProvider
{
    //Select:
    List<string> GetUniqueCarColors();
    decimal GetMinimumPriceOfAllCars();
    List<Car> GetSpecificColumns();
    string AnonymusClass();

    //OrderBy:
    List<Car> OrderByName();
    List<Car> OrderByNameDescending();
    List<Car> OrderByColorAndName();
    List<Car> OrderByColorAndNameDescending();

    //Where:
    List<Car> WhereStartsWith(string prefix);
    List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);
    List<Car> WhereColorIs(string color);

    // First Lat Single:
    Car FirstByColor(string color);
    Car? FirstOrDefaultByColor(string color);
    Car? FirstOrDefaultByColorWithDefault(string color);
    Car LastByColor(string color);
    Car SingleById(int id);
    Car? SingleByIdOrDefault(int id);

    //Take:
    List<Car> TakeCars(int howMany);
    List<Car> TakeCars(Range range);
    List<Car> TakeCarsWhileNameStartsWith(string prefix);

    //Skip:
    List<Car> SkipCars(int howMany);
    List<Car> SkipCarsWhileNameStartsWith(string prefix);

    //Distinct:
    List<string> DistinctAllColors();
    List<Car> DistinctByColors();

    //Chunk:
    List<Car[]> ChunkCars();
}
