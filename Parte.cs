// Parte.cs
using System;
using OpenTK;

[Serializable]
public class Parte : ElementoGeometrico<Cara>
{
    public Parte() : base() { }

    public void Render(Vector3 centroMasa)
    {
        foreach (var cara in Hijos.Values)
            cara.Render(centroMasa);
    }
}
