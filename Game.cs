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
    private Escenario escenario;

    // Objeto seleccionado para transformaciones (para testing)
    private ITransformable testeo;

    public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
    {
        // Inicializar cámara
        cameraPosition = new Vector3(0.0f, 0.0f, 10.0f);
        cameraFront = new Vector3(0.0f, 0.0f, -1.0f);
        cameraUp = Vector3.UnitY;
    }

    private void InitializeScene()
    {
        escenario = Serializador.CargarEscena("mi_escritorio");
        testeo = escenario;
        objetoKeys = new List<string>(escenario.Hijos.Keys);
        if (objetoKeys.Count > 0)
        {
            parteKeys = new List<string>(escenario.Hijos[objetoKeys[0]].Hijos.Keys);
            if (parteKeys.Count > 0)
                caraKeys = new List<string>(escenario.Hijos[objetoKeys[0]].Hijos[parteKeys[0]].Hijos.Keys);
        }
        Console.WriteLine($"Objeto seleccionado para transformaciones: {testeo.GetType().Name}");
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

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        // Configurar la matriz de vista (cambia con la cámara)
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();
        Vector3 cameraTarget = cameraPosition + cameraFront;
        Matrix4 lookAt = Matrix4.LookAt(cameraPosition, cameraTarget, cameraUp);
        GL.LoadMatrix(ref lookAt);

        // Renderizar todos los objetos
        escenario.Render();

        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        HandleInput();
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

    private List<string> objetoKeys = new List<string>();
    private List<string> parteKeys = new List<string>();
    private List<string> caraKeys = new List<string>();
    private int objetoIndex = 0;
    private int parteIndex = 0;
    private int caraIndex = 0;

    private void cambiarObjeto()
    {
        if (objetoKeys.Count == 0) return;

        objetoIndex = (objetoIndex + 1) % objetoKeys.Count;
        parteIndex = 0;
        caraIndex = 0;

        var objeto = escenario.Hijos[objetoKeys[objetoIndex]];
        testeo = objeto;

        // Actualizar listas de hijos
        parteKeys = new List<string>(objeto.Hijos.Keys);
        caraKeys = parteKeys.Count > 0 ? new List<string>(objeto.Hijos[parteKeys[0]].Hijos.Keys) : new List<string>();

        Console.WriteLine($"Objeto seleccionado: {objetoKeys[objetoIndex]}");
    }

    private void cambiarParte()
    {
        if (parteKeys.Count == 0) return;

        parteIndex = (parteIndex + 1) % parteKeys.Count;

        var objeto = escenario.Hijos[objetoKeys[objetoIndex]];
        var parte = objeto.Hijos[parteKeys[parteIndex]];

        testeo = parte;

        // Actualizar lista de caras
        caraKeys = new List<string>(parte.Hijos.Keys);

        Console.WriteLine($"Parte seleccionada: {objetoKeys[objetoIndex]}");
    }

    private void cambiarCara()
    {
        if (caraKeys.Count == 0) return;

        caraIndex = (caraIndex + 1) % caraKeys.Count;

        var objeto = escenario.Hijos[objetoKeys[objetoIndex]];
        var parte = objeto.Hijos[parteKeys[parteIndex]];
        var cara = parte.Hijos[caraKeys[caraIndex]];

        testeo = cara;

        Console.WriteLine($"Cara seleccionada: {objetoKeys[objetoIndex]}");
    }

    private void cambiarEscenario()
    {
        testeo = escenario;

        // Reiniciar índices
        objetoIndex = 0;
        parteIndex = 0;
        caraIndex = 0;

        // Actualizar listas de claves
        objetoKeys = new List<string>(escenario.Hijos.Keys);
        parteKeys = objetoKeys.Count > 0 ? new List<string>(escenario.Hijos[objetoKeys[0]].Hijos.Keys) : new List<string>();
        caraKeys = (parteKeys.Count > 0) ? new List<string>(escenario.Hijos[objetoKeys[0]].Hijos[parteKeys[0]].Hijos.Keys) : new List<string>();

        Console.WriteLine("Escenario seleccionado.");
    }

    private void HandleInput()
    {
        var keyboard = Keyboard.GetState();

        float moveSpeed = 0.2f;
        float rotationSpeed = 2.0f;

        // === CONTROLES DE CÁMARA ===
        // Rotación con Q y E
        if (keyboard[Key.E])
            cameraYaw -= rotationSpeed;
        if (keyboard[Key.Q])
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

        // === CONTROLES DE TRANSFORMACIÓN ===
        if (testeo != null)
        {
            float transformStep = 0.1f;
            float rotationStep = 5.0f;
            float scaleStep = 0.05f;

            // TRASLACIÓN - ROTACION
            if (keyboard[Key.Keypad4])
            {
                if (isTraslacion) testeo.Trasladar(new Vector3(-transformStep, 0, 0));
                else testeo.Rotar(new Vector3(-rotationStep, 0, 0));
            }
            if (keyboard[Key.Keypad6])
            {
                if (isTraslacion) testeo.Trasladar(new Vector3(transformStep, 0, 0));
                else testeo.Rotar(new Vector3(rotationStep, 0, 0));
            }
            if (keyboard[Key.Keypad2])
            {
                if (isTraslacion) testeo.Trasladar(new Vector3(0, -transformStep, 0));
                else testeo.Rotar(new Vector3(0, -rotationStep, 0));
            }
            if (keyboard[Key.Keypad8])
            {
                if (isTraslacion) testeo.Trasladar(new Vector3(0, transformStep, 0));
                else testeo.Rotar(new Vector3(0, rotationStep, 0));
            }
            if (keyboard[Key.Keypad7])
            {
                if (isTraslacion) testeo.Trasladar(new Vector3(0, 0, -transformStep));
                else testeo.Rotar(new Vector3(0, 0, -rotationStep));
            }
            if (keyboard[Key.Keypad9])
            {
                if (isTraslacion) testeo.Trasladar(new Vector3(0, 0, transformStep));
                else testeo.Rotar(new Vector3(0, 0, rotationStep));
            }

            // ESCALADO
            // Escalado uniforme
            if (keyboard[Key.KeypadMinus])
                testeo.Escalar(new Vector3(1.0f - scaleStep, 1.0f - scaleStep, 1.0f - scaleStep));
            if (keyboard[Key.KeypadAdd])
                testeo.Escalar(new Vector3(1.0f + scaleStep, 1.0f + scaleStep, 1.0f + scaleStep));

            // Escalado por eje
            /*
            if (keyboard[Key.J])
                testeo.Escalar(new Vector3(1.0f - scaleStep, 1.0f, 1.0f));
            if (keyboard[Key.K])
                testeo.Escalar(new Vector3(1.0f + scaleStep, 1.0f, 1.0f));
            if (keyboard[Key.N])
                testeo.Escalar(new Vector3(1.0f, 1.0f - scaleStep, 1.0f));
            if (keyboard[Key.M])
                testeo.Escalar(new Vector3(1.0f, 1.0f + scaleStep, 1.0f));
            if (keyboard[Key.B])
                testeo.Escalar(new Vector3(1.0f, 1.0f, 1.0f - scaleStep));
            if (keyboard[Key.V])
                testeo.Escalar(new Vector3(1.0f, 1.0f, 1.0f + scaleStep));
            */

            //REFLEXION
            if (keyboard[Key.Left])
                testeo.Reflejar(new Vector3(-1.0f, 1.0f, 1.0f));
            if (keyboard[Key.Up])
                testeo.Reflejar(new Vector3(1.0f, -1.0f, 1.0f));
            if (keyboard[Key.Right])
                testeo.Reflejar(new Vector3(1.0f, 1.0f, -1.0f));

        }
    }

    

    bool isTraslacion = true;

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

        // Reset de transformaciones del objeto
        if (e.Key == Key.T && testeo != null)
        {
            // Recargar la escena para resetear las transformaciones
            InitializeScene();
            Console.WriteLine("Transformaciones reseteadas.");
        }

        // Switch Traslacion - Rotacion
        if (e.Key == Key.Keypad5)
            isTraslacion = !isTraslacion;

        //CAMBIAR TESTEO
        if (e.Key == Key.Number1)
            cambiarObjeto();
        if (e.Key == Key.Number2)
            cambiarParte();
        if (e.Key == Key.Number3)
            cambiarCara();
        if (e.Key == Key.Number4)
            cambiarEscenario();

    }
}