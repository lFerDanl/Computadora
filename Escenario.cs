// Escenario.cs
using System;
using OpenTK;

[Serializable]
public class Escenario : ElementoGeometrico<Objeto>
{

    public Escenario() : base() { }

    public void Render()
    {
        foreach (var objeto in Hijos.Values)
            objeto.Render();
    }
}
