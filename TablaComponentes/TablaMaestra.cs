﻿using Compilador_22023.AnalisisLexico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador_22023.TablaComponentes
{
    public class TablaMaestra
    {
        private static TablaMaestra TABLA_MAESTRA = new TablaMaestra();
        private TablaSimbolos tablaSimbolos = new TablaSimbolos();
        private TablaLiterales tablaLiterales = new TablaLiterales();
        private TablaDummys tablaDummys = new TablaDummys();
        private TablaPalabrasReservadas tablaPalabrasReservadas = new TablaPalabrasReservadas();

        public static TablaMaestra ObtenerTablaMaestra()
        {
            return TABLA_MAESTRA;
        }
        public void Limpiar()
        {
            tablaPalabrasReservadas.Limpiar();
            tablaLiterales.Limpiar();
            tablaDummys.Limpiar();
            tablaLiterales.Limpiar();
        }
        public void Agregar(ComponenteLexico componente)
        {
            tablaPalabrasReservadas.ComprobarPalabraReservada(componente);
            tablaSimbolos.Agregar(componente);
            tablaLiterales.Agregar(componente);
            tablaPalabrasReservadas.Agregar(componente);
            tablaDummys.Agregar(componente);
        }
        public List<ComponenteLexico> ObtenerSimbolo(TipoComponente tipo,string lexema)
        {
            switch (tipo)
            {
                case TipoComponente.SIMBOLO:
                    return tablaSimbolos.ObtenerSimbolo(lexema);
                case TipoComponente.LITERAL:
                    return tablaLiterales.ObtenerSimbolo(lexema);
                case TipoComponente.PALABRA_RESERVADA:
                    return tablaPalabrasReservadas.ObtenerSimbolo(lexema);
                case TipoComponente.DUMMY:
                    return tablaDummys.ObtenerSimbolo(lexema);
                default:
                    throw new Exception("Tipo de componente NO válido!");
            }
        }
        public List<ComponenteLexico> ObtenerTodosSimbolos(TipoComponente tipo)
        {
            switch (tipo)
            {
                case TipoComponente.SIMBOLO:
                    return tablaSimbolos.ObtenerTodosSimbolos();
                case TipoComponente.LITERAL:
                    return tablaLiterales.ObtenerTodosSimbolos();
                case TipoComponente.PALABRA_RESERVADA:
                    return tablaPalabrasReservadas.ObtenerTodosSimbolos();
                case TipoComponente.DUMMY:
                    return tablaDummys.ObtenerTodosSimbolos();
                default:
                    throw new Exception("Tipo de componente NO´válido!");
            }
        }
    }
}
