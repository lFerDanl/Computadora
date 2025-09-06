// Serializador.cs
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public static class Serializador
{
    private static readonly JsonSerializerSettings jsonSettings = new()
    {
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
    };

    private const string DefaultDirectory = "Objects";

    public static void GuardarEscena(List<Objeto> objetos, string fileName, string directory = DefaultDirectory)
    {
        Directory.CreateDirectory(directory);

        string filePath = Path.Combine(directory, fileName + ".json");
        string json = JsonConvert.SerializeObject(objetos, jsonSettings);

        File.WriteAllText(filePath, json);
        Console.WriteLine($"Escena guardada ({objetos.Count} objetos) en: {filePath}");
    }

    public static List<Objeto> CargarEscena(string fileName, string directory = DefaultDirectory)
    {
        string filePath = Path.Combine(directory, fileName + ".json");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Archivo no encontrado: {filePath}");
            return new List<Objeto>();
        }

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Objeto>>(json, jsonSettings) ?? new List<Objeto>();
    }
}
