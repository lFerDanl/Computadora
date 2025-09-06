// Vertice.cs
using System;
using OpenTK;
using Vector3 = OpenTK.Vector3;
using Newtonsoft.Json;

[Serializable]
public class Vertice
{
    public float[] coordenadas { get; set; } = new float[3];

    [JsonIgnore]
    public Vector3 Position => new Vector3(coordenadas[0], coordenadas[1], coordenadas[2]);

    public Vertice() { }

    public Vertice(float x, float y, float z)
    {
        coordenadas[0] = x; coordenadas[1] = y; coordenadas[2] = z;
    }

}
