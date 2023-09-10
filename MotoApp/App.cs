using MotoApp.Components.CsvReader;

namespace MotoApp;

internal class App : IApp
{
    private readonly ICsvReader _csvReader;

    public App(ICsvReader csvReader)
    {
        _csvReader = csvReader;
    }

    public void Run()
    {
        var cars = _csvReader.ProcessCars(@"Resourses\Files\fuel.csv");
        var manufakturers = _csvReader.ProcessManufacturers(@"Resourses\Files\manufacturers.csv");

        var groups = cars.GroupBy(car => car.Manufakturer)
            .Select(x => new
            {
                Name = x.Key,
                Max = x.Max(car => car.Combined),
                Average = x.Average(car => car.Combined)
            })
            .OrderBy(x => x.Average);
        foreach (var group in groups)
        {
            Console.WriteLine($"Name: {group.Name}");
            Console.WriteLine($"\tMax: {group.Max}");
            Console.WriteLine($"\tAverage: {group.Average}");
        }
    }
}