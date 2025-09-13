// ObjetoFactory.cs - Actualizado para nueva estructura de clases
using System;
using OpenTK;

public static class ObjetoFactory
{
    public static Objeto CrearMonitor()
    {
        Objeto monitor = new Objeto(new Vector3(0, 0, 0));

        // Parte: Soporte vertical (GRIS OSCURO)
        Parte soporteVertical = new Parte();

        // Cara frontal del soporte
        Cara caraFrontalSoporte = new Cara();
        caraFrontalSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraFrontalSoporte.AddVertice(new Vertice(-0.1f, -1.9f, 0.1f));
        caraFrontalSoporte.AddVertice(new Vertice(0.1f, -1.9f, 0.1f));
        caraFrontalSoporte.AddVertice(new Vertice(0.1f, 0.1f, 0.1f));
        caraFrontalSoporte.AddVertice(new Vertice(-0.1f, 0.1f, 0.1f));

        // Cara trasera del soporte
        Cara caraTraseraSoporte = new Cara();
        caraTraseraSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraTraseraSoporte.AddVertice(new Vertice(-0.1f, -1.9f, -0.1f));
        caraTraseraSoporte.AddVertice(new Vertice(-0.1f, 0.1f, -0.1f));
        caraTraseraSoporte.AddVertice(new Vertice(0.1f, 0.1f, -0.1f));
        caraTraseraSoporte.AddVertice(new Vertice(0.1f, -1.9f, -0.1f));

        // Cara izquierda del soporte
        Cara caraIzquierdaSoporte = new Cara();
        caraIzquierdaSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, -1.9f, -0.1f));
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, -1.9f, 0.1f));
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, 0.1f, 0.1f));
        caraIzquierdaSoporte.AddVertice(new Vertice(-0.1f, 0.1f, -0.1f));

        // Cara derecha del soporte
        Cara caraDerechaSoporte = new Cara();
        caraDerechaSoporte.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, -1.9f, -0.1f));
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, 0.1f, -0.1f));
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, 0.1f, 0.1f));
        caraDerechaSoporte.AddVertice(new Vertice(0.1f, -1.9f, 0.1f));

        soporteVertical.AddCara("caraFrontal", caraFrontalSoporte);
        soporteVertical.AddCara("caraTrasera", caraTraseraSoporte);
        soporteVertical.AddCara("caraIzquierda", caraIzquierdaSoporte);
        soporteVertical.AddCara("caraDerecha", caraDerechaSoporte);

        monitor.AddParte("soporteVertical", soporteVertical);

        // Parte: Base del monitor (GRIS OSCURO)
        Parte baseMonitor = new Parte();

        // Cara frontal de la base
        Cara caraFrontalBase = new Cara();
        caraFrontalBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraFrontalBase.AddVertice(new Vertice(-0.8f, -2.3f, 0.8f));
        caraFrontalBase.AddVertice(new Vertice(0.8f, -2.3f, 0.8f));
        caraFrontalBase.AddVertice(new Vertice(0.8f, -1.7f, 0.8f));
        caraFrontalBase.AddVertice(new Vertice(-0.8f, -1.7f, 0.8f));

        // Cara trasera de la base
        Cara caraTraseraBase = new Cara();
        caraTraseraBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraTraseraBase.AddVertice(new Vertice(-0.8f, -2.3f, -0.8f));
        caraTraseraBase.AddVertice(new Vertice(-0.8f, -1.7f, -0.8f));
        caraTraseraBase.AddVertice(new Vertice(0.8f, -1.7f, -0.8f));
        caraTraseraBase.AddVertice(new Vertice(0.8f, -2.3f, -0.8f));

        // Cara izquierda de la base
        Cara caraIzquierdaBase = new Cara();
        caraIzquierdaBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, -2.3f, -0.8f));
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, -2.3f, 0.8f));
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, -1.7f, 0.8f));
        caraIzquierdaBase.AddVertice(new Vertice(-0.8f, -1.7f, -0.8f));

        // Cara derecha de la base
        Cara caraDerechaBase = new Cara();
        caraDerechaBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraDerechaBase.AddVertice(new Vertice(0.8f, -2.3f, -0.8f));
        caraDerechaBase.AddVertice(new Vertice(0.8f, -1.7f, -0.8f));
        caraDerechaBase.AddVertice(new Vertice(0.8f, -1.7f, 0.8f));
        caraDerechaBase.AddVertice(new Vertice(0.8f, -2.3f, 0.8f));

        // Cara superior de la base
        Cara caraSuperiorBase = new Cara();
        caraSuperiorBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraSuperiorBase.AddVertice(new Vertice(-0.8f, -1.7f, -0.8f));
        caraSuperiorBase.AddVertice(new Vertice(-0.8f, -1.7f, 0.8f));
        caraSuperiorBase.AddVertice(new Vertice(0.8f, -1.7f, 0.8f));
        caraSuperiorBase.AddVertice(new Vertice(0.8f, -1.7f, -0.8f));

        // Cara inferior de la base
        Cara caraInferiorBase = new Cara();
        caraInferiorBase.Color = new float[] { 0.3f, 0.3f, 0.3f };
        caraInferiorBase.AddVertice(new Vertice(-0.8f, -2.3f, -0.8f));
        caraInferiorBase.AddVertice(new Vertice(0.8f, -2.3f, -0.8f));
        caraInferiorBase.AddVertice(new Vertice(0.8f, -2.3f, 0.8f));
        caraInferiorBase.AddVertice(new Vertice(-0.8f, -2.3f, 0.8f));

        baseMonitor.AddCara("caraFrontal", caraFrontalBase);
        baseMonitor.AddCara("caraTrasera", caraTraseraBase);
        baseMonitor.AddCara("caraIzquierda", caraIzquierdaBase);
        baseMonitor.AddCara("caraDerecha", caraDerechaBase);
        baseMonitor.AddCara("caraSuperior", caraSuperiorBase);
        baseMonitor.AddCara("caraInferior", caraInferiorBase);

        monitor.AddParte("baseMonitor", baseMonitor);

        // Parte: Monitor caja (NEGRO)
        Parte monitorCaja = new Parte();

        // Cara frontal de la pantalla
        Cara caraFrontalMonitor = new Cara();
        caraFrontalMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraFrontalMonitor.AddVertice(new Vertice(-2.0f, -0.5f, 0.2f));
        caraFrontalMonitor.AddVertice(new Vertice(2.0f, -0.5f, 0.2f));
        caraFrontalMonitor.AddVertice(new Vertice(2.0f, 2.5f, 0.2f));
        caraFrontalMonitor.AddVertice(new Vertice(-2.0f, 2.5f, 0.2f));

        // Cara trasera de la pantalla
        Cara caraTraseraMonitor = new Cara();
        caraTraseraMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraTraseraMonitor.AddVertice(new Vertice(-2.0f, -0.5f, -0.2f));
        caraTraseraMonitor.AddVertice(new Vertice(-2.0f, 2.5f, -0.2f));
        caraTraseraMonitor.AddVertice(new Vertice(2.0f, 2.5f, -0.2f));
        caraTraseraMonitor.AddVertice(new Vertice(2.0f, -0.5f, -0.2f));

        // Cara izquierda de la pantalla
        Cara caraIzquierdaMonitor = new Cara();
        caraIzquierdaMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, -0.5f, -0.2f));
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, -0.5f, 0.2f));
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, 2.5f, 0.2f));
        caraIzquierdaMonitor.AddVertice(new Vertice(-2.0f, 2.5f, -0.2f));

        // Cara derecha de la pantalla
        Cara caraDerechaMonitor = new Cara();
        caraDerechaMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, -0.5f, -0.2f));
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, 2.5f, -0.2f));
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, 2.5f, 0.2f));
        caraDerechaMonitor.AddVertice(new Vertice(2.0f, -0.5f, 0.2f));

        // Cara superior de la pantalla
        Cara caraSuperiorMonitor = new Cara();
        caraSuperiorMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraSuperiorMonitor.AddVertice(new Vertice(-2.0f, 2.5f, -0.2f));
        caraSuperiorMonitor.AddVertice(new Vertice(-2.0f, 2.5f, 0.2f));
        caraSuperiorMonitor.AddVertice(new Vertice(2.0f, 2.5f, 0.2f));
        caraSuperiorMonitor.AddVertice(new Vertice(2.0f, 2.5f, -0.2f));

        // Cara inferior de la pantalla
        Cara caraInferiorMonitor = new Cara();
        caraInferiorMonitor.Color = new float[] { 0.1f, 0.1f, 0.1f };
        caraInferiorMonitor.AddVertice(new Vertice(-2.0f, -0.5f, -0.2f));
        caraInferiorMonitor.AddVertice(new Vertice(2.0f, -0.5f, -0.2f));
        caraInferiorMonitor.AddVertice(new Vertice(2.0f, -0.5f, 0.2f));
        caraInferiorMonitor.AddVertice(new Vertice(-2.0f, -0.5f, 0.2f));

        monitorCaja.AddCara("caraFrontal", caraFrontalMonitor);
        monitorCaja.AddCara("caraTrasera", caraTraseraMonitor);
        monitorCaja.AddCara("caraIzquierda", caraIzquierdaMonitor);
        monitorCaja.AddCara("caraDerecha", caraDerechaMonitor);
        monitorCaja.AddCara("caraSuperior", caraSuperiorMonitor);
        monitorCaja.AddCara("caraInferior", caraInferiorMonitor);

        monitor.AddParte("monitorCaja", monitorCaja);

        // Parte: Pantalla azul (frente)
        Parte pantallaAzul = new Parte();

        // Solo la cara frontal azul
        Cara caraPantallaAzul = new Cara();
        caraPantallaAzul.Color = new float[] { 0.0f, 0.5f, 1.0f };
        caraPantallaAzul.AddVertice(new Vertice(-1.8f, -0.3f, 0.25f));
        caraPantallaAzul.AddVertice(new Vertice(1.8f, -0.3f, 0.25f));
        caraPantallaAzul.AddVertice(new Vertice(1.8f, 2.3f, 0.25f));
        caraPantallaAzul.AddVertice(new Vertice(-1.8f, 2.3f, 0.25f));

        pantallaAzul.AddCara("pantalla", caraPantallaAzul);
        monitor.AddParte("pantallaAzul", pantallaAzul);

        return monitor;
    }

    public static Objeto CrearMouse()
    {
        Objeto mouse = new Objeto(new Vector3(3, -2.5f, 2));

        // Parte: Cuerpo del mouse (GRIS)
        Parte cuerpoMouse = new Parte();

        // Cara frontal
        Cara caraFrontal = new Cara();
        caraFrontal.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraFrontal.AddVertice(new Vertice(-0.5f, 0.0f, 0.8f));
        caraFrontal.AddVertice(new Vertice(0.5f, 0.0f, 0.8f));
        caraFrontal.AddVertice(new Vertice(0.5f, 0.3f, 0.8f));
        caraFrontal.AddVertice(new Vertice(-0.5f, 0.3f, 0.8f));

        // Cara trasera
        Cara caraTrasera = new Cara();
        caraTrasera.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraTrasera.AddVertice(new Vertice(-0.5f, 0.0f, -0.8f));
        caraTrasera.AddVertice(new Vertice(-0.5f, 0.3f, -0.8f));
        caraTrasera.AddVertice(new Vertice(0.5f, 0.3f, -0.8f));
        caraTrasera.AddVertice(new Vertice(0.5f, 0.0f, -0.8f));

        // Cara izquierda
        Cara caraIzquierda = new Cara();
        caraIzquierda.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.0f, -0.8f));
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.0f, 0.8f));
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.3f, 0.8f));
        caraIzquierda.AddVertice(new Vertice(-0.5f, 0.3f, -0.8f));

        // Cara derecha
        Cara caraDerecha = new Cara();
        caraDerecha.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraDerecha.AddVertice(new Vertice(0.5f, 0.0f, -0.8f));
        caraDerecha.AddVertice(new Vertice(0.5f, 0.3f, -0.8f));
        caraDerecha.AddVertice(new Vertice(0.5f, 0.3f, 0.8f));
        caraDerecha.AddVertice(new Vertice(0.5f, 0.0f, 0.8f));

        // Cara superior
        Cara caraSuperior = new Cara();
        caraSuperior.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraSuperior.AddVertice(new Vertice(-0.5f, 0.3f, -0.8f));
        caraSuperior.AddVertice(new Vertice(-0.5f, 0.3f, 0.8f));
        caraSuperior.AddVertice(new Vertice(0.5f, 0.3f, 0.8f));
        caraSuperior.AddVertice(new Vertice(0.5f, 0.3f, -0.8f));

        // Cara inferior
        Cara caraInferior = new Cara();
        caraInferior.Color = new float[] { 0.5f, 0.5f, 0.5f };
        caraInferior.AddVertice(new Vertice(-0.5f, 0.0f, -0.8f));
        caraInferior.AddVertice(new Vertice(0.5f, 0.0f, -0.8f));
        caraInferior.AddVertice(new Vertice(0.5f, 0.0f, 0.8f));
        caraInferior.AddVertice(new Vertice(-0.5f, 0.0f, 0.8f));

        cuerpoMouse.AddCara("caraFrontal", caraFrontal);
        cuerpoMouse.AddCara("caraTrasera", caraTrasera);
        cuerpoMouse.AddCara("caraIzquierda", caraIzquierda);
        cuerpoMouse.AddCara("caraDerecha", caraDerecha);
        cuerpoMouse.AddCara("caraSuperior", caraSuperior);
        cuerpoMouse.AddCara("caraInferior", caraInferior);

        mouse.AddParte("cuerpoMouse", cuerpoMouse);

        // Parte: Botón izquierdo
        Parte botonIzquierdo = new Parte();

        Cara botonIzq = new Cara();
        botonIzq.Color = new float[] { 0.3f, 0.3f, 0.3f };
        botonIzq.AddVertice(new Vertice(-0.35f, 0.35f, -0.3f));
        botonIzq.AddVertice(new Vertice(-0.05f, 0.35f, -0.3f));
        botonIzq.AddVertice(new Vertice(-0.05f, 0.35f, 0.3f));
        botonIzq.AddVertice(new Vertice(-0.35f, 0.35f, 0.3f));

        botonIzquierdo.AddCara("boton", botonIzq);
        mouse.AddParte("botonIzquierdo", botonIzquierdo);

        // Parte: Botón derecho
        Parte botonDerecho = new Parte();

        Cara botonDer = new Cara();
        botonDer.Color = new float[] { 0.3f, 0.3f, 0.3f };
        botonDer.AddVertice(new Vertice(0.05f, 0.35f, -0.3f));
        botonDer.AddVertice(new Vertice(0.35f, 0.35f, -0.3f));
        botonDer.AddVertice(new Vertice(0.35f, 0.35f, 0.3f));
        botonDer.AddVertice(new Vertice(0.05f, 0.35f, 0.3f));

        botonDerecho.AddCara("boton", botonDer);
        mouse.AddParte("botonDerecho", botonDerecho);

        return mouse;
    }

    public static Objeto CrearTeclado()
    {
        Objeto teclado = new Objeto(new Vector3(0, -2.3f, 3));

        // Parte: Base del teclado (NEGRO)
        Parte baseTeclado = new Parte();

        // Cara frontal de la base
        Cara caraFrontalTeclado = new Cara();
        caraFrontalTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraFrontalTeclado.AddVertice(new Vertice(-2.5f, 0.0f, 1.0f));
        caraFrontalTeclado.AddVertice(new Vertice(2.5f, 0.0f, 1.0f));
        caraFrontalTeclado.AddVertice(new Vertice(2.5f, 0.2f, 1.0f));
        caraFrontalTeclado.AddVertice(new Vertice(-2.5f, 0.2f, 1.0f));

        // Cara trasera de la base
        Cara caraTraseraTeclado = new Cara();
        caraTraseraTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraTraseraTeclado.AddVertice(new Vertice(-2.5f, 0.0f, -1.0f));
        caraTraseraTeclado.AddVertice(new Vertice(-2.5f, 0.2f, -1.0f));
        caraTraseraTeclado.AddVertice(new Vertice(2.5f, 0.2f, -1.0f));
        caraTraseraTeclado.AddVertice(new Vertice(2.5f, 0.0f, -1.0f));

        // Cara izquierda de la base
        Cara caraIzquierdaTeclado = new Cara();
        caraIzquierdaTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.0f, -1.0f));
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.0f, 1.0f));
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.2f, 1.0f));
        caraIzquierdaTeclado.AddVertice(new Vertice(-2.5f, 0.2f, -1.0f));

        // Cara derecha de la base
        Cara caraDerechaTeclado = new Cara();
        caraDerechaTeclado.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.0f, -1.0f));
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.2f, -1.0f));
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.2f, 1.0f));
        caraDerechaTeclado.AddVertice(new Vertice(2.5f, 0.0f, 1.0f));

        // Cara superior de la base
        Cara caraSuperiorBase = new Cara();
        caraSuperiorBase.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraSuperiorBase.AddVertice(new Vertice(-2.5f, 0.2f, -1.0f));
        caraSuperiorBase.AddVertice(new Vertice(-2.5f, 0.2f, 1.0f));
        caraSuperiorBase.AddVertice(new Vertice(2.5f, 0.2f, 1.0f));
        caraSuperiorBase.AddVertice(new Vertice(2.5f, 0.2f, -1.0f));

        // Cara inferior de la base
        Cara caraInferiorBase = new Cara();
        caraInferiorBase.Color = new float[] { 0.2f, 0.2f, 0.2f };
        caraInferiorBase.AddVertice(new Vertice(-2.5f, 0.0f, -1.0f));
        caraInferiorBase.AddVertice(new Vertice(2.5f, 0.0f, -1.0f));
        caraInferiorBase.AddVertice(new Vertice(2.5f, 0.0f, 1.0f));
        caraInferiorBase.AddVertice(new Vertice(-2.5f, 0.0f, 1.0f));

        baseTeclado.AddCara("caraFrontal", caraFrontalTeclado);
        baseTeclado.AddCara("caraTrasera", caraTraseraTeclado);
        baseTeclado.AddCara("caraIzquierda", caraIzquierdaTeclado);
        baseTeclado.AddCara("caraDerecha", caraDerechaTeclado);
        baseTeclado.AddCara("caraSuperior", caraSuperiorBase);
        baseTeclado.AddCara("caraInferior", caraInferiorBase);

        teclado.AddParte("baseTeclado", baseTeclado);

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
                tecla.AddVertice(new Vertice(x - 0.15f, 0.25f, z - 0.1f));
                tecla.AddVertice(new Vertice(x + 0.15f, 0.25f, z - 0.1f));
                tecla.AddVertice(new Vertice(x + 0.15f, 0.25f, z + 0.1f));
                tecla.AddVertice(new Vertice(x - 0.15f, 0.25f, z + 0.1f));

                teclas.AddCara($"tecla_{teclaId}", tecla);
                teclaId++;
            }
        }

        teclado.AddParte("teclas", teclas);
        return teclado;
    }

    public static Objeto CrearPC()
    {
        Objeto pc = new Objeto(new Vector3(-4, -1, 0));

        // Parte: Carcasa principal (GRIS OSCURO)
        Parte carcasa = new Parte();

        // Cara frontal
        Cara caraFrontal = new Cara();
        caraFrontal.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraFrontal.AddVertice(new Vertice(-0.8f, -2.0f, 1.0f));
        caraFrontal.AddVertice(new Vertice(0.8f, -2.0f, 1.0f));
        caraFrontal.AddVertice(new Vertice(0.8f, 2.0f, 1.0f));
        caraFrontal.AddVertice(new Vertice(-0.8f, 2.0f, 1.0f));

        // Cara trasera
        Cara caraTrasera = new Cara();
        caraTrasera.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraTrasera.AddVertice(new Vertice(-0.8f, -2.0f, -1.0f));
        caraTrasera.AddVertice(new Vertice(-0.8f, 2.0f, -1.0f));
        caraTrasera.AddVertice(new Vertice(0.8f, 2.0f, -1.0f));
        caraTrasera.AddVertice(new Vertice(0.8f, -2.0f, -1.0f));

        // Cara izquierda
        Cara caraIzquierda = new Cara();
        caraIzquierda.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraIzquierda.AddVertice(new Vertice(-0.8f, -2.0f, -1.0f));
        caraIzquierda.AddVertice(new Vertice(-0.8f, -2.0f, 1.0f));
        caraIzquierda.AddVertice(new Vertice(-0.8f, 2.0f, 1.0f));
        caraIzquierda.AddVertice(new Vertice(-0.8f, 2.0f, -1.0f));

        // Cara derecha
        Cara caraDerecha = new Cara();
        caraDerecha.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraDerecha.AddVertice(new Vertice(0.8f, -2.0f, -1.0f));
        caraDerecha.AddVertice(new Vertice(0.8f, 2.0f, -1.0f));
        caraDerecha.AddVertice(new Vertice(0.8f, 2.0f, 1.0f));
        caraDerecha.AddVertice(new Vertice(0.8f, -2.0f, 1.0f));

        // Cara superior
        Cara caraSuperior = new Cara();
        caraSuperior.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraSuperior.AddVertice(new Vertice(-0.8f, 2.0f, -1.0f));
        caraSuperior.AddVertice(new Vertice(-0.8f, 2.0f, 1.0f));
        caraSuperior.AddVertice(new Vertice(0.8f, 2.0f, 1.0f));
        caraSuperior.AddVertice(new Vertice(0.8f, 2.0f, -1.0f));

        // Cara inferior
        Cara caraInferior = new Cara();
        caraInferior.Color = new float[] { 0.25f, 0.25f, 0.25f };
        caraInferior.AddVertice(new Vertice(-0.8f, -2.0f, -1.0f));
        caraInferior.AddVertice(new Vertice(0.8f, -2.0f, -1.0f));
        caraInferior.AddVertice(new Vertice(0.8f, -2.0f, 1.0f));
        caraInferior.AddVertice(new Vertice(-0.8f, -2.0f, 1.0f));

        carcasa.AddCara("caraFrontal", caraFrontal);
        carcasa.AddCara("caraTrasera", caraTrasera);
        carcasa.AddCara("caraIzquierda", caraIzquierda);
        carcasa.AddCara("caraDerecha", caraDerecha);
        carcasa.AddCara("caraSuperior", caraSuperior);
        carcasa.AddCara("caraInferior", caraInferior);

        pc.AddParte("carcasa", carcasa);

        // Parte: Botón de encendido (VERDE)
        Parte botonEncendido = new Parte();

        Cara boton = new Cara();
        boton.Color = new float[] { 0.0f, 1.0f, 0.0f };
        boton.AddVertice(new Vertice(0.5f, 1.4f, 1.05f));
        boton.AddVertice(new Vertice(0.7f, 1.4f, 1.05f));
        boton.AddVertice(new Vertice(0.7f, 1.6f, 1.05f));
        boton.AddVertice(new Vertice(0.5f, 1.6f, 1.05f));

        botonEncendido.AddCara("boton", boton);
        pc.AddParte("botonEncendido", botonEncendido);

        // Parte: Rejillas de ventilación (AMARILLO)
        Parte rejillas = new Parte();

        // Crear rejillas horizontales
        int rejillaId = 0;
        for (int i = -3; i <= 3; i++)
        {
            float y = i * 0.3f;

            Cara rejilla = new Cara();
            rejilla.Color = new float[] { 1.0f, 1.0f, 0.0f };
            rejilla.AddVertice(new Vertice(-0.6f, y - 0.05f, 1.05f));
            rejilla.AddVertice(new Vertice(0.6f, y - 0.05f, 1.05f));
            rejilla.AddVertice(new Vertice(0.6f, y + 0.05f, 1.05f));
            rejilla.AddVertice(new Vertice(-0.6f, y + 0.05f, 1.05f));

            rejillas.AddCara($"rejilla_{rejillaId}", rejilla);
            rejillaId++;
        }

        pc.AddParte("rejillas", rejillas);
        return pc;
    }
}