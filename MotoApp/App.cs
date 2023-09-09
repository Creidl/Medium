using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;

namespace MotoApp;

internal class App : IApp
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;

    public App(IRepository<Employee> employeeRepository,
               IRepository<Car> carsRepository,
               ICarsProvider carsProvider)
    {
        _employeeRepository = employeeRepository;
        _carsRepository = carsRepository;
        _carsProvider = carsProvider;
    }

    public void Run()
    {
        Console.WriteLine("Employees:\n");
        //adding
        var employees = new[]
        {
            new Employee { FirstName = "John" },
            new Employee { FirstName = "Luck"}
        };

        foreach (var employee in employees)
        {
            _employeeRepository.Add(employee);
        }

        _employeeRepository.Save();
        //print
        var items = _employeeRepository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item.FirstName);
        }
        Console.WriteLine("\n Cars:\n");

        foreach (var car in GenerateSampleCars())
        {
            _carsRepository.Add(car);
        }
        _carsRepository.Save();
        Console.WriteLine(_carsProvider.AnonymusClass());
    }

    public List<Car> GenerateSampleCars()
    {
        var cars = new List<Car>()
        {
            new Car
            {
                Id = 1,
                Name = "Audi",
                Type = "A1",
                Color = "black",
                StandardCost = 1000
            },
            new Car
            {
                Id = 2,
                Name = "Audi",
                Type = "A2",
                Color = "black",
                StandardCost = 2000
            },
            new Car
            {
                Id = 3,
                Name = "Audi",
                Type = "A3",
                Color = "blue",
                StandardCost = 3000
            },
            new Car
            {
                Id = 4,
                Name = "Audi",
                Type = "A4",
                Color = "red",
                StandardCost = 6000
            },
            new Car
            {
                Id = 5,
                Name = "BMW",
                Type = "305",
                Color = "black",
                StandardCost = 3500
            },
            new Car
            {
                Id = 6,
                Name = "Hyundai",
                Type = "i30",
                Color = "gray",
                StandardCost = 4000
            },
            new Car
            {
                Id = 7,
                Name = "Fiat",
                Type = "500",
                Color = "pink",
                StandardCost = 2500
            },
            new Car
            {
                Id = 8,
                Name = "Renault",
                Type = "Megane",
                Color = "yellow",
                StandardCost = 1500
            },
            new Car
            {
                Id = 9,
                Name = "Nissan",
                Type = "Note",
                Color = "gray",
                StandardCost = 3000
            }
        };
        return cars;
    }
}