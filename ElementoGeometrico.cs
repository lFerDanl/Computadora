// ElementoGeometrico.cs
using System;
using System.Collections.Generic;
using OpenTK;
using Newtonsoft.Json;

[Serializable]
public abstract class ElementoGeometrico<T> : ITransformable where T : ITransformable
{
    public Dictionary<string, T> Hijos { get; set; } = new Dictionary<string, T>();

    public virtual void AddHijo(string id, T hijo)
    {
        Hijos[id] = hijo;
    }

    public T? GetHijo(string id)
    {
        return Hijos.ContainsKey(id) ? Hijos[id] : default;
    }

    public virtual void Trasladar(Vector3 traslacion)
    {
        foreach (var hijo in Hijos.Values)
            hijo.Trasladar(traslacion);
    }

    public virtual void Rotar(Vector3 rotacion)
    {
        foreach (var hijo in Hijos.Values)
            hijo.Rotar(rotacion);
    }

    public virtual void Escalar(Vector3 escala)
    {
        foreach (var hijo in Hijos.Values)
            hijo.Escalar(escala);
    }

    public virtual void Reflejar(Vector3 reflejar)
    {
        foreach (var hijo in Hijos.Values)
            hijo.Reflejar(reflejar);
    }

}
