using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Token
    {

        public enum Tipo
        {
            PALABRA_RESERVADA,
            CADENA_DE_TEXTO,
            NUMERO,
            LLAVES_IZQ,
            LLAVES_DER,
            SIGNO_PUNTO_Y_COMA,
            SIGNO_DOS_PUNTOS,
            SIGNO_PORCENTAJE
        }

        private Tipo tipoToken;
        private String lexema;
        private int fila, columna;

        public Token(Token.Tipo tipoToken, String lexema, int fila, int columna)
        {
            this.tipoToken = tipoToken;
            this.lexema = lexema;
            this.fila = fila;
            this.columna = columna;
        }

        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }

        public String getLexema()
        {
            return this.lexema;
        }

        public String getTipoToken()
        {
            switch (tipoToken)
            {
                case Tipo.PALABRA_RESERVADA:
                    return "PALABRA_RESERVADA";
                case Tipo.CADENA_DE_TEXTO:
                    return "CADENA_DE_TEXTO";
                case Tipo.NUMERO:
                    return "NÚMERO";
                case Tipo.LLAVES_IZQ:
                    return "LLAVES_ABRE";
                case Tipo.LLAVES_DER:
                    return "LLAVES_CIERRA";
                case Tipo.SIGNO_DOS_PUNTOS:
                    return "SIGNO_DOS_PUNTOS";
                case Tipo.SIGNO_PUNTO_Y_COMA:
                    return "SIGNO_PUNTO_Y_COMA";
                case Tipo.SIGNO_PORCENTAJE:
                    return "SIGNO_PORCENTAJE";
                default:
                    return "DESCONOCIDO";
            }
        }
    }
}
