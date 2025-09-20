// ObjetoFactory.cs
using System;
using OpenTK;

public static class ObjetoFactory
{
    public static Escenario CrearEscenarioEscritorio()
    {
        var escenario = new Escenario();

        // Crear objetos 
        var monitor = CrearMonitor();
        var mouse = CrearMouse();
        var teclado = CrearTeclado();
        var pc = CrearPC();

        // Agregar objetos al escenario
        escenario.AddHijo("monitor", monitor);
        escenario.AddHijo("mouse", mouse);
        escenario.AddHijo("teclado", teclado);
        escenario.AddHijo("pc", pc);

        return escenario;
    }

    private static Objeto CrearMonitor()
    {
        Objeto monitor = new Objeto(new Vector3(0, 0, 0));

        // Parte: Soporte vertical (GRIS OSCURO)
        Parte soporteVertical = new Parte();

        // Cara frontal del soporte
        Cara caraFrontalSoporte = new Cara();
        caraFrontalSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraFrontalSoporte.AddHijo("v1", new Vertice(-0.1f, -1.9f, 0.1f));
        caraFrontalSoporte.AddHijo("v2", new Vertice(0.1f, -1.9f, 0.1f));
        caraFrontalSoporte.AddHijo("v3", new Vertice(0.1f, 0.1f, 0.1f));
        caraFrontalSoporte.AddHijo("v4", new Vertice(-0.1f, 0.1f, 0.1f));

        // Cara trasera del soporte
        Cara caraTraseraSoporte = new Cara();
        caraTraseraSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraTraseraSoporte.AddHijo("v1", new Vertice(-0.1f, -1.9f, -0.1f));
        caraTraseraSoporte.AddHijo("v2", new Vertice(-0.1f, 0.1f, -0.1f));
        caraTraseraSoporte.AddHijo("v3", new Vertice(0.1f, 0.1f, -0.1f));
        caraTraseraSoporte.AddHijo("v4", new Vertice(0.1f, -1.9f, -0.1f));

        // Cara izquierda del soporte
        Cara caraIzquierdaSoporte = new Cara();
        caraIzquierdaSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraIzquierdaSoporte.AddHijo("v1", new Vertice(-0.1f, -1.9f, -0.1f));
        caraIzquierdaSoporte.AddHijo("v2", new Vertice(-0.1f, -1.9f, 0.1f));
        caraIzquierdaSoporte.AddHijo("v3", new Vertice(-0.1f, 0.1f, 0.1f));
        caraIzquierdaSoporte.AddHijo("v4", new Vertice(-0.1f, 0.1f, -0.1f));

        // Cara derecha del soporte
        Cara caraDerechaSoporte = new Cara();
        caraDerechaSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraDerechaSoporte.AddHijo("v1", new Vertice(0.1f, -1.9f, -0.1f));
        caraDerechaSoporte.AddHijo("v2", new Vertice(0.1f, 0.1f, -0.1f));
        caraDerechaSoporte.AddHijo("v3", new Vertice(0.1f, 0.1f, 0.1f));
        caraDerechaSoporte.AddHijo("v4", new Vertice(0.1f, -1.9f, 0.1f));

        soporteVertical.AddHijo("caraFrontal", caraFrontalSoporte);
        soporteVertical.AddHijo("caraTrasera", caraTraseraSoporte);
        soporteVertical.AddHijo("caraIzquierda", caraIzquierdaSoporte);
        soporteVertical.AddHijo("caraDerecha", caraDerechaSoporte);

        monitor.AddHijo("soporteVertical", soporteVertical);

        // Parte: Base del monitor (GRIS OSCURO)
        Parte baseMonitor = new Parte();

        // Cara frontal de la base
        Cara caraFrontalBase = new Cara();
        caraFrontalBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraFrontalBase.AddHijo("v1", new Vertice(-0.8f, -2.3f, 0.8f));
        caraFrontalBase.AddHijo("v2", new Vertice(0.8f, -2.3f, 0.8f));
        caraFrontalBase.AddHijo("v3", new Vertice(0.8f, -1.7f, 0.8f));
        caraFrontalBase.AddHijo("v4", new Vertice(-0.8f, -1.7f, 0.8f));

        // Cara trasera de la base
        Cara caraTraseraBase = new Cara();
        caraTraseraBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraTraseraBase.AddHijo("v1", new Vertice(-0.8f, -2.3f, -0.8f));
        caraTraseraBase.AddHijo("v2", new Vertice(-0.8f, -1.7f, -0.8f));
        caraTraseraBase.AddHijo("v3", new Vertice(0.8f, -1.7f, -0.8f));
        caraTraseraBase.AddHijo("v4", new Vertice(0.8f, -2.3f, -0.8f));

        // Cara izquierda de la base
        Cara caraIzquierdaBase = new Cara();
        caraIzquierdaBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraIzquierdaBase.AddHijo("v1", new Vertice(-0.8f, -2.3f, -0.8f));
        caraIzquierdaBase.AddHijo("v2", new Vertice(-0.8f, -2.3f, 0.8f));
        caraIzquierdaBase.AddHijo("v3", new Vertice(-0.8f, -1.7f, 0.8f));
        caraIzquierdaBase.AddHijo("v4", new Vertice(-0.8f, -1.7f, -0.8f));

        // Cara derecha de la base
        Cara caraDerechaBase = new Cara();
        caraDerechaBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraDerechaBase.AddHijo("v1", new Vertice(0.8f, -2.3f, -0.8f));
        caraDerechaBase.AddHijo("v2", new Vertice(0.8f, -1.7f, -0.8f));
        caraDerechaBase.AddHijo("v3", new Vertice(0.8f, -1.7f, 0.8f));
        caraDerechaBase.AddHijo("v4", new Vertice(0.8f, -2.3f, 0.8f));

        // Cara superior de la base
        Cara caraSuperiorBase = new Cara();
        caraSuperiorBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraSuperiorBase.AddHijo("v1", new Vertice(-0.8f, -1.7f, -0.8f));
        caraSuperiorBase.AddHijo("v2", new Vertice(-0.8f, -1.7f, 0.8f));
        caraSuperiorBase.AddHijo("v3", new Vertice(0.8f, -1.7f, 0.8f));
        caraSuperiorBase.AddHijo("v4", new Vertice(0.8f, -1.7f, -0.8f));

        // Cara inferior de la base
        Cara caraInferiorBase = new Cara();
        caraInferiorBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraInferiorBase.AddHijo("v1", new Vertice(-0.8f, -2.3f, -0.8f));
        caraInferiorBase.AddHijo("v2", new Vertice(0.8f, -2.3f, -0.8f));
        caraInferiorBase.AddHijo("v3", new Vertice(0.8f, -2.3f, 0.8f));
        caraInferiorBase.AddHijo("v4", new Vertice(-0.8f, -2.3f, 0.8f));

        baseMonitor.AddHijo("caraFrontal", caraFrontalBase);
        baseMonitor.AddHijo("caraTrasera", caraTraseraBase);
        baseMonitor.AddHijo("caraIzquierda", caraIzquierdaBase);
        baseMonitor.AddHijo("caraDerecha", caraDerechaBase);
        baseMonitor.AddHijo("caraSuperior", caraSuperiorBase);
        baseMonitor.AddHijo("caraInferior", caraInferiorBase);

        monitor.AddHijo("baseMonitor", baseMonitor);

        // Parte: Monitor caja (NEGRO)
        Parte monitorCaja = new Parte();

        // Cara frontal de la pantalla
        Cara caraFrontalMonitor = new Cara();
        caraFrontalMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraFrontalMonitor.AddHijo("v1", new Vertice(-2.0f, -0.5f, 0.2f));
        caraFrontalMonitor.AddHijo("v2", new Vertice(2.0f, -0.5f, 0.2f));
        caraFrontalMonitor.AddHijo("v3", new Vertice(2.0f, 2.5f, 0.2f));
        caraFrontalMonitor.AddHijo("v4", new Vertice(-2.0f, 2.5f, 0.2f));

        // Cara trasera de la pantalla
        Cara caraTraseraMonitor = new Cara();
        caraTraseraMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraTraseraMonitor.AddHijo("v1", new Vertice(-2.0f, -0.5f, -0.2f));
        caraTraseraMonitor.AddHijo("v2", new Vertice(-2.0f, 2.5f, -0.2f));
        caraTraseraMonitor.AddHijo("v3", new Vertice(2.0f, 2.5f, -0.2f));
        caraTraseraMonitor.AddHijo("v4", new Vertice(2.0f, -0.5f, -0.2f));

        // Cara izquierda de la pantalla
        Cara caraIzquierdaMonitor = new Cara();
        caraIzquierdaMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraIzquierdaMonitor.AddHijo("v1", new Vertice(-2.0f, -0.5f, -0.2f));
        caraIzquierdaMonitor.AddHijo("v2", new Vertice(-2.0f, -0.5f, 0.2f));
        caraIzquierdaMonitor.AddHijo("v3", new Vertice(-2.0f, 2.5f, 0.2f));
        caraIzquierdaMonitor.AddHijo("v4", new Vertice(-2.0f, 2.5f, -0.2f));

        // Cara derecha de la pantalla
        Cara caraDerechaMonitor = new Cara();
        caraDerechaMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraDerechaMonitor.AddHijo("v1", new Vertice(2.0f, -0.5f, -0.2f));
        caraDerechaMonitor.AddHijo("v2", new Vertice(2.0f, 2.5f, -0.2f));
        caraDerechaMonitor.AddHijo("v3", new Vertice(2.0f, 2.5f, 0.2f));
        caraDerechaMonitor.AddHijo("v4", new Vertice(2.0f, -0.5f, 0.2f));

        // Cara superior de la pantalla
        Cara caraSuperiorMonitor = new Cara();
        caraSuperiorMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraSuperiorMonitor.AddHijo("v1", new Vertice(-2.0f, 2.5f, -0.2f));
        caraSuperiorMonitor.AddHijo("v2", new Vertice(-2.0f, 2.5f, 0.2f));
        caraSuperiorMonitor.AddHijo("v3", new Vertice(2.0f, 2.5f, 0.2f));
        caraSuperiorMonitor.AddHijo("v4", new Vertice(2.0f, 2.5f, -0.2f));

        // Cara inferior de la pantalla
        Cara caraInferiorMonitor = new Cara();
        caraInferiorMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraInferiorMonitor.AddHijo("v1", new Vertice(-2.0f, -0.5f, -0.2f));
        caraInferiorMonitor.AddHijo("v2", new Vertice(2.0f, -0.5f, -0.2f));
        caraInferiorMonitor.AddHijo("v3", new Vertice(2.0f, -0.5f, 0.2f));
        caraInferiorMonitor.AddHijo("v4", new Vertice(-2.0f, -0.5f, 0.2f));

        monitorCaja.AddHijo("caraFrontal", caraFrontalMonitor);
        monitorCaja.AddHijo("caraTrasera", caraTraseraMonitor);
        monitorCaja.AddHijo("caraIzquierda", caraIzquierdaMonitor);
        monitorCaja.AddHijo("caraDerecha", caraDerechaMonitor);
        monitorCaja.AddHijo("caraSuperior", caraSuperiorMonitor);
        monitorCaja.AddHijo("caraInferior", caraInferiorMonitor);

        monitor.AddHijo("monitorCaja", monitorCaja);

        // Parte: Pantalla azul (frente)
        Parte pantallaAzul = new Parte();

        // Solo la cara frontal azul
        Cara caraPantallaAzul = new Cara();
        caraPantallaAzul.Color = new float[] { 0.0f, 0.5f, 1.0f };
        caraPantallaAzul.AddHijo("v1", new Vertice(-1.8f, -0.3f, 0.25f));
        caraPantallaAzul.AddHijo("v2", new Vertice(1.8f, -0.3f, 0.25f));
        caraPantallaAzul.AddHijo("v3", new Vertice(1.8f, 2.3f, 0.25f));
        caraPantallaAzul.AddHijo("v4", new Vertice(-1.8f, 2.3f, 0.25f));

        pantallaAzul.AddHijo("pantalla", caraPantallaAzul);
        monitor.AddHijo("pantallaAzul", pantallaAzul);

        return monitor;
    }

    private static Objeto CrearMouse()
    {
        Objeto mouse = new Objeto(new Vector3(3, -2.5f, 2));

        // Parte: Cuerpo del mouse (GRIS)
        Parte cuerpoMouse = new Parte();

        // Cara frontal
        Cara caraFrontal = new Cara();
        caraFrontal.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraFrontal.AddHijo("v1", new Vertice(-0.5f, 0.0f, 0.8f));
        caraFrontal.AddHijo("v2", new Vertice(0.5f, 0.0f, 0.8f));
        caraFrontal.AddHijo("v3", new Vertice(0.5f, 0.3f, 0.8f));
        caraFrontal.AddHijo("v4", new Vertice(-0.5f, 0.3f, 0.8f));

        // Cara trasera
        Cara caraTrasera = new Cara();
        caraTrasera.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraTrasera.AddHijo("v1", new Vertice(-0.5f, 0.0f, -0.8f));
        caraTrasera.AddHijo("v2", new Vertice(-0.5f, 0.3f, -0.8f));
        caraTrasera.AddHijo("v3", new Vertice(0.5f, 0.3f, -0.8f));
        caraTrasera.AddHijo("v4", new Vertice(0.5f, 0.0f, -0.8f));

        // Cara izquierda
        Cara caraIzquierda = new Cara();
        caraIzquierda.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraIzquierda.AddHijo("v1", new Vertice(-0.5f, 0.0f, -0.8f));
        caraIzquierda.AddHijo("v2", new Vertice(-0.5f, 0.0f, 0.8f));
        caraIzquierda.AddHijo("v3", new Vertice(-0.5f, 0.3f, 0.8f));
        caraIzquierda.AddHijo("v4", new Vertice(-0.5f, 0.3f, -0.8f));

        // Cara derecha
        Cara caraDerecha = new Cara();
        caraDerecha.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraDerecha.AddHijo("v1", new Vertice(0.5f, 0.0f, -0.8f));
        caraDerecha.AddHijo("v2", new Vertice(0.5f, 0.3f, -0.8f));
        caraDerecha.AddHijo("v3", new Vertice(0.5f, 0.3f, 0.8f));
        caraDerecha.AddHijo("v4", new Vertice(0.5f, 0.0f, 0.8f));

        // Cara superior
        Cara caraSuperior = new Cara();
        caraSuperior.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraSuperior.AddHijo("v1", new Vertice(-0.5f, 0.3f, -0.8f));
        caraSuperior.AddHijo("v2", new Vertice(-0.5f, 0.3f, 0.8f));
        caraSuperior.AddHijo("v3", new Vertice(0.5f, 0.3f, 0.8f));
        caraSuperior.AddHijo("v4", new Vertice(0.5f, 0.3f, -0.8f));

        // Cara inferior
        Cara caraInferior = new Cara();
        caraInferior.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraInferior.AddHijo("v1", new Vertice(-0.5f, 0.0f, -0.8f));
        caraInferior.AddHijo("v2", new Vertice(0.5f, 0.0f, -0.8f));
        caraInferior.AddHijo("v3", new Vertice(0.5f, 0.0f, 0.8f));
        caraInferior.AddHijo("v4", new Vertice(-0.5f, 0.0f, 0.8f));

        cuerpoMouse.AddHijo("caraFrontal", caraFrontal);
        cuerpoMouse.AddHijo("caraTrasera", caraTrasera);
        cuerpoMouse.AddHijo("caraIzquierda", caraIzquierda);
        cuerpoMouse.AddHijo("caraDerecha", caraDerecha);
        cuerpoMouse.AddHijo("caraSuperior", caraSuperior);
        cuerpoMouse.AddHijo("caraInferior", caraInferior);

        mouse.AddHijo("cuerpoMouse", cuerpoMouse);

        // Parte: Botón izquierdo
        Parte botonIzquierdo = new Parte();

        Cara botonIzq = new Cara();
        botonIzq.Color = new float[] { 0.3f, 0.3f, 0.3f };
        botonIzq.AddHijo("v1", new Vertice(-0.35f, 0.35f, -0.3f));
        botonIzq.AddHijo("v2", new Vertice(-0.05f, 0.35f, -0.3f));
        botonIzq.AddHijo("v3", new Vertice(-0.05f, 0.35f, 0.3f));
        botonIzq.AddHijo("v4", new Vertice(-0.35f, 0.35f, 0.3f));

        botonIzquierdo.AddHijo("boton", botonIzq);
        mouse.AddHijo("botonIzquierdo", botonIzquierdo);

        // Parte: Botón derecho
        Parte botonDerecho = new Parte();

        Cara botonDer = new Cara();
        botonDer.Color = new float[] { 0.3f, 0.3f, 0.3f };
        botonDer.AddHijo("v1", new Vertice(0.05f, 0.35f, -0.3f));
        botonDer.AddHijo("v2", new Vertice(0.35f, 0.35f, -0.3f));
        botonDer.AddHijo("v3", new Vertice(0.35f, 0.35f, 0.3f));
        botonDer.AddHijo("v4", new Vertice(0.05f, 0.35f, 0.3f));

        botonDerecho.AddHijo("boton", botonDer);
        mouse.AddHijo("botonDerecho", botonDerecho);

        return mouse;
    }

    private static Objeto CrearTeclado()
    {
        Objeto teclado = new Objeto(new Vector3(0, -2.3f, 3));

        // Parte: Base del teclado (NEGRO)
        Parte baseTeclado = new Parte();

        // Cara frontal de la base
        Cara caraFrontalTeclado = new Cara();
        caraFrontalTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraFrontalTeclado.AddHijo("v1", new Vertice(-2.5f, 0.0f, 1.0f));
        caraFrontalTeclado.AddHijo("v2", new Vertice(2.5f, 0.0f, 1.0f));
        caraFrontalTeclado.AddHijo("v3", new Vertice(2.5f, 0.2f, 1.0f));
        caraFrontalTeclado.AddHijo("v4", new Vertice(-2.5f, 0.2f, 1.0f));

        // Cara trasera de la base
        Cara caraTraseraTeclado = new Cara();
        caraTraseraTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraTraseraTeclado.AddHijo("v1", new Vertice(-2.5f, 0.0f, -1.0f));
        caraTraseraTeclado.AddHijo("v2", new Vertice(-2.5f, 0.2f, -1.0f));
        caraTraseraTeclado.AddHijo("v3", new Vertice(2.5f, 0.2f, -1.0f));
        caraTraseraTeclado.AddHijo("v4", new Vertice(2.5f, 0.0f, -1.0f));

        // Cara izquierda de la base
        Cara caraIzquierdaTeclado = new Cara();
        caraIzquierdaTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraIzquierdaTeclado.AddHijo("v1", new Vertice(-2.5f, 0.0f, -1.0f));
        caraIzquierdaTeclado.AddHijo("v2", new Vertice(-2.5f, 0.0f, 1.0f));
        caraIzquierdaTeclado.AddHijo("v3", new Vertice(-2.5f, 0.2f, 1.0f));
        caraIzquierdaTeclado.AddHijo("v4", new Vertice(-2.5f, 0.2f, -1.0f));

        // Cara derecha de la base
        Cara caraDerechaTeclado = new Cara();
        caraDerechaTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraDerechaTeclado.AddHijo("v1", new Vertice(2.5f, 0.0f, -1.0f));
        caraDerechaTeclado.AddHijo("v2", new Vertice(2.5f, 0.2f, -1.0f));
        caraDerechaTeclado.AddHijo("v3", new Vertice(2.5f, 0.2f, 1.0f));
        caraDerechaTeclado.AddHijo("v4", new Vertice(2.5f, 0.0f, 1.0f));

        // Cara superior de la base
        Cara caraSuperiorBase = new Cara();
        caraSuperiorBase.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraSuperiorBase.AddHijo("v1", new Vertice(-2.5f, 0.2f, -1.0f));
        caraSuperiorBase.AddHijo("v2", new Vertice(-2.5f, 0.2f, 1.0f));
        caraSuperiorBase.AddHijo("v3", new Vertice(2.5f, 0.2f, 1.0f));
        caraSuperiorBase.AddHijo("v4", new Vertice(2.5f, 0.2f, -1.0f));

        // Cara inferior de la base
        Cara caraInferiorBase = new Cara();
        caraInferiorBase.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraInferiorBase.AddHijo("v1", new Vertice(-2.5f, 0.0f, -1.0f));
        caraInferiorBase.AddHijo("v2", new Vertice(2.5f, 0.0f, -1.0f));
        caraInferiorBase.AddHijo("v3", new Vertice(2.5f, 0.0f, 1.0f));
        caraInferiorBase.AddHijo("v4", new Vertice(-2.5f, 0.0f, 1.0f));

        baseTeclado.AddHijo("caraFrontal", caraFrontalTeclado);
        baseTeclado.AddHijo("caraTrasera", caraTraseraTeclado);
        baseTeclado.AddHijo("caraIzquierda", caraIzquierdaTeclado);
        baseTeclado.AddHijo("caraDerecha", caraDerechaTeclado);
        baseTeclado.AddHijo("caraSuperior", caraSuperiorBase);
        baseTeclado.AddHijo("caraInferior", caraInferiorBase);

        teclado.AddHijo("baseTeclado", baseTeclado);

        // Parte: Teclas (BLANCO)
        Parte teclas = new Parte();

        // Crear teclas en una cuadrícula
        int teclaId = 0;
        for (int i = -5; i <= 5; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                float x = i * 0.4f;
                float z = j * 0.3f;

                Cara tecla = new Cara();
                tecla.Color = new float[] { 1.0f, 1.0f, 1.0f };
                tecla.AddHijo("v1", new Vertice(x - 0.15f, 0.25f, z - 0.1f));
                tecla.AddHijo("v2", new Vertice(x + 0.15f, 0.25f, z - 0.1f));
                tecla.AddHijo("v3", new Vertice(x + 0.15f, 0.25f, z + 0.1f));
                tecla.AddHijo("v4", new Vertice(x - 0.15f, 0.25f, z + 0.1f));

                teclas.AddHijo($"tecla_{teclaId}", tecla);
                teclaId++;
            }
        }

        teclado.AddHijo("teclas", teclas);
        return teclado;
    }

    private static Objeto CrearPC()
    {
        Objeto pc = new Objeto(new Vector3(-4, -1, 0));

        // Parte: Carcasa principal (GRIS OSCURO)
        Parte carcasa = new Parte();

        // Cara frontal
        Cara caraFrontal = new Cara();
        caraFrontal.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraFrontal.AddHijo("v1", new Vertice(-0.8f, -2.0f, 1.0f));
        caraFrontal.AddHijo("v2", new Vertice(0.8f, -2.0f, 1.0f));
        caraFrontal.AddHijo("v3", new Vertice(0.8f, 2.0f, 1.0f));
        caraFrontal.AddHijo("v4", new Vertice(-0.8f, 2.0f, 1.0f));

        // Cara trasera
        Cara caraTrasera = new Cara();
        caraTrasera.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraTrasera.AddHijo("v1", new Vertice(-0.8f, -2.0f, -1.0f));
        caraTrasera.AddHijo("v2", new Vertice(-0.8f, 2.0f, -1.0f));
        caraTrasera.AddHijo("v3", new Vertice(0.8f, 2.0f, -1.0f));
        caraTrasera.AddHijo("v4", new Vertice(0.8f, -2.0f, -1.0f));

        // Cara izquierda
        Cara caraIzquierda = new Cara();
        caraIzquierda.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraIzquierda.AddHijo("v1", new Vertice(-0.8f, -2.0f, -1.0f));
        caraIzquierda.AddHijo("v2", new Vertice(-0.8f, -2.0f, 1.0f));
        caraIzquierda.AddHijo("v3", new Vertice(-0.8f, 2.0f, 1.0f));
        caraIzquierda.AddHijo("v4", new Vertice(-0.8f, 2.0f, -1.0f));

        // Cara derecha
        Cara caraDerecha = new Cara();
        caraDerecha.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraDerecha.AddHijo("v1", new Vertice(0.8f, -2.0f, -1.0f));
        caraDerecha.AddHijo("v2", new Vertice(0.8f, 2.0f, -1.0f));
        caraDerecha.AddHijo("v3", new Vertice(0.8f, 2.0f, 1.0f));
        caraDerecha.AddHijo("v4", new Vertice(0.8f, -2.0f, 1.0f));

        // Cara superior
        Cara caraSuperior = new Cara();
        caraSuperior.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraSuperior.AddHijo("v1", new Vertice(-0.8f, 2.0f, -1.0f));
        caraSuperior.AddHijo("v2", new Vertice(-0.8f, 2.0f, 1.0f));
        caraSuperior.AddHijo("v3", new Vertice(0.8f, 2.0f, 1.0f));
        caraSuperior.AddHijo("v4", new Vertice(0.8f, 2.0f, -1.0f));

        // Cara inferior
        Cara caraInferior = new Cara();
        caraInferior.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraInferior.AddHijo("v1", new Vertice(-0.8f, -2.0f, -1.0f));
        caraInferior.AddHijo("v2", new Vertice(0.8f, -2.0f, -1.0f));
        caraInferior.AddHijo("v3", new Vertice(0.8f, -2.0f, 1.0f));
        caraInferior.AddHijo("v4", new Vertice(-0.8f, -2.0f, 1.0f));

        carcasa.AddHijo("caraFrontal", caraFrontal);
        carcasa.AddHijo("caraTrasera", caraTrasera);
        carcasa.AddHijo("caraIzquierda", caraIzquierda);
        carcasa.AddHijo("caraDerecha", caraDerecha);
        carcasa.AddHijo("caraSuperior", caraSuperior);
        carcasa.AddHijo("caraInferior", caraInferior);

        pc.AddHijo("carcasa", carcasa);

        // Parte: Botón de encendido (VERDE)
        Parte botonEncendido = new Parte();

        Cara boton = new Cara();
        boton.Color = new float[] { 0.0f, 1.0f, 0.0f };
        boton.AddHijo("v1", new Vertice(0.5f, 1.4f, 1.05f));
        boton.AddHijo("v2", new Vertice(0.7f, 1.4f, 1.05f));
        boton.AddHijo("v3", new Vertice(0.7f, 1.6f, 1.05f));
        boton.AddHijo("v4", new Vertice(0.5f, 1.6f, 1.05f));

        botonEncendido.AddHijo("boton", boton);
        pc.AddHijo("botonEncendido", botonEncendido);

        // Parte: Rejillas de ventilación (AMARILLO)
        Parte rejillas = new Parte();

        // Crear rejillas horizontales
        int rejillaId = 0;
        for (int i = -3; i <= 3; i++)
        {
            float y = i * 0.3f;

            Cara rejilla = new Cara();
            rejilla.Color = new float[] { 1.0f, 1.0f, 0.0f };
            rejilla.AddHijo("v1", new Vertice(-0.6f, y - 0.05f, 1.05f));
            rejilla.AddHijo("v2", new Vertice(0.6f, y - 0.05f, 1.05f));
            rejilla.AddHijo("v3", new Vertice(0.6f, y + 0.05f, 1.05f));
            rejilla.AddHijo("v4", new Vertice(-0.6f, y + 0.05f, 1.05f));

            rejillas.AddHijo($"rejilla_{rejillaId}", rejilla);
            rejillaId++;
        }

        pc.AddHijo("rejillas", rejillas);
        return pc;
    }
}