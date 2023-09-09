using Microsoft.Extensions.DependencyInjection;
using MotoApp;
using MotoApp.Components.CsvReader;
using MotoApp.Components.DataProviders;
using MotoApp.Data.Entities;
using MotoApp.Data.Repositories;
using System.ComponentModel.DataAnnotations;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<ICarsProvider,CarsProvider>();
services.AddSingleton<ICsvReader, CsvReader>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetRequiredService<IApp>();
app.Run();

//using MotoApp.Repositories;
//using MotoApp.Entities;
//using MotoApp.Data;
//using MotoApp.Repositories.Extensions;

//var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext(), EmployeeAdded);
//sqlRepository.ItemAdded += EmployeeRepositoryOnItemAdded;

//AddEmployee(sqlRepository);
//AddManager(sqlRepository);

//WriteAllToConsole(sqlRepository);


//void EmployeeRepositoryOnItemAdded(object? sender, Employee e)
//{
//   Console.WriteLine($"Employee added => {e.FirstName} from {sender?.GetType().Name}");
//}

//static void EmployeeAdded(Employee item)
//{
//    Console.WriteLine($"{item.FirstName} added");
//}

// static void AddEmployee(IRepository<Employee> employeeRepository)
//{
//    //employeeRepository.Add(new Employee { FirstName = "Creidl" });
//    //employeeRepository.Add(new Employee { FirstName = "Marlon" });
//    //employeeRepository.Add(new Employee { FirstName = "Bambi" });
//    var employees = new[] {
//        new Employee { FirstName = "Creidl" },
//        new Employee { FirstName = "Marlon" },
//        new Employee { FirstName = "Bambi" }
//    };

//    //AddBatch(employeeRepository, employees);
//    employeeRepository.AddBatch(employees);
//}

//static void AddManager(IWriteRepository<Manager> employeeRepository)
//{
//    employeeRepository.Add(new Manager { FirstName = "Creidlus" });
//    employeeRepository.Add(new Manager { FirstName = "Maniek" });
//    employeeRepository.Save();
//}

////static void AddBatch<T>(IRepository<T> repository, T[] employees)
////    where T : class, IEntitiy
////{
////    foreach (var employee in employees)
////    {
////        repository.Add(employee);
////    }
////    repository.Save();
////}

//static void WriteAllToConsole(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (Employee item in items)
//    {
//        Console.WriteLine(item);
//    }
//}