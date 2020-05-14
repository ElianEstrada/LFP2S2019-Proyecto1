using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    class Pais
    {

        private String nombre;
        private int poblacion;
        private int saturacion;
        private String bandera;
        private String color;

        public Pais(String nombre, int poblacion, int saturacion, String bandera)
        {
            this.nombre = nombre;
            this.poblacion = poblacion;
            if (saturacion <= 100)
            {
                this.saturacion = saturacion;
                color = colorNodo(saturacion);
            }
            else
            {
                MessageBox.Show("La saturación debe ser un número entero entre 0 y 100");
            }
            this.bandera = bandera;
        }


        public int getPoblacion()
        {
            return poblacion;
        }

        public int getSaturacion()
        {
            return saturacion;
        }
        
        public String getNombre()
        {
            return nombre;
        }

        public String getBandera()
        {
            return bandera;
        }

        public String getColor()
        {
            return color;
        }

        public String colorNodo(int numero)
        {
            if(numero >= 0 && numero <= 15)
            {
                return "white";
            }else if(numero > 15 && numero <= 30)
            {
                return "blue";
            }else if(numero >30 && numero <= 45)
            {
                return "green";
            }else if(numero > 45 && numero <= 60)
            {
                return "yellow";
            }else if(numero > 60 && numero <= 75)
            {
                return "orange";
            }else if(numero > 75 && numero <= 100)
            {
                return "red";
            }
            return "white";
        }
    }
}
