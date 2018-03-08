using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Cadena : IComparable<Cadena>
    {
        public string cadena { get; set; }

        public int CompareTo(Cadena obj)
        {
            if (obj == null)
                return 1;

            Cadena otraCadena = obj as Cadena;
            if (otraCadena != null)
                return this.cadena.CompareTo(otraCadena.cadena);
            else
                throw new ArgumentException("Object is not a cadena");
        }
    }
}