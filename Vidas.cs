using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhorcadosJuegoTarea
{
    internal class Vidas { 
        private int numeroVidas=0;
        
        public int getNumeroVidas()
        {
            return numeroVidas;
        }
        public void eliminarVida()
        {
            numeroVidas--;
        }
        public void setVidas(int numeroVidas)
        {
            this.numeroVidas = numeroVidas;
        }
    }
}
