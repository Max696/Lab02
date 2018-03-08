using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication2.Models
{
    public class Entero : IComparable<Entero>
    {
        public int entero { get; set; }

        public string path { get; set; }

        public int CompareTo(Entero obj)
        {
            if (obj == null)
                return 1;

            Entero otroEntero = obj as Entero;
            if (otroEntero != null)
                return this.entero.CompareTo(otroEntero.entero);
            else
                throw new ArgumentException("Object is not a entero");
        }
    }
}