// Game.cs
using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

public class Game : GameWindow
{
    // Variables para el control de cámara
    private Vector3 cameraPosition;
    private Vector3 cameraFront;
    private Vector3 cameraUp;
    private float cameraYaw = -90.0f;

    // Lista de objetos en la escena
    private List<Objeto> objetos;

    public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
    {
        // Inicializar cámara
        cameraPosition = new Vector3(0.0f, 0.0f, 10.0f);
        cameraFront = new Vector3(0.0f, 0.0f, -1.0f);
        cameraUp = Vector3.UnitY;

        // Inicializar lista de objetos
        objetos = new List<Objeto>();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        GL.ClearColor(0.2f, 0.3f, 0.4f, 1.0f);
        GL.Enable(EnableCap.DepthTest);

        // Configurar matriz de proyección 
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f),
            (float)Width / Height, 0.1f, 100.0f);
        GL.LoadMatrix(ref perspective);

        InitializeScene();
    }

    private void InitializeScene()
    {
        objetos = Serializador.CargarEscena("mi_escritorio");

    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        // Configurar la matriz de vista (cambia con la cámara)
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();
        //--------------------------
        Vector3 cameraTarget = cameraPosition + cameraFront;
        Matrix4 lookAt = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
        GL.LoadMatrix(ref lookAt);

        // Renderizar todos los objetos
        foreach (var objeto in objetos)
        {
            objeto.Render();
        }

        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        HandleInput();
    }

    private void HandleInput()
    {
        var keyboard = Keyboard.GetState();

        float moveSpeed = 0.2f;
        float rotationSpeed = 2.0f;

        // Rotación con Q y E
        if (keyboard[Key.Q])
            cameraYaw -= rotationSpeed;
        if (keyboard[Key.E])
            cameraYaw += rotationSpeed;

        // Actualizar dirección de la cámara
        cameraFront.X = (float)Math.Cos(MathHelper.DegreesToRadians(cameraYaw));
        cameraFront.Z = (float)Math.Sin(MathHelper.DegreesToRadians(cameraYaw));
        cameraFront = Vector3.Normalize(cameraFront);

        // Movimiento con WASD
        if (keyboard[Key.W])
            cameraPosition += cameraFront * moveSpeed;
        if (keyboard[Key.S])
            cameraPosition -= cameraFront * moveSpeed;
        if (keyboard[Key.A])
            cameraPosition -= Vector3.Normalize(Vector3.Cross(cameraFront, cameraUp)) * moveSpeed;
        if (keyboard[Key.D])
            cameraPosition += Vector3.Normalize(Vector3.Cross(cameraFront, cameraUp)) * moveSpeed;

        // Subir y bajar con Shift y Control
        if (keyboard[Key.LShift] || keyboard[Key.RShift])
            cameraPosition += cameraUp * moveSpeed;
        if (keyboard[Key.LControl] || keyboard[Key.RControl])
            cameraPosition -= cameraUp * moveSpeed;
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);

        // Reconfigurar proyección cuando cambie el tamaño
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f),
            (float)Width / Height, 0.1f, 100.0f);
        GL.LoadMatrix(ref perspective);
    }

    protected override void OnKeyDown(KeyboardKeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.Key == Key.Escape)
        {
            Exit();
        }

        // Reset de cámara
        if (e.Key == Key.R)
        {
            cameraPosition = new Vector3(0.0f, 0.0f, 10.0f);
            cameraFront = new Vector3(0.0f, 0.0f, -1.0f);
            cameraYaw = -90.0f;
        }
    }
}