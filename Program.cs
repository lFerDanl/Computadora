// Program.cs - Actualizado para usar la nueva estructura
using System;
using System.Threading;
using Computadora;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Computadora
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var monitor = ObjetoFactory.CrearMonitor();
            var mouse = ObjetoFactory.CrearMouse();
            var teclado = ObjetoFactory.CrearTeclado();
            var pc = ObjetoFactory.CrearPC();
            List<Objeto> escritorio = new List<Objeto> { monitor, mouse, teclado, pc };
            Serializador.GuardarEscena(escritorio, "mi_escritorio");*/

            // Configurar y ejecutar el juego
            using (Game game = new Game(1024, 768, "Computadora 3D - OpenTK"))
            {
                // Configurar propiedades del juego
                game.VSync = VSyncMode.On;
                game.WindowBorder = WindowBorder.Fixed;

                // Mostrar instrucciones en consola
                Console.WriteLine("=== COMPUTADORA 3D - CONTROLES ===");
                Console.WriteLine("WASD: Mover cámara");
                Console.WriteLine("Q/E: Rotar cámara arriba/abajo");
                Console.WriteLine("R: Resetear cámara");
                Console.WriteLine("Escape: Salir");
                Console.WriteLine("=====================================");

                // Ejecutar el juego
                game.Run(60.0); // 60 FPS
            }
        }
    }
}