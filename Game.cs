// Game.cs
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

public class Game : GameWindow
{
    private List<Objeto> objetos;

    // Variables para el control de cámara
    private Vector3 cameraPosition;
    private Vector3 cameraFront;
    private Vector3 cameraUp;
    private float cameraYaw = -90.0f; // Inicializar mirando hacia adelante

    public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
    {
        objetos = new List<Objeto>();

        // Inicializar cámara
        cameraPosition = new Vector3(0.0f, 0.0f, 10.0f);
        cameraFront = new Vector3(0.0f, 0.0f, -1.0f);
        cameraUp = Vector3.UnitY;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        GL.ClearColor(0.2f, 0.3f, 0.4f, 1.0f);
        GL.Enable(EnableCap.DepthTest);

        InitializeScene();
    }

    private void InitializeScene()
    {
        // Crear todos los componentes de la computadora usando la clase Objeto
        CrearMonitor();
        CrearMouse();
        CrearTeclado();
        CrearPC();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        // Configurar matriz de proyección
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f),
            (float)Width / Height, 0.1f, 100.0f);
        GL.LoadMatrix(ref perspective);

        // Configurar matriz de vista con cámara simplificada
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();
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

        // Velocidad de movimiento y rotación de cámara
        float moveSpeed = 0.2f;
        float rotationSpeed = 2.0f;

        // Rotación con Q y E
        if (keyboard[Key.Q])
            cameraYaw -= rotationSpeed;
        if (keyboard[Key.E])
            cameraYaw += rotationSpeed;

        // Actualizar dirección de la cámara basado en yaw
        cameraFront.X = (float)Math.Cos(MathHelper.DegreesToRadians(cameraYaw));
        cameraFront.Z = (float)Math.Sin(MathHelper.DegreesToRadians(cameraYaw));
        cameraFront = Vector3.Normalize(cameraFront);

        // Movimiento con WASD (resto del código igual)
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

    private void CrearMonitor()
    {
        Objeto monitor = new Objeto();
        monitor.Position = new Vector3(0, 0, 0);

        // Parte: Soporte vertical (GRIS OSCURO)
        Parte soporteVertical = new Parte();
        soporteVertical.Position = new Vector3(0, -0.9f, 0);
        soporteVertical.Color = new Vector3(0.3f, 0.3f, 0.3f);

        // Cara frontal del soporte
        Cara caraFrontalSoporte = new Cara();
        caraFrontalSoporte.AddVertice(new Vertice(-0.1f, -1.0f, 0.1f, 0, 0, 1));
        caraFrontalSoporte.AddVertice(new Vertice(0.1f, -1.0f, 0.1f, 0, 0, 1));
        caraFrontalSoporte.AddVertice(new Vertice(0.1f, 1.0f, 0.1f, 0, 0, 1));
        caraFrontalSoporte.AddVertice(new Vertice(-0.1f, 1.0f, 0.1f, 0, 0, 1));

        // Cara trasera del soporte
        Cara caraTraseraSoporte = new Cara();
        caraTraseraSoporte.AddVertice(new Vertice(-0.1f, -1.0f, -0.1f, 0, 0, -1));
        caraTraseraSoporte.AddVertice(new Vertice(-0.1f, 1.0f, -0.1f, 0, 0, -1));
        caraTraseraSoporte.AddVertice(new Vertice(0.1f, 1.0f, -0.1f, 0, 0, -1));
        caraTraseraSoporte.AddVertice(new Vertice(0.1f, -1.0f, -0.1f, 0, 0, -1));

        // Cara izquierda del soporte
        Cara caraIzquierdaSoporte = new Cara();
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, -1.0f, -0.1f, -1, 0, 0));
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, -1.0f, 0.1f, -1, 0, 0));
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, 1.0f, 0.1f, -1, 0, 0));
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, 1.0f, -0.1f, -1, 0, 0));

        // Cara derecha del soporte
        Cara caraDerechaSoporte = new Cara();
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, -1.0f, -0.1f, 1, 0, 0));
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, 1.0f, -0.1f, 1, 0, 0));
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, 1.0f, 0.1f, 1, 0, 0));
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, -1.0f, 0.1f, 1, 0, 0));

        soporteVertical.AddCara(caraFrontalSoporte);
        soporteVertical.AddCara(caraTraseraSoporte);
        soporteVertical.AddCara(caraIzquierdaSoporte);
        soporteVertical.AddCara(caraDerechaSoporte);

        monitor.AddParte(soporteVertical);

        // Parte: Base del monitor (GRIS OSCURO)
        Parte baseMonitor = new Parte();
        baseMonitor.Position = new Vector3(0, -2.0f, 0);
        baseMonitor.Color = new Vector3(0.3f, 0.3f, 0.3f); // Gris más visible

        // Cara frontal de la base
        Cara caraFrontalBase = new Cara();
        caraFrontalBase.AddVertice(new Vertice(-0.8f, -0.3f, 0.8f, 0, 0, 1));
        caraFrontalBase.AddVertice(new Vertice(0.8f, -0.3f, 0.8f, 0, 0, 1));
        caraFrontalBase.AddVertice(new Vertice(0.8f, 0.3f, 0.8f, 0, 0, 1));
        caraFrontalBase.AddVertice(new Vertice(-0.8f, 0.3f, 0.8f, 0, 0, 1));

        // Cara trasera de la base
        Cara caraTraseraBase = new Cara();
        caraTraseraBase.AddVertice(new Vertice(-0.8f, -0.3f, -0.8f, 0, 0, -1));
        caraTraseraBase.AddVertice(new Vertice(-0.8f, 0.3f, -0.8f, 0, 0, -1));
        caraTraseraBase.AddVertice(new Vertice(0.8f, 0.3f, -0.8f, 0, 0, -1));
        caraTraseraBase.AddVertice(new Vertice(0.8f, -0.3f, -0.8f, 0, 0, -1));

        // Cara izquierda de la base
        Cara caraIzquierdaBase = new Cara();
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, -0.3f, -0.8f, -1, 0, 0));
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, -0.3f, 0.8f, -1, 0, 0));
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, 0.3f, 0.8f, -1, 0, 0));
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, 0.3f, -0.8f, -1, 0, 0));

        // Cara derecha de la base
        Cara caraDerechaBase = new Cara();
        caraDerechaBase.AddVertice(new Vertice(0.8f, -0.3f, -0.8f, 1, 0, 0));
        caraDerechaBase.AddVertice(new Vertice(0.8f, 0.3f, -0.8f, 1, 0, 0));
        caraDerechaBase.AddVertice(new Vertice(0.8f, 0.3f, 0.8f, 1, 0, 0));
        caraDerechaBase.AddVertice(new Vertice(0.8f, -0.3f, 0.8f, 1, 0, 0));

        // Cara superior de la base
        Cara caraSuperiorBase = new Cara();
        caraSuperiorBase.AddVertice(new Vertice(-0.8f, 0.3f, -0.8f, 0, 1, 0));
        caraSuperiorBase.AddVertice(new Vertice(-0.8f, 0.3f, 0.8f, 0, 1, 0));
        caraSuperiorBase.AddVertice(new Vertice(0.8f, 0.3f, 0.8f, 0, 1, 0));
        caraSuperiorBase.AddVertice(new Vertice(0.8f, 0.3f, -0.8f, 0, 1, 0));

        // Cara inferior de la base
        Cara caraInferiorBase = new Cara();
        caraInferiorBase.AddVertice(new Vertice(-0.8f, -0.3f, -0.8f, 0, -1, 0));
        caraInferiorBase.AddVertice(new Vertice(0.8f, -0.3f, -0.8f, 0, -1, 0));
        caraInferiorBase.AddVertice(new Vertice(0.8f, -0.3f, 0.8f, 0, -1, 0));
        caraInferiorBase.AddVertice(new Vertice(-0.8f, -0.3f, 0.8f, 0, -1, 0));

        baseMonitor.AddCara(caraFrontalBase);
        baseMonitor.AddCara(caraTraseraBase);
        baseMonitor.AddCara(caraIzquierdaBase);
        baseMonitor.AddCara(caraDerechaBase);
        baseMonitor.AddCara(caraSuperiorBase);
        baseMonitor.AddCara(caraInferiorBase);

        monitor.AddParte(baseMonitor);

        // Parte: Monitor caja
        Parte monitorCaja = new Parte();
        monitorCaja.Position = new Vector3(0, 1.0f, 0);
        monitorCaja.Color = new Vector3(0.1f, 0.1f, 0.1f); // Negro

        // Cara frontal de la pantalla
        Cara caraFrontalMonitor = new Cara();
        caraFrontalMonitor.AddVertice(new Vertice(-2.0f, -1.5f, 0.2f, 0, 0, 1));
        caraFrontalMonitor.AddVertice(new Vertice(2.0f, -1.5f, 0.2f, 0, 0, 1));
        caraFrontalMonitor.AddVertice(new Vertice(2.0f, 1.5f, 0.2f, 0, 0, 1));
        caraFrontalMonitor.AddVertice(new Vertice(-2.0f, 1.5f, 0.2f, 0, 0, 1));

        // Cara trasera de la pantalla
        Cara caraTraseraMonitor = new Cara();
        caraTraseraMonitor.AddVertice(new Vertice(-2.0f, -1.5f, -0.2f, 0, 0, -1));
        caraTraseraMonitor.AddVertice(new Vertice(-2.0f, 1.5f, -0.2f, 0, 0, -1));
        caraTraseraMonitor.AddVertice(new Vertice(2.0f, 1.5f, -0.2f, 0, 0, -1));
        caraTraseraMonitor.AddVertice(new Vertice(2.0f, -1.5f, -0.2f, 0, 0, -1));

        // Cara izquierda de la pantalla
        Cara caraIzquierdaMonitor = new Cara();
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, -1.5f, -0.2f, -1, 0, 0));
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, -1.5f, 0.2f, -1, 0, 0));
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, 1.5f, 0.2f, -1, 0, 0));
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, 1.5f, -0.2f, -1, 0, 0));

        // Cara derecha de la pantalla
        Cara caraDerechaMonitor = new Cara();
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, -1.5f, -0.2f, 1, 0, 0));
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, 1.5f, -0.2f, 1, 0, 0));
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, 1.5f, 0.2f, 1, 0, 0));
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, -1.5f, 0.2f, 1, 0, 0));

        // Cara superior de la pantalla
        Cara caraSuperiorMonitor = new Cara();
        caraSuperiorMonitor.AddVertice(new Vertice(-2.0f, 1.5f, -0.2f, 0, 1, 0));
        caraSuperiorMonitor.AddVertice(new Vertice(-2.0f, 1.5f, 0.2f, 0, 1, 0));
        caraSuperiorMonitor.AddVertice(new Vertice(2.0f, 1.5f, 0.2f, 0, 1, 0));
        caraSuperiorMonitor.AddVertice(new Vertice(2.0f, 1.5f, -0.2f, 0, 1, 0));

        // Cara inferior de la pantalla
        Cara caraInferiorMonitor = new Cara();
        caraInferiorMonitor.AddVertice(new Vertice(-2.0f, -1.5f, -0.2f, 0, -1, 0));
        caraInferiorMonitor.AddVertice(new Vertice(2.0f, -1.5f, -0.2f, 0, -1, 0));
        caraInferiorMonitor.AddVertice(new Vertice(2.0f, -1.5f, 0.2f, 0, -1, 0));
        caraInferiorMonitor.AddVertice(new Vertice(-2.0f, -1.5f, 0.2f, 0, -1, 0));

        monitorCaja.AddCara(caraFrontalMonitor);
        monitorCaja.AddCara(caraTraseraMonitor);
        monitorCaja.AddCara(caraIzquierdaMonitor);
        monitorCaja.AddCara(caraDerechaMonitor);
        monitorCaja.AddCara(caraSuperiorMonitor);
        monitorCaja.AddCara(caraInferiorMonitor);

        monitor.AddParte(monitorCaja);

        // Parte : Pantalla azul (frente)
        Parte pantallaAzul = new Parte();
        pantallaAzul.Position = new Vector3(0, 1.0f, 0);
        pantallaAzul.Color = new Vector3(0.0f, 0.5f, 1.0f); // Azul brillante

        // Solo la cara frontal azul
        Cara caraPantallaAzul = new Cara();
        caraPantallaAzul.AddVertice(new Vertice(-1.8f, -1.3f, 0.25f, 0, 0, 1));
        caraPantallaAzul.AddVertice(new Vertice(1.8f, -1.3f, 0.25f, 0, 0, 1));
        caraPantallaAzul.AddVertice(new Vertice(1.8f, 1.3f, 0.25f, 0, 0, 1));
        caraPantallaAzul.AddVertice(new Vertice(-1.8f, 1.3f, 0.25f, 0, 0, 1));

        pantallaAzul.AddCara(caraPantallaAzul);
        monitor.AddParte(pantallaAzul);

        objetos.Add(monitor);
    }

    private void CrearMouse()
    {
        Objeto mouse = new Objeto();
        mouse.Position = new Vector3(3, -2.5f, 2);

        // Parte: Cuerpo del mouse (GRIS)
        Parte cuerpoMouse = new Parte();
        cuerpoMouse.Position = new Vector3(0, 0, 0);
        cuerpoMouse.Color = new Vector3(0.5f, 0.5f, 0.5f); // Gris más visible

        // Cara frontal
        Cara caraFrontal = new Cara();
        caraFrontal.AddVertice(new Vertice(-0.5f, 0.0f, 0.8f, 0, 0, 1));
        caraFrontal.AddVertice(new Vertice(0.5f, 0.0f, 0.8f, 0, 0, 1));
        caraFrontal.AddVertice(new Vertice(0.5f, 0.3f, 0.8f, 0, 0, 1));
        caraFrontal.AddVertice(new Vertice(-0.5f, 0.3f, 0.8f, 0, 0, 1));

        // Cara trasera
        Cara caraTrasera = new Cara();
        caraTrasera.AddVertice(new Vertice(-0.5f, 0.0f, -0.8f, 0, 0, -1));
        caraTrasera.AddVertice(new Vertice(-0.5f, 0.3f, -0.8f, 0, 0, -1));
        caraTrasera.AddVertice(new Vertice(0.5f, 0.3f, -0.8f, 0, 0, -1));
        caraTrasera.AddVertice(new Vertice(0.5f, 0.0f, -0.8f, 0, 0, -1));

        // Cara izquierda
        Cara caraIzquierda = new Cara();
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.0f, -0.8f, -1, 0, 0));
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.0f, 0.8f, -1, 0, 0));
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.3f, 0.8f, -1, 0, 0));
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.3f, -0.8f, -1, 0, 0));

        // Cara derecha
        Cara caraDerecha = new Cara();
        caraDerecha.AddVertice(new Vertice(0.5f, 0.0f, -0.8f, 1, 0, 0));
        caraDerecha.AddVertice(new Vertice(0.5f, 0.3f, -0.8f, 1, 0, 0));
        caraDerecha.AddVertice(new Vertice(0.5f, 0.3f, 0.8f, 1, 0, 0));
        caraDerecha.AddVertice(new Vertice(0.5f, 0.0f, 0.8f, 1, 0, 0));

        // Cara superior
        Cara caraSuperior = new Cara();
        caraSuperior.AddVertice(new Vertice(-0.5f, 0.3f, -0.8f, 0, 1, 0));
        caraSuperior.AddVertice(new Vertice(-0.5f, 0.3f, 0.8f, 0, 1, 0));
        caraSuperior.AddVertice(new Vertice(0.5f, 0.3f, 0.8f, 0, 1, 0));
        caraSuperior.AddVertice(new Vertice(0.5f, 0.3f, -0.8f, 0, 1, 0));

        // Cara inferior
        Cara caraInferior = new Cara();
        caraInferior.AddVertice(new Vertice(-0.5f, 0.0f, -0.8f, 0, -1, 0));
        caraInferior.AddVertice(new Vertice(0.5f, 0.0f, -0.8f, 0, -1, 0));
        caraInferior.AddVertice(new Vertice(0.5f, 0.0f, 0.8f, 0, -1, 0));
        caraInferior.AddVertice(new Vertice(-0.5f, 0.0f, 0.8f, 0, -1, 0));

        cuerpoMouse.AddCara(caraFrontal);
        cuerpoMouse.AddCara(caraTrasera);
        cuerpoMouse.AddCara(caraIzquierda);
        cuerpoMouse.AddCara(caraDerecha);
        cuerpoMouse.AddCara(caraSuperior);
        cuerpoMouse.AddCara(caraInferior);

        mouse.AddParte(cuerpoMouse);

        // Parte: Botón izquierdo
        Parte botonIzquierdo = new Parte();
        botonIzquierdo.Position = new Vector3(-0.2f, 0.35f, 0);
        botonIzquierdo.Color = new Vector3(0.3f, 0.3f, 0.3f); // Gris oscuro

        Cara botonIzq = new Cara();
        botonIzq.AddVertice(new Vertice(-0.15f, 0.0f, -0.3f, 0, 1, 0));
        botonIzq.AddVertice(new Vertice(0.15f, 0.0f, -0.3f, 0, 1, 0));
        botonIzq.AddVertice(new Vertice(0.15f, 0.0f, 0.3f, 0, 1, 0));
        botonIzq.AddVertice(new Vertice(-0.15f, 0.0f, 0.3f, 0, 1, 0));

        botonIzquierdo.AddCara(botonIzq);
        mouse.AddParte(botonIzquierdo);

        // Parte: Botón derecho (AZUL)
        Parte botonDerecho = new Parte();
        botonDerecho.Position = new Vector3(0.2f, 0.35f, 0);
        botonDerecho.Color = new Vector3(0.3f, 0.3f, 0.3f); // Gris oscuro

        Cara botonDer = new Cara();
        botonDer.AddVertice(new Vertice(-0.15f, 0.0f, -0.3f, 0, 1, 0));
        botonDer.AddVertice(new Vertice(0.15f, 0.0f, -0.3f, 0, 1, 0));
        botonDer.AddVertice(new Vertice(0.15f, 0.0f, 0.3f, 0, 1, 0));
        botonDer.AddVertice(new Vertice(-0.15f, 0.0f, 0.3f, 0, 1, 0));

        botonDerecho.AddCara(botonDer);
        mouse.AddParte(botonDerecho);

        objetos.Add(mouse);
    }

    private void CrearTeclado()
    {
        Objeto teclado = new Objeto();
        teclado.Position = new Vector3(0, -2.3f, 3);

        // Parte: Base del teclado (NEGRO)
        Parte baseTeclado = new Parte();
        baseTeclado.Position = new Vector3(0, 0, 0);
        baseTeclado.Color = new Vector3(0.2f, 0.2f, 0.2f); // Negro

        // Cara frontal de la base
        Cara caraFrontalTeclado = new Cara();
        caraFrontalTeclado.AddVertice(new Vertice(-2.5f, 0.0f, 1.0f, 0, 0, 1));
        caraFrontalTeclado.AddVertice(new Vertice(2.5f, 0.0f, 1.0f, 0, 0, 1));
        caraFrontalTeclado.AddVertice(new Vertice(2.5f, 0.2f, 1.0f, 0, 0, 1));
        caraFrontalTeclado.AddVertice(new Vertice(-2.5f, 0.2f, 1.0f, 0, 0, 1));

        // Cara trasera de la base
        Cara caraTraseraTeclado = new Cara();
        caraTraseraTeclado.AddVertice(new Vertice(-2.5f, 0.0f, -1.0f, 0, 0, -1));
        caraTraseraTeclado.AddVertice(new Vertice(-2.5f, 0.2f, -1.0f, 0, 0, -1));
        caraTraseraTeclado.AddVertice(new Vertice(2.5f, 0.2f, -1.0f, 0, 0, -1));
        caraTraseraTeclado.AddVertice(new Vertice(2.5f, 0.0f, -1.0f, 0, 0, -1));

        // Cara izquierda de la base
        Cara caraIzquierdaTeclado = new Cara();
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.0f, -1.0f, -1, 0, 0));
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.0f, 1.0f, -1, 0, 0));
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.2f, 1.0f, -1, 0, 0));
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.2f, -1.0f, -1, 0, 0));

        // Cara derecha de la base
        Cara caraDerechaTeclado = new Cara();
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.0f, -1.0f, 1, 0, 0));
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.2f, -1.0f, 1, 0, 0));
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.2f, 1.0f, 1, 0, 0));
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.0f, 1.0f, 1, 0, 0));

        // Cara superior de la base
        Cara caraSuperiorBase = new Cara();
        caraSuperiorBase.AddVertice(new Vertice(-2.5f, 0.2f, -1.0f, 0, 1, 0));
        caraSuperiorBase.AddVertice(new Vertice(-2.5f, 0.2f, 1.0f, 0, 1, 0));
        caraSuperiorBase.AddVertice(new Vertice(2.5f, 0.2f, 1.0f, 0, 1, 0));
        caraSuperiorBase.AddVertice(new Vertice(2.5f, 0.2f, -1.0f, 0, 1, 0));

        // Cara inferior de la base
        Cara caraInferiorBase = new Cara();
        caraInferiorBase.AddVertice(new Vertice(-2.5f, 0.0f, -1.0f, 0, -1, 0));
        caraInferiorBase.AddVertice(new Vertice(2.5f, 0.0f, -1.0f, 0, -1, 0));
        caraInferiorBase.AddVertice(new Vertice(2.5f, 0.0f, 1.0f, 0, -1, 0));
        caraInferiorBase.AddVertice(new Vertice(-2.5f, 0.0f, 1.0f, 0, -1, 0));

        baseTeclado.AddCara(caraFrontalTeclado);
        baseTeclado.AddCara(caraTraseraTeclado);
        baseTeclado.AddCara(caraIzquierdaTeclado);
        baseTeclado.AddCara(caraDerechaTeclado);
        baseTeclado.AddCara(caraSuperiorBase);
        baseTeclado.AddCara(caraInferiorBase);

        teclado.AddParte(baseTeclado);

        // Parte: Teclas (BLANCO)
        Parte teclas = new Parte();
        teclas.Position = new Vector3(0, 0.25f, 0);
        teclas.Color = new Vector3(1.0f, 1.0f, 1.0f); // Blanco

        // Teclas
        for (int i = -5; i <= 5; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                float x = i * 0.4f;
                float z = j * 0.3f;

                Cara tecla = new Cara();
                tecla.AddVertice(new Vertice(x - 0.15f, 0.0f, z - 0.1f, 0, 1, 0));
                tecla.AddVertice(new Vertice(x + 0.15f, 0.0f, z - 0.1f, 0, 1, 0));
                tecla.AddVertice(new Vertice(x + 0.15f, 0.0f, z + 0.1f, 0, 1, 0));
                tecla.AddVertice(new Vertice(x - 0.15f, 0.0f, z + 0.1f, 0, 1, 0));

                teclas.AddCara(tecla);
            }
        }

        teclado.AddParte(teclas);
        objetos.Add(teclado);
    }

    private void CrearPC()
    {
        Objeto pc = new Objeto();
        pc.Position = new Vector3(-4, -1, 0);

        // Parte: Carcasa principal (GRIS OSCURO)
        Parte carcasa = new Parte();
        carcasa.Position = new Vector3(0, 0, 0);
        carcasa.Color = new Vector3(0.25f, 0.25f, 0.25f); // Gris oscuro

        // Cara frontal
        Cara caraFrontal = new Cara();
        caraFrontal.AddVertice(new Vertice(-0.8f, -2.0f, 1.0f, 0, 0, 1));
        caraFrontal.AddVertice(new Vertice(0.8f, -2.0f, 1.0f, 0, 0, 1));
        caraFrontal.AddVertice(new Vertice(0.8f, 2.0f, 1.0f, 0, 0, 1));
        caraFrontal.AddVertice(new Vertice(-0.8f, 2.0f, 1.0f, 0, 0, 1));

        // Cara trasera
        Cara caraTrasera = new Cara();
        caraTrasera.AddVertice(new Vertice(-0.8f, -2.0f, -1.0f, 0, 0, -1));
        caraTrasera.AddVertice(new Vertice(-0.8f, 2.0f, -1.0f, 0, 0, -1));
        caraTrasera.AddVertice(new Vertice(0.8f, 2.0f, -1.0f, 0, 0, -1));
        caraTrasera.AddVertice(new Vertice(0.8f, -2.0f, -1.0f, 0, 0, -1));

        // Cara izquierda
        Cara caraIzquierda = new Cara();
        caraIzquierda.AddVertice(new Vertice(-0.8f, -2.0f, -1.0f, -1, 0, 0));
        caraIzquierda.AddVertice(new Vertice(-0.8f, -2.0f, 1.0f, -1, 0, 0));
        caraIzquierda.AddVertice(new Vertice(-0.8f, 2.0f, 1.0f, -1, 0, 0));
        caraIzquierda.AddVertice(new Vertice(-0.8f, 2.0f, -1.0f, -1, 0, 0));

        // Cara derecha
        Cara caraDerecha = new Cara();
        caraDerecha.AddVertice(new Vertice(0.8f, -2.0f, -1.0f, 1, 0, 0));
        caraDerecha.AddVertice(new Vertice(0.8f, 2.0f, -1.0f, 1, 0, 0));
        caraDerecha.AddVertice(new Vertice(0.8f, 2.0f, 1.0f, 1, 0, 0));
        caraDerecha.AddVertice(new Vertice(0.8f, -2.0f, 1.0f, 1, 0, 0));

        // Cara superior
        Cara caraSuperior = new Cara();
        caraSuperior.AddVertice(new Vertice(-0.8f, 2.0f, -1.0f, 0, 1, 0));
        caraSuperior.AddVertice(new Vertice(-0.8f, 2.0f, 1.0f, 0, 1, 0));
        caraSuperior.AddVertice(new Vertice(0.8f, 2.0f, 1.0f, 0, 1, 0));
        caraSuperior.AddVertice(new Vertice(0.8f, 2.0f, -1.0f, 0, 1, 0));

        // Cara inferior
        Cara caraInferior = new Cara();
        caraInferior.AddVertice(new Vertice(-0.8f, -2.0f, -1.0f, 0, -1, 0));
        caraInferior.AddVertice(new Vertice(0.8f, -2.0f, -1.0f, 0, -1, 0));
        caraInferior.AddVertice(new Vertice(0.8f, -2.0f, 1.0f, 0, -1, 0));
        caraInferior.AddVertice(new Vertice(-0.8f, -2.0f, 1.0f, 0, -1, 0));

        carcasa.AddCara(caraFrontal);
        carcasa.AddCara(caraTrasera);
        carcasa.AddCara(caraIzquierda);
        carcasa.AddCara(caraDerecha);
        carcasa.AddCara(caraSuperior);
        carcasa.AddCara(caraInferior);

        pc.AddParte(carcasa);

        // Parte: Botón de encendido (VERDE)
        Parte botonEncendido = new Parte();
        botonEncendido.Position = new Vector3(0.6f, 1.5f, 1.05f);
        botonEncendido.Color = new Vector3(0.0f, 1.0f, 0.0f); // VERDE BRILLANTE

        Cara boton = new Cara();
        boton.AddVertice(new Vertice(-0.1f, -0.1f, 0.0f, 0, 0, 1));
        boton.AddVertice(new Vertice(0.1f, -0.1f, 0.0f, 0, 0, 1));
        boton.AddVertice(new Vertice(0.1f, 0.1f, 0.0f, 0, 0, 1));
        boton.AddVertice(new Vertice(-0.1f, 0.1f, 0.0f, 0, 0, 1));

        botonEncendido.AddCara(boton);
        pc.AddParte(botonEncendido);

        // Parte 3: Rejillas de ventilación (AMARILLO)
        Parte rejillas = new Parte();
        rejillas.Position = new Vector3(0, 0, 1.05f);
        rejillas.Color = new Vector3(1.0f, 1.0f, 0.0f); // AMARILLO

        // Rejillas
        for (int i = -3; i <= 3; i++)
        {
            float y = i * 0.3f;

            Cara rejilla = new Cara();
            rejilla.AddVertice(new Vertice(-0.6f, y - 0.05f, 0.0f, 0, 0, 1));
            rejilla.AddVertice(new Vertice(0.6f, y - 0.05f, 0.0f, 0, 0, 1));
            rejilla.AddVertice(new Vertice(0.6f, y + 0.05f, 0.0f, 0, 0, 1));
            rejilla.AddVertice(new Vertice(-0.6f, y + 0.05f, 0.0f, 0, 0, 1));

            rejillas.AddCara(rejilla);
        }

        pc.AddParte(rejillas);
        objetos.Add(pc);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);
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
            cameraYaw = -90.0f; // Resetear rotación
        }
    }
}