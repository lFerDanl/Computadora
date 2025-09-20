//// Cara.cs
//using System;
//using System.Collections.Generic;
//using OpenTK;
//using OpenTK.Graphics.OpenGL;
//using Newtonsoft.Json;

//[Serializable]
//public class Cara : ElementoGeometrico<Vertice>
//{
//    public float[] Color { get; set; } = new float[] { 1f, 1f, 1f };
//    [JsonIgnore] public Vector3 traslacion = Vector3.Zero;
//    [JsonIgnore] public Vector3 rotacion = Vector3.Zero;
//    [JsonIgnore] public Vector3 escala = Vector3.One;
//    [JsonIgnore] public Vector3 reflejar = Vector3.One;
//    [JsonIgnore] private Matrix4 matrizTransformacion = Matrix4.Identity;


//    public Cara(Vector3 centro) : base(centro) { }

//    public override void Trasladar(Vector3 t)
//    {
//        traslacion += t;
//        ActualizarMatriz();
//    }

//    public override void Rotar(Vector3 r)
//    {
//        rotacion += r;
//        ActualizarMatriz();
//    }

//    public override void Escalar(Vector3 s)
//    {
//        escala *= s;
//        ActualizarMatriz();
//    }

//    public override void Reflejar(Vector3 r)
//    {
//        reflejar *= r;
//        ActualizarMatriz();
//    }

//    private void ActualizarMatriz()
//    {
//        // Crear la matriz de transformación completa
//        matrizTransformacion =
//            Matrix4.CreateScale(reflejar) *
//            Matrix4.CreateTranslation(traslacion) *
//            (Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotacion.X)) *
//             Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotacion.Y)) *
//             Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotacion.Z))) *
//            Matrix4.CreateScale(escala);
//    }

//    public void Render(Vector3 centroPadre)
//    {
//        GL.PushMatrix();

//        Matrix4 transform = ObtenerMatrizTransformacion();
//        Vector3 centroGlobal = centroPadre + centroMasa;

//        // Aplicar transformaciones
//        GL.Translate(centroGlobal.X, centroGlobal.Y, centroGlobal.Z);
//        GL.MultMatrix(ref transform);
//        GL.MultMatrix(ref matrizTransformacion);

//        // Dibujar vértices
//        GL.Color3(Color[0], Color[1], Color[2]);
//        GL.Begin(PrimitiveType.Quads);
//        foreach (var vertice in Hijos.Values)
//            GL.Vertex3(vertice.Position);
//        GL.End();

//        GL.PopMatrix();
//    }
//}