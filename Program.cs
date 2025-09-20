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

            // Crear escenario con objetos
            //var escenario = ObjetoFactory.CrearEscenarioEscritorio();
            //Serializador.GuardarEscenario(escenario, "mi_escritorio");

            // Configurar y ejecutar el juego
            using (Game game = new Game(1024, 768, "Computadora 3D - OpenTK"))
            {
                // Configurar propiedades del juego
                game.VSync = VSyncMode.On;
                game.WindowBorder = WindowBorder.Fixed;

                // Mostrar instrucciones en consola
                MostrarInstrucciones();

                // Ejecutar el juego
                game.Run(60.0); // 60 FPS
            }
        }

        private static void MostrarInstrucciones()
        {
            Console.WriteLine("=== COMPUTADORA 3D - CONTROLES ===");
            Console.WriteLine("WASD: Mover cámara");
            Console.WriteLine("Q/E: Rotar cámara arriba/abajo");
            Console.WriteLine("R: Resetear cámara");
            Console.WriteLine("Escape: Salir");
            Console.WriteLine("=====================================");
            Console.WriteLine("=== CONTROLES DE TRANSFORMACIÓN ===");
            Console.WriteLine("Traslación:");
            Console.WriteLine("  1/2: Trasladar en X (-/+)");
            Console.WriteLine("  3/4: Trasladar en Y (-/+)");
            Console.WriteLine("  5/6: Trasladar en Z (-/+)");
            Console.WriteLine("Rotación:");
            Console.WriteLine("  7/8: Rotar en X (-/+)");
            Console.WriteLine("  9/0: Rotar en Y (-/+)");
            Console.WriteLine("  U/I: Rotar en Z (-/+)");
            Console.WriteLine("Escalado:");
            Console.WriteLine("  O/P: Escalar uniformemente (-/+)");
            Console.WriteLine("  J/K: Escalar en X (-/+)");
            Console.WriteLine("  N/M: Escalar en Y (-/+)");
            Console.WriteLine("  B/V: Escalar en Z (-/+)");
            Console.WriteLine("  T: Reset transformaciones");
            Console.WriteLine("===================================");
        }
    }
}