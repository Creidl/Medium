using MotoApp.Components.CsvReader;
using MotoApp.Components.CsvReader.Models;
using MotoApp.Data.Entities;
using System.Xml.Linq;

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
        //var manufakturers = _csvReader.ProcessManufacturers(@"Resourses\Files\manufacturers.csv");

        CreateXML(cars);
        QueryXML();
    }

    private void QueryXML()
    {
        var document = XDocument.Load(@"Resourses\Files\fuel.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufakturer")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    private static void CreateXML(List<Components.CsvReader.Models.Car> cars)
    {
        var document = new XDocument();
        var newCars = new XElement("Cars", cars
            .Select(x => 
                new XElement("Car",
                    new XAttribute("Name", x.Name),
                    new XAttribute("Combined", x.Combined),
                    new XAttribute("Manufakturer", x.Manufakturer)
                )
            )
        );
        document.Add(newCars);
        document.Save(@"Resourses\Files\fuel.xml");
    }
}
//------------ GroupBy -------------------
//var groups = cars.GroupBy(car => car.Manufakturer)
//           .Select(x => new
//           {
//               Name = x.Key,
//               Max = x.Max(car => car.Combined),
//               Average = x.Average(car => car.Combined)
//           })
//           .OrderBy(x => x.Average);
//foreach (var group in groups)
//{
//    Console.WriteLine($"Name: {group.Name}");
//    Console.WriteLine($"\tMax: {group.Max}");
//    Console.WriteLine($"\tAverage: {group.Average}");
//}


//------------ Join -------------------
//var carsInCountry = cars.Join(
//         manufakturers,
//         c => c.Manufakturer,            //tu określamy sposób 
//         m => m.Name,                    // łączenia 
//         (car, manufakturer) =>          // tu określamy co łączymy w anonimową klasę
//             new
//             {
//                 manufakturer.Country,
//                 car.Name,
//                 car.Combined
//             }
//         )
//         .OrderByDescending(x => x.Combined)
//         .ThenBy(x => x.Name);

//foreach (var car in carsInCountry)
//{
//    Console.WriteLine($"Name: {car.Name}");
//    Console.WriteLine($"\tCombined: {car.Combined}");
//    Console.WriteLine($"\tCountry: {car.Country}");
//}


//------------ GroupJoin -------------------
//var groupsJoin = manufakturers.GroupJoin(
//cars,                                   // z tym się łączymy
//    manufakturers => manufakturers.Name,    // dwie linie klucza
//    car => car.Manufakturer,
//    (m, g) =>                                // zwracany element
//    new
//    {
//        manufakturer = m,    // klucz
//        car = g             //kolekcja
//    })
//    .OrderBy(x => x.manufakturer.Name);

//        foreach (var car in groupsJoin)
//        {
//            Console.WriteLine($"Name: {car.manufakturer.Name} {car.manufakturer.Country} {car.manufakturer.Year}");
//            Console.WriteLine($"\tCount: {car.car.Count()}");
//            Console.WriteLine($"\tMax: {car.car.Max(x => x.Combined)}");
//            Console.WriteLine($"\tMin: {car.car.Min(x => x.Combined)}");
//            Console.WriteLine($"\tAverage: {car.car.Average(x => x.Combined)}");
//            Console.WriteLine();
//        }