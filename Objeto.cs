using OpenTK;
using Newtonsoft.Json;

[Serializable]
public class Objeto : ElementoGeometrico<Parte>
{
    public Objeto(Vector3 centro) : base(centro) { }

    public void Render(Vector3 centroPadre)
    {
        Vector3 centroGlobal = centroPadre + centroMasa;
        foreach (var parte in Hijos.Values)
            parte.Render(centroGlobal);
    }
}
