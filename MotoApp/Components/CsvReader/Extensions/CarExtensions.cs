using MotoApp.Components.CsvReader.Models;
using System.Globalization;

namespace MotoApp.Components.CsvReader.Extensions;

public static class CarExtensions
{
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
        foreach (var line in source)
        {
            var colums = line.Split(',');
            yield return new Car
            {
                Year = int.Parse(colums[0]),
                Manufakturer = colums[1],
                Name = colums[2],
                Displacement = double.Parse(colums[3], CultureInfo.InvariantCulture),
                Cylinders = int.Parse(colums[4]),
                City = int.Parse(colums[5]),
                Highway = int.Parse(colums[6]),
                Combined = int.Parse(colums[7])
            };
        }

    }
}
