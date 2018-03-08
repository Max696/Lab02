using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDA_NoLineales.Interfaces;
using TDA_NoLineales.Clases;

namespace TDA_NoLineales.Clases
{
    public class ArbolBinarioBusqueda<T> : IArbolBinario<T> 
    {

        private Nodo<T> _raiz;

        public ArbolBinarioBusqueda() {
            _raiz = null;
        }
        
        public Nodo<T> Min( Nodo<T> actual)
        {
            if (actual==null)
            {
                return null;

            }
            if (actual.left == null)
            {
                return actual;
            }
            return Min(actual.left);
        }
        public  Nodo<T> RoveToFindMin()
        {
            return Min(_raiz);
        }
        public void Eliminar(T _key)
        {
            DeleteWithNodea(_key, _raiz);
        }
        public Nodo<T> Max(Nodo<T> n)
        {
            if (n == null)
            {
                return null;

            }
            else
            {
                while (n.right != null)
                {
                    n = n.right;
                }
                return n;
            }
        }
        public Nodo<T> DeleteWithNodea(T _key, Nodo<T> pivot)
        {
            if (pivot==null)
            {
                return null;
            }
            if (pivot.CompareTo(_key)>0)
            {
               pivot.left= DeleteWithNodea(_key, pivot.left);
            }
            else if (pivot.CompareTo(_key)<0)
            {
                pivot.right=DeleteWithNodea(_key, pivot.right);
            }
            else if (pivot==_raiz)
            {

            }
          
            else
            {
                if( pivot.right==null && pivot.left==null)
                {
                    pivot = null;
                    return pivot;
                }
                else if (pivot.right == null)
                {
                    Nodo<T> aux = pivot;
                    pivot = pivot.left;
                    aux = null;
                }
                else if ( pivot.right==null)
                {
                    Nodo<T> aux = pivot;
                    pivot = pivot.right;
                    aux = null;
                }
                else
                {
                    Nodo<T> aux = Max(pivot.left);
                    pivot.value = aux.value;
                    pivot.right = DeleteWithNodea(_key, pivot.left);
                }
            }
            return pivot;

        
        }
        private void rootDelete(T _key, Nodo<T> root)
        {
            if (root != null)
            {
                if (root.CompareTo(_key) < 0)
                {
                    rootDelete(_key, root.left);
                }
                else
                {
                    if (root.CompareTo(_key) > 0)
                    {
                        rootDelete(_key, root.right);
                    }
                    else
                    {
                        Nodo<T> toDeleteNode = root;
                        if (toDeleteNode.right == null)
                        {
                            root = toDeleteNode.left;
                        }
                        else
                        {
                            if (toDeleteNode.left == null)
                            {
                                root = toDeleteNode.right;
                            }
                            else
                            {
                                Nodo<T> pivot = null;
                                Nodo<T> aux = root.left;
                                bool mark = false;
                                while (aux.right != null)
                                {
                                    pivot = aux;
                                    aux = aux.right;
                                    mark = true;
                                }
                                root.value = aux.value;
                                toDeleteNode = aux;
                                if (mark == true)
                                {
                                    pivot.right = aux.left;
                                }
                                else
                                {
                                    root.left = aux.left;
                                }
                            }
                        }
                    }
                }
            }
        }
                 
         
        public void EnOrden(RecorridoDelegate<T> _recorrido)
        {
            RecorridoEnOrdenInterno(_recorrido, _raiz);
        }

        public void Insertar(Nodo<T> _nuevo)
        {
            if (_raiz == null)
            {
                _raiz = _nuevo;
            }
            else
            {
                InsercionInterna(_raiz, _nuevo);
            }
        }

        public Nodo<T> ObtenerRaiz()
        {
            return _raiz;
        }


        public void PostOrden(RecorridoDelegate<T> _recorrido)
        {
            RecorridoPostOrdenInterno(_recorrido, _raiz);
        }

        public void PreOrden(RecorridoDelegate<T> _recorrido)
        {
            RecorridoPreOrdenInterno(_recorrido, _raiz);
        }

        private void InsercionInterna(Nodo<T> _actual, Nodo<T> _nuevo) {
            if (_actual.CompareTo(_nuevo.value) < 0)
            {
                if (_actual.right == null)
                {
                    _actual.right = _nuevo;
                }
                else
                {
                    InsercionInterna(_actual.right, _nuevo);
                }
            }
            else if (_actual.CompareTo(_nuevo.value) > 0) {
                if (_actual.left == null)
                {
                    _actual.left = _nuevo;
                }
                else 
                {
                    InsercionInterna(_actual.left, _nuevo);
                }
            }
        } //Fin de inserción interna.

        private void RecorridoEnOrdenInterno(RecorridoDelegate<T> _recorrido, Nodo<T> _actual) {    
            if (_actual != null) {
                RecorridoEnOrdenInterno(_recorrido, _actual.left);

                _recorrido(_actual);

                RecorridoEnOrdenInterno(_recorrido, _actual.right);
            }
        }

        private void RecorridoPostOrdenInterno(RecorridoDelegate<T> _recorrido, Nodo<T> _actual) {
            if (_actual != null) {
                RecorridoEnOrdenInterno(_recorrido, _actual.left);

                RecorridoEnOrdenInterno(_recorrido, _actual.right);

                _recorrido(_actual);
            }
        }

        private void RecorridoPreOrdenInterno(RecorridoDelegate<T> _recorrido, Nodo<T> _actual)
        {
            if (_actual != null)
            {
                _recorrido(_actual);

                RecorridoEnOrdenInterno(_recorrido, _actual.left);

                RecorridoEnOrdenInterno(_recorrido, _actual.right);
            }
        }
    }
}
