// Vertice.cs
using System;
using OpenTK;
using Vector3 = OpenTK.Vector3;
using Vector2 = OpenTK.Vector2;

public class Vertice
{
    public Vector3 Position { get; set; }
    public Vector3 Normal { get; set; }
    public Vector2 TexCoord { get; set; }

    public Vertice(float x, float y, float z)
    {
        Position = new Vector3(x, y, z);
        Normal = Vector3.Zero;
        TexCoord = Vector2.Zero;
    }

    public Vertice(float x, float y, float z, float nx, float ny, float nz)
    {
        Position = new Vector3(x, y, z);
        Normal = new Vector3(nx, ny, nz);
        TexCoord = Vector2.Zero;
    }

    public Vertice(float x, float y, float z, float nx, float ny, float nz, float u, float v)
    {
        Position = new Vector3(x, y, z);
        Normal = new Vector3(nx, ny, nz);
        TexCoord = new Vector2(u, v);
    }
}