// Objeto.cs
using System;
using System.Collections.Generic;
using OpenTK;
using Vector3 = OpenTK.Vector3;
using Newtonsoft.Json;

[Serializable]
public class Objeto
{
    public Dictionary<string, Parte> partes { get; set; } = new Dictionary<string, Parte>();

    public float[] centroDeMasa { get; set; } = new float[3];

    [JsonIgnore]
    public Vector3 centroMasa {
        get => new Vector3(centroDeMasa[0], centroDeMasa[1], centroDeMasa[2]);
        set{ centroDeMasa[0] = value.X; centroDeMasa[1] = value.Y; centroDeMasa[2] = value.Z; }
    }

    public Objeto(Vector3 centroMasa)
    {
        this.centroMasa = centroMasa;
        partes = new Dictionary<string, Parte>();
    }

    public void AddParte(string id, Parte parte)
    {
        partes[id] = parte;
    }

    public Parte? GetParte(string id)
    {
        return partes.ContainsKey(id) ? partes[id] : null;
    }

    public void Trasladar(Vector3 traslacion)
    {
        foreach (var parte in partes.Values)
        {
            parte.Trasladar(traslacion);
        }
    }

    public void Rotar(Vector3 rotacion)
    {
        foreach (var parte in partes.Values)
        {
            parte.Rotar(rotacion);
        }
    }

    public void Escalar(Vector3 escala)
    {
        foreach (var parte in partes.Values)
        {
            parte.Escalar(escala);
        }
    }
    //obtener partes con dictionary

    public virtual void Render()
    {
        foreach (var parte in partes.Values)
        {
            parte.Render(this.centroMasa);
        }
    }
}