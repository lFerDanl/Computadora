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

    [JsonIgnore]
    public Vector3 traslacion { get; set; } = Vector3.Zero;
    [JsonIgnore]
    public Vector3 rotacion { get; set; } = Vector3.Zero;
    [JsonIgnore]
    public Vector3 escala { get; set; } = Vector3.One;

    public Cara()
    {
        Vertices = new List<Vertice>();
    }

    public void AddVertice(Vertice vertice)
    {
        Vertices.Add(vertice);
    }

    public void Trasladar(Vector3 traslacion)
    {
        this.traslacion += traslacion;
    }

    public void Rotar(Vector3 rotacion)
    {
        this.rotacion += rotacion;
    }

    public void Escalar(Vector3 escala)
    {
        this.escala = new Vector3(
            this.escala.X * escala.X,
            this.escala.Y * escala.Y,
            this.escala.Z * escala.Z
        );
    }

    public void Render(Vector3 centroMasa)
    {
        GL.PushMatrix();

        // Aplicar centro de masa del objeto
        GL.Translate(centroMasa.X, centroMasa.Y, centroMasa.Z);

        // Aplicar transformaciones de la cara
        GL.Translate(traslacion.X, traslacion.Y, traslacion.Z);
        GL.Rotate(rotacion.X, 1.0f, 0.0f, 0.0f);
        GL.Rotate(rotacion.Y, 0.0f, 1.0f, 0.0f);
        GL.Rotate(rotacion.Z, 0.0f, 0.0f, 1.0f);
        GL.Scale(escala.X, escala.Y, escala.Z);

        // Renderizar la cara
        GL.Color3(Color[0], Color[1], Color[2]);
        GL.Begin(PrimitiveType.Quads);
        foreach (var vertice in Vertices)
        {
            GL.Vertex3(vertice.Position);
        }
        GL.End();

        GL.PopMatrix();
    }
}