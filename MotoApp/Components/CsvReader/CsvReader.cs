﻿using MotoApp.Components.CsvReader.Extensions;
using MotoApp.Components.CsvReader.Models;
using System.Globalization;

namespace MotoApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<Car> ProcessCars(string filePath)
    {
        if(!File.Exists(filePath))
        {
            return new List<Car>();
        }
        return File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToCar()            
            .ToList();
    }

    public List<Manufacturer> ProcessManufacturers(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Manufacturer>();
        }
        return File.ReadAllLines(filePath)
            .Where(x => x.Length > 1)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Manufacturer 
                { 
                    Name = columns[0],
                    Country = columns[1], 
                    Year = int.Parse(columns[2]) 
                };
            })
            .ToList();
    }
}
