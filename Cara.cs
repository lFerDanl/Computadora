// Cara.cs
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Newtonsoft.Json;

[Serializable]
public class Cara: ElementoGeometrico<Vertice>
{
    public float[] Color { get; set; } = new float[] { 1f, 1f, 1f };

    [JsonIgnore]
    public Vector3 traslacion { get; set; } = Vector3.Zero;
    [JsonIgnore]
    public Vector3 rotacion { get; set; } = Vector3.Zero;
    [JsonIgnore]
    public Vector3 escala { get; set; } = Vector3.One;
    [JsonIgnore]
    public Vector3 reflejar { get; set; } = Vector3.One;
    [JsonIgnore]
    private Matrix4 matrizTransformacion = Matrix4.Identity;


    public override void Trasladar(Vector3 t)
    {
        traslacion += t;
        ActualizarMatriz();
    }

    public override void Rotar(Vector3 r)
    {
        rotacion += r;
        ActualizarMatriz();
    }

    public override void Escalar(Vector3 s)
    {
        escala *= s; // Vector3 tiene operador * sobrecargado
        ActualizarMatriz();
    }

    public override void Reflejar(Vector3 r)
    {
        reflejar *= r;
        ActualizarMatriz();
    }

    private void ActualizarMatriz()
    {
        // Crear la matriz de transformación completa
        matrizTransformacion =
            Matrix4.CreateScale(reflejar) *
            Matrix4.CreateTranslation(traslacion) *
            (Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotacion.X)) *
             Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotacion.Y)) *
             Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotacion.Z))) *
            Matrix4.CreateScale(escala);
    }

    public void Render(Vector3 centroMasa)
    {
        GL.PushMatrix();

        // Aplicar centro de masa del objeto
        GL.Translate(centroMasa.X, centroMasa.Y, centroMasa.Z);

        // Aplicar Transformacionesa
        GL.MultMatrix(ref matrizTransformacion);

        // Renderizar la cara
        GL.Color3(Color[0], Color[1], Color[2]);
        GL.Begin(PrimitiveType.Quads);
        foreach (var vertice in Hijos)
        {
            GL.Vertex3(vertice.Value.Position);
        }
        GL.End();

        GL.PopMatrix();
    }
}