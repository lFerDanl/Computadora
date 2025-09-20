// ElementoGeometrico.cs
using System;
using System.Collections.Generic;
using OpenTK;
using Newtonsoft.Json;
[Serializable] public abstract class ElementoGeometrico<T> : ITransformable where T : ITransformable { 
    public Dictionary<string, T> Hijos { get; set; } = new Dictionary<string, T>(); 
    public float[] centroDeMasa { get; set; } = new float[3]; 
    [JsonIgnore] 
    public Vector3 centroMasa { 
        get => new Vector3(centroDeMasa[0], centroDeMasa[1], centroDeMasa[2]); 
        set { centroDeMasa[0] = value.X; centroDeMasa[1] = value.Y; centroDeMasa[2] = value.Z; } 
    }
    

    public ElementoGeometrico(Vector3 centro) { this.centroMasa = centro; } 
    public virtual void AddHijo(string id, T hijo) { Hijos[id] = hijo; } 
    public T? GetHijo(string id) { return Hijos.ContainsKey(id) ? Hijos[id] : default; }

    public Vector3 GetCentro() { return centroMasa; }

    public virtual void Trasladar(Vector3 traslacion) { 
        foreach (var hijo in Hijos.Values) 
            hijo.Trasladar(traslacion); 
    } 
    public virtual void Rotar(Vector3 rotacion) { 
        foreach (var hijo in Hijos.Values) { 
            hijo.Rotar(rotacion);
        }
    } 
    public virtual void Escalar(Vector3 escala) { 
        foreach (var hijo in Hijos.Values) 
            hijo.Escalar(escala); 
    } 
    public virtual void Reflejar(Vector3 reflejar) { 
        foreach (var hijo in Hijos.Values) 
            hijo.Reflejar(reflejar); 
    } 

}