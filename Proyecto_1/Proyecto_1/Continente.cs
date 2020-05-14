using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Continente
    {
        
        private String nombre;
        private int poblacionTotal;
        private int saturacionTotal;
        private String color;
        private LinkedList<Pais> paises;

        public Continente(String nombre)
        {
            this.nombre = nombre;
            paises = new LinkedList<Pais>();
            
        }

        public void setPais(Pais pais)
        {
            paises.AddLast(pais);
        }

        public LinkedList<Pais> getPais()
        {
            return paises;
        }

        public String getNombre()
        {
            return nombre;
        }

        public int getSaturacion()
        {
            return saturacionTotal;
        }

        public void colorContinente()
        {
            int suma = 0;
            foreach (Pais item in paises)
            {
               
                poblacionTotal += item.getPoblacion();
                suma += item.getSaturacion();
                saturacionTotal = suma / paises.Count;
                double redondear = Math.Round((double)saturacionTotal);
                color = item.colorNodo((int) redondear);
            }
        }

        public String getColor()
        {
            return color;
        }

        public int getPoblacion()
        {
            return poblacionTotal;
        }
    }
}
