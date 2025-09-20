//Parte.cs
//using System;
//using OpenTK;

//[Serializable]
//public class Parte : ElementoGeometrico<Cara>
//{
//    public Parte(Vector3 centro) : base(centro) { }

//    public void Render(Vector3 centroPadre)
//    {
//        Matrix4 transform = ObtenerMatrizTransformacion();
//        Vector3 centroGlobal = Vector3.TransformPosition(centroMasa, transform) + centroPadre;

//        foreach (var cara in Hijos.Values)
//            cara.Render(centroGlobal); // centro acumulado
//    }

//}
