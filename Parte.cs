using System;
using OpenTK;

[Serializable]
public class Parte : ElementoGeometrico<Cara>
{
    public Parte(Vector3 centro) : base(centro) { }

    public void Render(Vector3 centroPadre)
    {
        Vector3 centroGlobal = centroPadre + centroMasa; // Centro relativo al objeto
        foreach (var cara in Hijos.Values)
            cara.Render(centroGlobal); // centro acumulado
    }
}
