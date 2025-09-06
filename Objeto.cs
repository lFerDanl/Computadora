// Objeto.cs - MEJORADO
using System;
using System.Collections.Generic;
using OpenTK;
using Vector3 = OpenTK.Vector3;
using Newtonsoft.Json;

[Serializable]
public class Objeto
{
    public List<Parte> partes { get; set; } = new List<Parte>();

    public float[] centroDeMasa { get; set; } = new float[3];

    [JsonIgnore]
    public Vector3 centroMasa {
        get => new Vector3(centroDeMasa[0], centroDeMasa[1], centroDeMasa[2]);
        set{ centroDeMasa[0] = value.X; centroDeMasa[1] = value.Y; centroDeMasa[2] = value.Z; }
    }

    public Objeto(Vector3 centroMasa)
    {
        this.centroMasa = centroMasa;
        partes = new List<Parte>();
    }

    public void AddParte(Parte parte)
    {
        partes.Add(parte);
    }

    public virtual void Render()
    {
        foreach (var parte in partes)
        {
            // Pasar el centro de masa del objeto a cada parte
            parte.Render(this.centroMasa);
        }
    }
}