// Serializador.cs
using System;
using System.Collections.Generic;
using System.Data;
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

    public static void GuardarEscenario(Escenario escenario, string fileName, string directory = DefaultDirectory)
    {
        Directory.CreateDirectory(directory);

        string filePath = Path.Combine(directory, fileName + ".json");
        string json = JsonConvert.SerializeObject(escenario, jsonSettings);

        File.WriteAllText(filePath, json);
        Console.WriteLine($"Escenario guardado ({escenario.Hijos.Count} objetos) en: {filePath}");
    }

    public static Escenario CargarEscena(string fileName, string directory = DefaultDirectory)
    {
        string filePath = Path.Combine(directory, fileName + ".json");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Archivo no encontrado: {filePath}");
        }

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<Escenario>(json, jsonSettings)
            ?? throw new InvalidOperationException($"Error al deserializar el archivo: {filePath}");
    }
}
