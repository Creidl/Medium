using MotoApp.Data.Entities;

namespace MotoApp.Data.Entities.Extensions;

public static class CarsHelper
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> cars, string color)
    {
        return cars.Where(car => car.Color == color);
    }
}
