using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace WebApplication2.Models
{
    public class Entero
    {
        public int valor { get; set; }

        public int CompareTo(Entero obj)
        {
            if (obj == null)
                return 1;

            Entero otroEntero = obj as Entero;
            if (otroEntero != null)
                return this.valor.CompareTo(otroEntero.valor);
            else
                throw new ArgumentException("Object is not a entero");
        }
    }    
}