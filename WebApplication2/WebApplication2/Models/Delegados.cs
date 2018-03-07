using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDA_NoLineales.Clases;

namespace TDA_NoLineales.Interfaces
{
    public delegate int ComparadorNodosDelegate<T>(T _actual, T _nuevo);

    public delegate void RecorridoDelegate<T>(Nodo<T> _acutal);
}
