using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDA_NoLineales.Interfaces;
using TDA_NoLineales.Clases;

namespace TDA_NoLineales.Clases
{
    public class ArbolBinarioBusqueda<T> : IArbolBinario<T> where T:IComparable<T>
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
            DeleteWithNode(_key, _raiz);
        }
        public void DeleteWithNode(T _key, Nodo<T> Actual)
        {
            if (Actual==null)
            {
                return;
            }
            if (_key.CompareTo(Actual.value)<0)
            {
                DeleteWithNode(_key, Actual.left);
            }
            else if (_key.CompareTo(Actual.value)>0)
            {
                DeleteWithNode(_key, Actual.right);
            }
            else if (Actual.left != null && Actual.right!=null)
            {
                Actual.value = Min(Actual.right).value;
                DeleteWithNode(Actual.value, Actual.right);
            }
            else
            {
                Actual = (Actual.left != null) ? Actual.left : Actual.right;
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
