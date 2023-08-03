using MotoApp.Repositories;
using MotoApp.Entities;
using MotoApp.Data;

var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());

AddEmployee(sqlRepository);
AddManager(sqlRepository);
AddEmployee(sqlRepository);
AddManager(sqlRepository);
WriteAllToConsole(sqlRepository);

 static void AddEmployee(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Creidl" });
    employeeRepository.Add(new Employee { FirstName = "Marlon" });
    employeeRepository.Add(new Employee { FirstName = "Bambi" });
    employeeRepository.Save();
}

static void AddManager(IWriteRepository<Manager> employeeRepository)
{
    employeeRepository.Add(new Manager { FirstName = "Creidlus" });
    employeeRepository.Add(new Manager { FirstName = "Maniek" });
    employeeRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntitiy> repository)
{
    var items = repository.GetAll();
    foreach (Employee item in items)
    {
        Console.WriteLine(item);
    }
}