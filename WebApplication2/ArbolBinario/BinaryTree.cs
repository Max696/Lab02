using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class BinaryTree<T> : IComparable<T>
    {
        
    }
    public static abstract class Nodo<T>
    {
        Nodo<T> left;
        Nodo<T> right;
        Nodo<T> sibling;
        Nodo<T> parent;
        bool isExternal();
        bool isInternal();
    }
}
