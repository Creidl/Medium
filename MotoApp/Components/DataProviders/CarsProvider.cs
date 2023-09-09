using MotoApp.Data.Entities;
using MotoApp.Data.Entities.Extensions;
using MotoApp.Data.Repositories;
using System;

namespace MotoApp.Components.DataProviders;

public class CarsProvider : ICarsProvider
{
    private readonly IRepository<Car> _carRepository;

    public CarsProvider(IRepository<Car> carRepository)
    {
        _carRepository = carRepository;
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        return _carRepository.GetAll().Select(x => x.LastPrice).Min();
    }

    public List<Car> GetSpecificColumns()
    {
        return _carRepository.GetAll().Select(x => new Car
        {
            Id = x.Id,
            Name = x.Name,
            Color = x.Color
        }).ToList();
    }

    public List<string> GetUniqueCarColors()
    {
        var colors = _carRepository.GetAll().Select(x => x.Color).Distinct().ToList();
        return colors;
    }

    public string AnonymusClass()
    {
        var list = _carRepository.GetAll().Select(x => new
        {
            x.Name,
            x.Type
        });
        return string.Join(", ", list);
    }

    public List<Car> OrderByName()
    {
        return _carRepository.GetAll().OrderBy(x => x.Name).ToList();
    }

    public List<Car> OrderByNameDescending()
    {
        return _carRepository.GetAll().OrderByDescending(x => x.Name).ToList();
    }

    public List<Car> OrderByColorAndName()
    {
        return _carRepository.GetAll()
            .OrderBy(x => x.Color)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Car> OrderByColorAndNameDescending()
    {
        return _carRepository.GetAll()
            .OrderByDescending(x => x.Color)
            .ThenByDescending(x => x.Name)
            .ToList();
    }

    public List<Car> WhereStartsWith(string prefix)
    {
        return _carRepository.GetAll().Where(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
    {
        return _carRepository.GetAll().Where(x => x.Name.StartsWith(prefix) && x.LastPrice > cost).ToList();
    }

    public List<Car> WhereColorIs(string color)
    {
        var cars = _carRepository.GetAll();
        return cars.ByColor(color).ToList();//wykorzystnie extension metody ByColor
    }

    public Car FirstByColor(string color)
    {
        return _carRepository.GetAll().First(x => x.Color == color);
    }

    public Car? FirstOrDefaultByColor(string color)
    {
        return _carRepository.GetAll().FirstOrDefault(x => x.Color == color);
    }

    public Car FirstOrDefaultByColorWithDefault(string color)
    {
        return _carRepository.GetAll()
            .FirstOrDefault(x => x.Color == color,
            new Car { Id = -1, Name = "Not found" });
    }

    public Car LastByColor(string color)
    {
        return _carRepository.GetAll()
            .Last(x => x.Color == color);
    }

    public Car SingleById(int id)
    {
        return _carRepository.GetAll().Single(x => x.Id == id);
    }

    public Car? SingleByIdOrDefault(int id)
    {
        return _carRepository.GetAll().SingleOrDefault(x => x.Id == id);
    }

    public List<Car> TakeCars(int howMany)
    {
        return _carRepository.GetAll()
            .OrderBy(x => x.Name)
            .Take(howMany)
            .ToList();
    }

    public List<Car> TakeCars(Range range)
    {
        return _carRepository.GetAll()
            .OrderBy(x => x.Name)
            .Take(range)
            .ToList();
    }

    public List<Car> TakeCarsWhileNameStartsWith(string prefix)
    {
        return _carRepository.GetAll()
            .OrderBy(x => x.Name)
            .TakeWhile(x => x.Name.StartsWith(prefix))
            .ToList();
    }

    public List<Car> SkipCars(int howMany)
    {
        return _carRepository.GetAll()
            .OrderBy(x => x.Name)
            .Skip(howMany)
            .ToList();
    }

    public List<Car> SkipCarsWhileNameStartsWith(string prefix)
    {
        return _carRepository.GetAll()
            .OrderBy(x => x.Name)
            .SkipWhile(x => x.Name.StartsWith(prefix))
            .ToList();
    }

    public List<string> DistinctAllColors()
    {
        return _carRepository.GetAll()
            .Select(x => x.Color)
            .Distinct()
            .ToList();
    }

    public List<Car> DistinctByColors()
    {
        return _carRepository.GetAll()
            .DistinctBy(x => x.Color)
            .ToList();
    }

    public List<Car[]> ChunkCars(int size)
    {
        return _carRepository.GetAll().Chunk(size).ToList();
    }
}