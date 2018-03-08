using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using TDA_NoLineales.Interfaces;
using TDA_NoLineales.Clases;

namespace WebApplication2.DBContext
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection Instance;
        private static object syncRoot = new Object();

        public ArbolBinarioBusqueda<Pais> Paises = new ArbolBinarioBusqueda<Pais>();
        public List<string> pai = new List<string>();
        public ArbolBinarioBusqueda<Entero> entero = new ArbolBinarioBusqueda<Entero>();
        public ArbolBinarioBusqueda<Cadena> cadena = new ArbolBinarioBusqueda<Cadena>();

        public int IDActual { get; set; }

        private DefaultConnection()
        {
            IDActual = 0;
        }

        public static DefaultConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DefaultConnection();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}