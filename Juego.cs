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
                while (true)
                {
                    string numeroVidas = Console.ReadLine();
                    if (int.TryParse(numeroVidas, out int numeroVidasInteger)){
                        jugador.getVida().setVidas(numeroVidasInteger);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error, ingresa un dato valido");
                    } 
                }
                
                while (jugador.getVida().getNumeroVidas() > 0)
                {
                    if (palabraCompleta())
                    {
                        ganaste = true;
                        break;
                    }
                    Console.WriteLine(palabraElegidaCodificada);
                    Console.WriteLine("Que letra escojes?");
                    char letraChar;
                    while (true)
                    {
                        string letra = Console.ReadLine().ToLower();
                        if(char.TryParse(letra, out letraChar) && !int.TryParse(letra,out int aux) &&letraChar>='a' &&letraChar<='z')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ingrese valor correcto");
                        }
                    }
                    
                    if (verificarLetraEnPalabra(letraChar))
                    {
                        agregarLetrasPalabraCodificada(letraChar);
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
                    Console.WriteLine("Haz sido ahorcado, no lograste adivinar la palabra '"+string.Join("",palabraElegida)+"' deseas empezar otra ronda? yes/no");
                }
                while (true)
                {
                    string reiniciar = Console.ReadLine().ToLower();
                    if (reiniciar== "no")
                    {
                        return;
                    }
                    else if (reiniciar == "yes")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Introduce dato valido");
                    }
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
