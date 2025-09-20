// Objeto.cs
using OpenTK;
using Newtonsoft.Json;

[Serializable]
public class Objeto : ElementoGeometrico<Parte>
{
    public float[] centroDeMasa { get; set; } = new float[3];

    [JsonIgnore]
    public Vector3 CentroMasa
    {
        get => new Vector3(centroDeMasa[0], centroDeMasa[1], centroDeMasa[2]);
        set { centroDeMasa[0] = value.X; centroDeMasa[1] = value.Y; centroDeMasa[2] = value.Z; }
    }

    public Objeto(Vector3 centroMasa)
    {
        this.CentroMasa = centroMasa;
    }

    public void Render()
    {
        foreach (var parte in Hijos.Values)
            parte.Render(this.CentroMasa);
    }
}
