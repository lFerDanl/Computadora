// Cara.cs
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;

[Serializable]
public class Cara
{
    public List<Vertice> Vertices { get; set; } = new List<Vertice>();
    public float[] Color { get; set; } = new float[] { 1f, 1f, 1f };

    public Cara()
    {
        Vertices = new List<Vertice>();
    }

    public void AddVertice(Vertice vertice)
    {
        Vertices.Add(vertice);
    }

    public void Render(Vector3 centroMasa)
    {
        GL.Color3(Color[0], Color[1], Color[2]);

        if (Vertices.Count == 3)
        {
            GL.Begin(PrimitiveType.Triangles);
            foreach (var vertice in Vertices)
            {
                Vector3 posicionFinal = vertice.Position + centroMasa;
                GL.Vertex3(posicionFinal);
            }
            GL.End();
        }
        else if (Vertices.Count == 4)
        {
            GL.Begin(PrimitiveType.Quads);
            foreach (var vertice in Vertices)
            {
                Vector3 posicionFinal = vertice.Position + centroMasa;
                GL.Vertex3(posicionFinal);
            }
            GL.End();
        }
    }
}