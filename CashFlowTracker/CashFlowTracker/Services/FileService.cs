using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


namespace CashFlowTracker.Services;

public static class FileService
{
    // Serialize any object to JSON and write it to a file
    public static void SaveToJson<T>(string filePath, T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    // Read a JSON file and deserialize it back to the given type
    public static T LoadFromJson<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json)!;
    }
}
