// Parte.cs
using System;
using System.Collections.Generic;
using OpenTK;
using Vector3 = OpenTK.Vector3;
using Newtonsoft.Json;

[Serializable]
public class Parte
{
    public Dictionary<string, Cara> Caras { get; set; } = new Dictionary<string, Cara>();

    public Parte()
    {
        Caras = new Dictionary<string, Cara>();
    }

    public void AddCara(string id, Cara cara)
    {
        Caras[id] = cara;
    }
    
    public Cara? GetCara(string id)
    {
        return Caras.ContainsKey(id) ? Caras[id] : null;
    }

    public void Trasladar(Vector3 traslacion)
    {
        foreach (var cara in Caras.Values)
        {
            cara.Trasladar(traslacion);
        }
    }

    public void Rotar(Vector3 rotacion)
    {
        foreach (var cara in Caras.Values)
        {
            cara.Rotar(rotacion);
        }
    }

    public void Escalar(Vector3 escala)
    {
        foreach (var cara in Caras.Values)
        {
            cara.Escalar(escala);
        }
    }

    public void Render(Vector3 centroMasa)
    {
        foreach (var cara in Caras.Values)
        {
            cara.Render(centroMasa);
        }
    }
}