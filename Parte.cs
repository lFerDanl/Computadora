// Parte.cs
using System;
using System.Collections.Generic;
using OpenTK;
using Vector3 = OpenTK.Vector3;
using Newtonsoft.Json;

[Serializable]
public class Parte
{
    public List<Cara> Caras { get; set; } = new List<Cara>();

    public Parte()
    {
        Caras = new List<Cara>();
    }

    public void AddCara(Cara cara)
    {
        Caras.Add(cara);
    }

    public void Render(Vector3 centroMasa)
    {
        foreach (var cara in Caras)
        {
            cara.Render(centroMasa);
        }
    }
}