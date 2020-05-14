using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Grafica
    {

        private String nombre;
        private LinkedList<Continente> continentes;

        public Grafica(String nombre)
        {
            this.nombre = nombre;
            continentes = new LinkedList<Continente>();
        }


        public void setContinente(Continente continente)
        {
            continentes.AddLast(continente);
        }

        public String getNombre()
        {
            return nombre;
        }

        public LinkedList<Continente> getContinente()
        {
            return continentes;
        }
    }
}
