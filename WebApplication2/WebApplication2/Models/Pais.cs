using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Pais : IComparable<Pais>
    {
        public string Grupo { get; set; }

        public string nombre { get; set; }

        public int CompareTo(Pais obj)
        {
            if (obj == null)
                return 1;

            Pais otroPais = obj as Pais;
            if (otroPais != null)
                return this.nombre.CompareTo(otroPais.nombre);
            else
                throw new ArgumentException("Object is not a País");
        }
    }
}