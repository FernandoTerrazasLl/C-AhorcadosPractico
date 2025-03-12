using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadosJuegoTarea
{
    internal class Juego
    {
        private Jugador jugador = new Jugador();
        private Palabras palabras = new Palabras();
        private char[] palabraElegida;
        private char[] palabraElegidaCodificada;

        public Juego()
        {
            inicioJuego();
            procesoJuego();
        }
        public void inicioJuego()
        {
            Console.WriteLine("Bienvenido al juego Ahorcado");
            Console.WriteLine("Tendras que adivinar una palabra dentro de las vidas permitidas");
            Console.WriteLine("Cada vez que te equivoques al mencionar una letra del juego estaras mas cerca de morir.");
            Console.WriteLine("Preparate!!");
            Console.WriteLine("Comencemos el juego!!!\n");

        }
        public void procesoJuego()
        {
            while (true) {
                palabraElegida = palabras.elegirPalabraRandom();
                palabraElegidaCodificada = palabras.hashearPalabra(palabraElegida);
                Boolean ganaste = false;
                Console.WriteLine("Ingresa la cantidad de vidas que tendras");
                jugador.getVida().setVidas(int.Parse(Console.ReadLine().ToLower()));

                while (jugador.getVida().getNumeroVidas() > 0)
                {
                    if (palabraCompleta())
                    {
                        ganaste = true;
                        break;
                    }
                    Console.WriteLine(palabraElegidaCodificada);
                    Console.WriteLine("Que letra escojes?");
                    char letra = char.ToLower(Console.ReadLine()[0]);
                    if (verificarLetraEnPalabra(letra))
                    {
                        agregarLetrasPalabraCodificada(letra);
                        Console.WriteLine("Acertaste!");
                    }
                    else
                    {
                        jugador.getVida().eliminarVida();
                        Console.WriteLine("Letra incorrecta, te quedan " + jugador.getVida().getNumeroVidas() + " vidas");
                    }
                }
                if (ganaste)
                {
                    Console.WriteLine("Felicidades Ganaste, deseas volver a jugar? yes/no");
                }
                else
                {
                    Console.WriteLine("Perdiste todas las vidas, haz sido ahorcado, deseas empezar otra ronda? yes/no");
                }
                if (Console.ReadLine().ToLower() == "no")
                {
                    break;
                }
            }
        }
        public void agregarLetrasPalabraCodificada(char letra)
        {
            for (int i = 0; i < palabraElegida.Length; i++) {
                if (palabraElegida[i] == letra)
                {
                    palabraElegidaCodificada[i] = letra;
                }
            }
        }
        public Boolean verificarLetraEnPalabra(char letra)
        {
            Boolean existe = false;
            for(int i = 0; i < palabraElegida.Length; ++i)
            {
                if (palabraElegida[i] == letra && palabraElegidaCodificada[i]=='_')
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        public Boolean palabraCompleta()
        {
            Boolean palabraCompleta = true;
            foreach(char caracter in palabraElegidaCodificada)
            {
                if (caracter == '_')
                {
                    palabraCompleta = false;
                    break;
                }
            }
            return palabraCompleta;
        }
    
    }
}
