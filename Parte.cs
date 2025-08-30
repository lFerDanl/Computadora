// Parte.cs
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Vector3 = OpenTK.Vector3;

public class Parte
{
    public List<Cara> Caras { get; set; }
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; }
    public Vector3 Color { get; set; }

    public Parte()
    {
        Caras = new List<Cara>();
        Position = Vector3.Zero;
        Rotation = Vector3.Zero;
        Scale = Vector3.One;
        Color = Vector3.One;
    }

    public void AddCara(Cara cara)
    {
        Caras.Add(cara);
    }

    public void Render()
    {
        GL.PushMatrix();

        // Aplicar transformaciones
        GL.Translate(Position);
        GL.Rotate(Rotation.X, 1, 0, 0);
        GL.Rotate(Rotation.Y, 0, 1, 0);
        GL.Rotate(Rotation.Z, 0, 0, 1);
        GL.Scale(Scale);

        // Establecer color
        GL.Color3(Color);

        // Renderizar todas las caras
        foreach (var cara in Caras)
        {
            cara.Render();
        }

        GL.PopMatrix();
    }
}