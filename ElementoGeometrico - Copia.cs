//using System;
//using System.Collections.Generic;
//using OpenTK;
//using Newtonsoft.Json;

//[Serializable]
//public abstract class ElementoGeometrico<T> : ITransformable where T : ITransformable
//{
//    public Dictionary<string, T> Hijos { get; set; } = new Dictionary<string, T>();

//    [JsonIgnore]
//    public Vector3 traslacion = Vector3.Zero;
//    [JsonIgnore]
//    public Vector3 rotacion = Vector3.Zero;
//    [JsonIgnore]
//    public Vector3 escala = Vector3.One;
//    [JsonIgnore]
//    public Vector3 reflejar = Vector3.One;
//    [JsonIgnore]
//    public Vector3 pivote = Vector3.Zero; // pivote opcional para órbitas

//    public float[] centroDeMasa { get; set; } = new float[3];

//    [JsonIgnore]
//    public Vector3 centroMasa
//    {
//        get => new Vector3(centroDeMasa[0], centroDeMasa[1], centroDeMasa[2]);
//        set { centroDeMasa[0] = value.X; centroDeMasa[1] = value.Y; centroDeMasa[2] = value.Z; }
//    }

//    public ElementoGeometrico(Vector3 centro)
//    {
//        this.centroMasa = centro;
//    }

//    public virtual void AddHijo(string id, T hijo)
//    {
//        Hijos[id] = hijo;
//    }

//    public T? GetHijo(string id)
//    {
//        return Hijos.ContainsKey(id) ? Hijos[id] : default;
//    }

//    public virtual void Trasladar(Vector3 t)
//    {
//        traslacion += t;
//        foreach (var hijo in Hijos.Values)
//            hijo.Trasladar(traslacion);
//    }
//    public virtual void Rotar(Vector3 r)
//    {
//        rotacion += r;
//        Vector3 rotParaHijos = r * 1;
//        foreach (var hijo in Hijos.Values)
//            hijo.Rotar(rotParaHijos);
//    }
//    public virtual void Escalar(Vector3 s)
//    {
//        escala *= s;
//        foreach (var hijo in Hijos.Values)
//            hijo.Escalar(escala);
//    }
//    public virtual void Reflejar(Vector3 r)
//    {
//        reflejar *= r;
//        foreach (var hijo in Hijos.Values)
//            hijo.Reflejar(reflejar);
//    }

//    protected Matrix4 ObtenerMatrizTransformacion()
//    {
//        // Rotación y traslación con pivote opcional
//        Matrix4 m =
//            Matrix4.CreateTranslation(-pivote) *
//            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotacion.X)) *
//            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotacion.Y)) *
//            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotacion.Z)) *
//            Matrix4.CreateTranslation(pivote + traslacion) *
//            Matrix4.CreateScale(reflejar) *
//            Matrix4.CreateScale(escala);

//        return m;
//    }

//}