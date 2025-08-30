// Objeto.cs
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Vector3 = OpenTK.Vector3;

public class Objeto
{
    protected List<Parte> partes;
    protected Vector3 position;
    protected Vector3 rotation;
    protected Vector3 scale;

    public Vector3 Position
    {
        get => position;
        set => position = value;
    }

    public Vector3 Rotation
    {
        get => rotation;
        set => rotation = value;
    }

    public Vector3 Scale
    {
        get => scale;
        set => scale = value;
    }

    protected List<Parte> Partes => partes;

    public Objeto()
    {
        partes = new List<Parte>();
        position = Vector3.Zero;
        rotation = Vector3.Zero;
        scale = Vector3.One;
    }

    // Método público para agregar partes
    public void AddParte(Parte parte)
    {
        partes.Add(parte);
    }

    public virtual void Render()
    {
        GL.PushMatrix();

        // Aplicar transformaciones del objeto
        GL.Translate(position);
        GL.Rotate(rotation.X, 1, 0, 0);
        GL.Rotate(rotation.Y, 0, 1, 0);
        GL.Rotate(rotation.Z, 0, 0, 1);
        GL.Scale(scale);

        // Renderizar todas las partes
        foreach (var parte in partes)
        {
            parte.Render();
        }

        GL.PopMatrix();
    }
}