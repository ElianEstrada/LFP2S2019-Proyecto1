using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Analizador_Lexico
    {

        LinkedList<String> palabras;

        public void palabrasReservadas()
        {
            palabras = new LinkedList<String>();


            palabras.AddLast("Grafica");
            palabras.AddLast("Continente");
            palabras.AddLast("Pais");
            palabras.AddLast("Nombre");
            palabras.AddLast("Poblacion");
            palabras.AddLast("Bandera");
            palabras.AddLast("Saturacion");
        }

        private LinkedList<Token> salida;
        private int estado;
        private String lexAux;

        private static int fila = 1;
        private static int columna = 0;

        private LinkedList<Grafica> grafica = new LinkedList<Grafica>();
        private String graficaAux = "";
        private String contienenteAux = "";
        private String paisAux = "";
        private String nombreGrafica = "";
        private String nombreContinente = "";
        private String nombrePais = "";
        private String bandera = "";
        private int saturacion = 0;
        private int poblacion = 0;
        private String varAux = "";


        public void setGrafica()
        {
            grafica.Clear();
        }
        public LinkedList<Token> getLista()
        {
            return salida;
        }

        public void setFila(int inicio)
        {
            fila = inicio;
        }

        public void setColumna(int inicio)
        {
            columna = inicio;
        }

        public LinkedList<Token> scanner(String entrada)
        {

            entrada = entrada + "#";
            salida = new LinkedList<Token>();
            estado = 0;
            lexAux = "";
            Char c;

            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (c.CompareTo('{') == 0)
                        {
                            lexAux += c;
                            columna++;
                            agregarToken(Token.Tipo.LLAVES_IZQ, lexAux, fila, columna);
                            lexAux = "";
                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            lexAux += c;
                            columna++;
                            agregarToken(Token.Tipo.LLAVES_DER, lexAux, fila, columna);
                            lexAux = "";
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            lexAux += c;
                            columna++;
                            agregarToken(Token.Tipo.SIGNO_DOS_PUNTOS, lexAux, fila, columna);
                            lexAux = "";
                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            lexAux += c;
                            columna++;
                            agregarToken(Token.Tipo.SIGNO_PUNTO_Y_COMA, lexAux, fila, columna);
                            lexAux = "";
                        }
                        else if (c.CompareTo('%') == 0)
                        {
                            lexAux += c;
                            columna++;
                            agregarToken(Token.Tipo.SIGNO_PORCENTAJE, lexAux, fila, columna);
                            lexAux = "";
                        }
                        else if (c.CompareTo('\n') == 0)
                        {
                            fila++;
                            columna = 0;
                        }
                        else if (c.CompareTo(' ') == 0)
                        {
                            estado = 0;
                            columna++;
                        }
                        else if (c.CompareTo('"') == 0)
                        {
                            estado = 5;
                            columna++;
                        }
                        else if (Char.IsLetter(c))
                        {
                            lexAux += c;
                            estado = 1;
                            columna++;
                        }
                        else if (Char.IsDigit(c))
                        {
                            lexAux += c;
                            estado = 2;
                            columna++;
                        }
                        else
                        {
                            if (c.Equals('#') && i == entrada.Length - 1)
                            {
                                System.Windows.Forms.MessageBox.Show("Analisis Finalizado");
                            }else
                            {
                                lexAux += c;
                                columna++;
                                agregarToken((Token.Tipo)8, lexAux, fila, columna);
                                lexAux = "";

                            }
                        }
                        break;
                    case 1:
                        if (Char.IsLetter(c) || Char.IsDigit(c))
                        {
                            lexAux += c;
                            columna++;
                        }
                        else
                        {
                            estado = 3;
                            i -= 1;
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexAux += c;
                            columna++;
                        }
                        else
                        {
                            estado = 4;
                            i -= 1;
                        }
                        break;
                    case 3:
                        if (existe(lexAux))
                        {
                            agregarToken(Token.Tipo.PALABRA_RESERVADA, lexAux, fila, columna);
                            estado = 0;
                            i -= 1;
                            lexAux = "";
                        }
                        else
                        {
                            agregarToken((Token.Tipo)8, lexAux, fila, columna);
                            estado = 0;
                            i -= 1;
                            lexAux = "";
                        }
                        break;
                    case 4:
                        agregarToken(Token.Tipo.NUMERO, lexAux, fila, columna);
                        estado = 0;
                        i -= 1;
                        lexAux = "";
                        break;
                    case 5:
                        if (c.CompareTo('"') == 0)
                        {
                            estado = 6;
                            columna++;
                            i -= 1;
                        }
                        else if (c.CompareTo('\n') == 0)
                        {
                            fila++;
                            columna = 0;
                            lexAux += c;
                        }
                        else
                        {
                            lexAux += c;
                            columna++;
                        }
                        break;
                    case 6:
                        agregarToken(Token.Tipo.CADENA_DE_TEXTO, lexAux, fila, columna);
                        estado = 0;
                        lexAux = "";
                        break;
                }
            }


            return salida;
        }


        public Boolean existe(String entrada)
        {
            foreach (String item in palabras)
            {
                if (entrada.Equals(item))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }

            return false;
        }

        public void agregarToken(Token.Tipo tipo, String lexema, int fila, int columna)
        {
            salida.AddLast(new Token(tipo, lexema, fila, columna));
        }
        /*
                public String imprimir(LinkedList<Token> lista)
                {
                    String cadenaSalida = "";

                    foreach (Token item in lista)
                    {
                        if (item.getTipoToken().Equals("DESCONOCIDO"))
                        {
                            continue;
                        }
                        else
                        {
                            cadenaSalida += "Lexema: " + item.getLexema() + " Token: " + item.getTipoToken() + " Fila: " + item.getFila() + " Columna: " + item.getColumna() + "\n";
                        }
                    }

                    return cadenaSalida;
                }

                public String imprimirErrores(LinkedList<Token> lista)
                {
                    String cadenaSalida = "";

                    foreach (Token item in lista)
                    {
                        if (item.getTipoToken().Equals("DESCONOCIDO"))
                        {
                            cadenaSalida += "Lexema: " + item.getLexema() + " Token: " + item.getTipoToken() + " Fila: " + item.getFila() + " Columna: " + item.getColumna() + "\n";
                        }
                        else
                        {
                            continue;
                        }
                    }

                    return cadenaSalida;
                }
                */

        public void imprimir(LinkedList<Token> lista)
        {

            int contador = 0;
            String contenido = "<html>\n <head> <title> Lista de Tokens </title> </head>\n <body bgcolor = \"black\"; text = \"white\";>\n <p> <h1> <center> Tabla de Tokens </center> </h1> </p> \n<table border = \"1\"> \n"
                + "<tr>\n <th> # </th>\n <th> Fila </th>\n <th> Columna </th>\n <th> Lexema</th> \n <th> Tipo de Token </th>\n</tr>";

            foreach (Token item in lista)
            {
                if (item.getTipoToken().Equals("DESCONOCIDO"))
                {
                    continue;
                }
                else
                {
                    contador++;
                    String concatener = "<tr>\n <td>" + contador + "</td>\n <td>" + item.getFila() + "</td>\n <td>" + item.getColumna() + "</td>\n <td>" + item.getLexema() + "</td>\n <td>" + item.getTipoToken() + "</td>\n </tr>";
                    contenido += concatener;
                }
            }

            File.WriteAllText("Archivos\\Tokens.html", contenido);

        }

        public void imprimirErrores(LinkedList<Token> lista)
        {
            int contador = 0;
            String contenido = "<html>\n <head> <title> Lista de Errores </title> </head>\n <body bgcolor = \"black\"; text = \"white\";>\n <p> <h1> <center> Tabla de Errores </center> </h1> </p> \n<table border = \"1\"> \n"
                + "<tr>\n <th> # </th>\n <th> Fila </th>\n <th> Columna </th>\n <th> Caracter </th> \n <th> Descripción </th>\n</tr>";

            foreach (Token item in lista)
            {
                if (item.getTipoToken().Equals("DESCONOCIDO"))
                {
                    contador++;
                    String concatener = "<tr>\n <td>" + contador + "</td>\n <td>" + item.getFila() + "</td>\n <td>" + item.getColumna() + "</td>\n <td>" + item.getLexema() + "</td>\n <td>" + item.getTipoToken() + "</td>\n </tr>";
                    contenido += concatener;
                }
                else
                {
                    continue;
                }
            }

            File.WriteAllText("Archivos\\Errores.html", contenido);
        }
        

        public void llenarJerarquia(LinkedList<Token> lista)
        {
            try
            {
                int contador = -1;
                foreach (Token item in lista)
                {
                    if (item.getLexema().Equals("Grafica"))
                    {
                        graficaAux = item.getLexema();
                    }
                    else if (graficaAux.Equals("Grafica") && item.getTipoToken().Equals("CADENA_DE_TEXTO"))
                    {
                        grafica.AddLast(new Grafica(item.getLexema()));
                        nombreGrafica = item.getLexema();
                        graficaAux = "";
                    }

                    foreach (Grafica item2 in grafica)
                    {
                        if (item2.getNombre().Equals(nombreGrafica))
                        {
                            if (item.getLexema().Equals("Continente"))
                            {
                                contienenteAux = item.getLexema();
                            }
                            else if (contienenteAux.Equals("Continente") && item.getTipoToken().Equals("CADENA_DE_TEXTO"))
                            {
                                item2.setContinente(new Continente(item.getLexema()));
                                nombreContinente = item.getLexema();
                                contienenteAux = "";
                            }

                            foreach (Continente item3 in item2.getContinente())
                            {
                                if (item3.getNombre().Equals(nombreContinente))
                                {
                                    if (item.getLexema().Equals("Pais"))
                                    {
                                        paisAux = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && item.getLexema().Equals("Nombre"))
                                    {
                                        varAux = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && item.getLexema().Equals("Bandera"))
                                    {
                                        varAux = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && varAux.Equals("Nombre") && item.getTipoToken().Equals("CADENA_DE_TEXTO"))
                                    {
                                        nombrePais = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && varAux.Equals("Bandera") && item.getTipoToken().Equals("CADENA_DE_TEXTO"))
                                    {
                                        bandera = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && item.getLexema().Equals("Poblacion"))
                                    {
                                        varAux = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && item.getLexema().Equals("Saturacion"))
                                    {
                                        varAux = item.getLexema();
                                    }
                                    else if (paisAux.Equals("Pais") && varAux.Equals("Poblacion") && item.getTipoToken().Equals("NÚMERO"))
                                    {
                                        poblacion = Convert.ToInt32(item.getLexema());
                                    }
                                    else if (paisAux.Equals("Pais") && varAux.Equals("Saturacion") && item.getTipoToken().Equals("NÚMERO"))
                                    {
                                        saturacion = Convert.ToInt32(item.getLexema());
                                    }
                                    else if (paisAux.Equals("Pais") && nombrePais != "" && bandera != "")
                                    {
                                        item3.setPais(new Pais(nombrePais, poblacion, saturacion, bandera));
                                        contador++;
                                        paisAux = "";
                                        nombrePais = "";
                                        poblacion = 0;
                                        saturacion = 0;
                                        bandera = "";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Ah ocurrido un error");
            }

        }

        /*
        public void selecionPais()
        {
            for(int i = 0; i < grafica.Count; i++)
            {
                if(grafica.ElementAt(i) != null)
                {
                    for(int j = 0; j < grafica.ElementAt(i).getContinente().Count; j++)
                    {
                        if((j+1) < grafica.ElementAt(i).getContinente().Count)
                        {
                            Console.WriteLine(mayorQUe(grafica.ElementAt(i).getContinente().ElementAt(j).getSaturacion(), grafica.ElementAt(i).getContinente().ElementAt(j + 1).getSaturacion()));
                        }

                        for(int k = 0; k < grafica.ElementAt(i).getContinente().ElementAt(j).getPais().Count; k++)
                        {
                            if((k+1) < grafica.ElementAt(i).getContinente().ElementAt(j).getPais().Count)
                            {
                                Console.WriteLine(mayorQUe(grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(0).getSaturacion(), mayorQUe(grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getSaturacion(), grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k + 1).getSaturacion())));
                            }
                        }
                    }
                }
            }
        }

        public int mayorQUe (int num1, int num2)
        {
            if(num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }*/


        LinkedList<Pais> paisTempoarl = new LinkedList<Pais>();
        Pais paisMenor = null;
        Continente continenteMenor = null;
        IEnumerable<Pais> ordenarPais;
        IEnumerable<Pais> paisMinimo;
        IEnumerable<Continente> orContinente;

        public Pais seleccionPais()
        {
            try
            {
                paisTempoarl.Clear();
                ordenarPais = null;
                orContinente = null;
                paisMenor = null;
                paisMinimo = null;

                for (int i = 0; i < grafica.Count; i++)
                {
                    for (int j = 0; j < grafica.ElementAt(i).getContinente().Count; j++)
                    {
                        ordenarPais = grafica.ElementAt(i).getContinente().ElementAt(j).getPais().OrderBy(Pais => Pais.getSaturacion());

                        paisTempoarl.AddLast(ordenarPais.First());
                    }
                }

                paisMinimo = paisTempoarl.OrderBy(Pais => Pais.getSaturacion());

                paisMenor = paisMinimo.First();

                if (multiplePais())
                {
                    return paisMenor;
                }
                else
                {
                    orContinente = grafica.ElementAt(0).getContinente().OrderBy(Continente => Continente.getSaturacion());
                    continenteMenor = orContinente.First();

                    if (multipleContiente())
                    {
                        for (int i = 0; i < grafica.ElementAt(0).getContinente().Count; i++)
                        {
                            if (continenteMenor.getNombre().Equals(grafica.ElementAt(0).getContinente().ElementAt(i).getNombre()))
                            {
                                IEnumerable<Pais> paisAbsoluto = grafica.ElementAt(0).getContinente().ElementAt(i).getPais().OrderBy(Pais => Pais.getSaturacion());
                                return paisAbsoluto.First();
                            }
                        }
                    }
                    else if(contadorContinente < grafica.ElementAt(0).getContinente().Count)
                    {
                        for (int i = 0; i < grafica.ElementAt(0).getContinente().Count; i++)
                        {
                            if (continenteMenor.getNombre().Equals(grafica.ElementAt(0).getContinente().ElementAt(i).getNombre()))
                            {
                                IEnumerable<Pais> paisAbsoluto = grafica.ElementAt(0).getContinente().ElementAt(i).getPais().OrderBy(Pais => Pais.getSaturacion());
                                return paisAbsoluto.First();
                            }
                        }
                    }
                    else
                    {
                        return paisMenor;
                    }
                }

                
            }
            catch (Exception)
            {
                
            }
            return null;
        }

        static int contadorPais = 0;
        static int contadorContinente = 0;

        public bool multiplePais()
        {
            contadorPais = 0;
            foreach(Pais item in paisMinimo)
            {
                if (item.getSaturacion() == paisMenor.getSaturacion())
                {
                    contadorPais++;
                }
            }

            if(contadorPais > 1)
            {
                return false;
            }else
            {
                return true;
            }
        }

        public bool multipleContiente()
        {
            contadorContinente = 0;
            foreach (Continente item in orContinente)
            {
                if (item.getSaturacion() == continenteMenor.getSaturacion())
                {
                    contadorContinente++;
                }
            }

            return (contadorContinente > 1 ? false : true);
        }

        public void imprimirGrafica()
        {
            int continente = 0;
            int pais = 0;
            String contenido2 = "";
            String contenido = "digraph G{\nrankdir=TB;\nnode[shape=Mdiamond];\n";
            for(int i = 0; i < grafica.Count; i++)
            {
                contenido += "inicio [label = " + "\"" +grafica.ElementAt(i).getNombre() + "\"" + "];\n node[shape=record];\n";
                Console.WriteLine("Grafica: " + grafica.ElementAt(i).getNombre());
                for (int j = 0; j < grafica.ElementAt(i).getContinente().Count; j++)
                {
                    grafica.ElementAt(i).getContinente().ElementAt(j).colorContinente();
                    continente++;
                    contenido2 += "cont" + continente + "[label = \" {<f0> " + grafica.ElementAt(i).getContinente().ElementAt(j).getNombre() + "|<f1> " + grafica.ElementAt(i).getContinente().ElementAt(j).getSaturacion() + "}\", color = black, fillcolor = " + grafica.ElementAt(i).getContinente().ElementAt(j).getColor() + ", style=filled];\n";
                    contenido += contenido2;
                    contenido += "inicio -> " + "cont" + continente +";\n"; 
                    Console.WriteLine("\tContinente: " + grafica.ElementAt(i).getContinente().ElementAt(j).getNombre() + " Población Total: " +
                        grafica.ElementAt(i).getContinente().ElementAt(j).getPoblacion() + " Saturación: " + grafica.ElementAt(i).getContinente().ElementAt(j).getSaturacion() + "%"+ " Color: " 
                        + grafica.ElementAt(i).getContinente().ElementAt(j).getColor());
                    for (int k = 0; k < grafica.ElementAt(i).getContinente().ElementAt(j).getPais().Count; k++)
                    {
                        pais++;
                        String contenido3 = "pais" + pais + "[label = \" {<f0> " + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getNombre() + "|<f1> " + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getSaturacion() + "}\", color = black, fillcolor = " + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getColor() + ", style=filled];\n";
                        contenido += contenido3;
                        contenido += "cont" + continente + " -> " + "pais" + pais + ";\n";
                        Console.WriteLine("\t\tPais: " + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getNombre() + " Población: " +
                            grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getPoblacion() + " Saturación: "
                            + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getSaturacion() + "%" + " Bandera: " + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getBandera() + " Color: "
                            + grafica.ElementAt(i).getContinente().ElementAt(j).getPais().ElementAt(k).getColor());
                    }
                }
            }
            contenido += "}";
            File.WriteAllText("D:\\Desktop\\Imagen.txt", contenido);


        }
    }
}
