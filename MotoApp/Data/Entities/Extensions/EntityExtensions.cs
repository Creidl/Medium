using Microsoft.EntityFrameworkCore.ChangeTracking;
using MotoApp.Data.Entities;
using System.Text.Json;

namespace MotoApp.Data.Entities.Extensions;

public static class EntityExtensions
{
    public static T? Copy<T>(this T? itemToCopy) where T : class, IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}