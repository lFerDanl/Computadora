// Cara.cs
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

public class Cara
{
    public List<Vertice> Vertices { get; set; }

    public Cara()
    {
        Vertices = new List<Vertice>();
    }

    public void AddVertice(Vertice vertice)
    {
        Vertices.Add(vertice);
    }

    public void Render()
    {
        if (Vertices.Count == 3)
        {
            // Triángulo
            GL.Begin(PrimitiveType.Triangles);
            foreach (var vertice in Vertices)
            {
                GL.Normal3(vertice.Normal);
                GL.TexCoord2(vertice.TexCoord);
                GL.Vertex3(vertice.Position);
            }
            GL.End();
        }
        else if (Vertices.Count == 4)
        {
            // Cuadrilátero - usar quads es más eficiente
            GL.Begin(PrimitiveType.Quads);
            foreach (var vertice in Vertices)
            {
                GL.Normal3(vertice.Normal);
                GL.TexCoord2(vertice.TexCoord);
                GL.Vertex3(vertice.Position);
            }
            GL.End();
        }
    }
}