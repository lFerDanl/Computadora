//// Objeto.cs
//using OpenTK;
//using Newtonsoft.Json;

//[Serializable]
//public class Objeto : ElementoGeometrico<Parte>
//{

//    public Objeto(Vector3 centro) : base(centro) { }

//    public void Render(Vector3 centroPadre)
//    {
//        Matrix4 transform = ObtenerMatrizTransformacion();
//        Vector3 centroGlobal = Vector3.TransformPosition(centroMasa, transform) + centroPadre;

//        foreach (var parte in Hijos.Values)
//            parte.Render(centroGlobal);
//    }
//}
