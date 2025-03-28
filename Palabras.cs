﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadosJuegoTarea
{
    internal class Palabras
    {
        private List<string> palabras = new List<string>()
            {
                "computador", "navegador", "dinosaurio", "astronauta",
                "bicicleta", "biblioteca", "paraguas", "herramienta", "electricidad",
                "ventilador", "telefonia", "calendario", "arquitecto", "cinematografia",
                "fotovoltaico", "telefonista", "desconocido", "programacion",
                "matematicas", "diccionario", "marionetista", "desarrollador",
                "entretenimiento", "alimentacion", "fortalecimiento", "pensamiento",
                "administradora"
            };
        public void addPalabra(string s)
        {
            palabras.Add(s);
        }
        public char[] elegirPalabraRandom()
        {
            Random rand=new Random();
            return (palabras[rand.Next(palabras.Count)]).ToCharArray();
        }
        public char[] hashearPalabra(char[] palabraElegida)
        {
            Random random = new Random();
            
            char[] resultado = (char[])palabraElegida.Clone();

            int cantidadMostrar = ((palabraElegida.Length * 30) / 100); 

            for (int i = 0; i < palabraElegida.Length; i++)
            {
                if (cantidadMostrar > 0)
                {
                    if (random.Next(2) == 1) 
                    {
                        resultado[i] = '_';
                        
                    }
                    else
                    {
                        cantidadMostrar--;
                    }
                }
                else
                {
                    resultado[i] = '_';
                }
            }
            return resultado;
        }
    }
}
