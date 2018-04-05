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

        public Nodo<T> _raiz { get; set; }

        public ArbolBinarioBusqueda() {
            _raiz = null;
        }
        
        public Nodo<T> Min( Nodo<T> actual)
        {
            if (actual==null)
            {
                return null;

            }
            if (actual.izquierdo == null)
            {
                return actual;
            }
            return Min(actual.izquierdo);
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
                while (n.derecho != null)
                {
                    n = n.derecho;
                }
                return n;
            }
        }
        public Nodo<T> DeleteWithNodea(T _key, Nodo<T> pivot) //Eliminar
        {
            if (pivot==null)
            {
                return null;
            }
            if (_key.CompareTo(pivot.valor)<0)
            {
               pivot.izquierdo= DeleteWithNodea(_key, pivot.izquierdo);
            }
            else if (_key.CompareTo(pivot.valor)>0)
            {
                pivot.derecho=DeleteWithNodea(_key, pivot.derecho);
            }
            else if (pivot == _raiz)
            {
                rootDelete(_key, pivot);
            }

            else
            {
                if( pivot.derecho==null && pivot.izquierdo==null)
                {
                    pivot = null;
                   
                }
                else if (pivot.derecho == null)
                {
                    Nodo<T> aux = pivot;
                    pivot = pivot.izquierdo;
                    aux = null;
                }
                else if ( pivot.izquierdo==null)
                {
                    Nodo<T> aux = pivot;
                    pivot = pivot.derecho;
                    aux = null;
                }
                else
                {
                    Nodo<T> aux = Max(pivot.izquierdo);
                    pivot.valor = aux.valor;
                    pivot.izquierdo = DeleteWithNodea(aux.valor, pivot.izquierdo);
                }
            }
            _raiz = pivot;
            return pivot;

        
        }
        private void rootDelete(T _key, Nodo<T> root)
        {
            if (root != null)
            {
                if (root.CompareTo(_key) < 0)
                {
                    rootDelete(_key, root.izquierdo);
                }
                else
                {
                    if (root.CompareTo(_key) > 0)
                    {
                        rootDelete(_key, root.derecho);
                    }
                    else
                    {
                        Nodo<T> toDeleteNode = root;
                        if (toDeleteNode.derecho == null)
                        {
                            root = toDeleteNode.izquierdo;
                        }
                        else
                        {
                            if (toDeleteNode.izquierdo == null)
                            {
                                root = toDeleteNode.derecho;
                            }
                            else
                            {
                                Nodo<T> pivot = null;
                                Nodo<T> aux = root.izquierdo;
                                bool mark = false;
                                while (aux.derecho != null)
                                {
                                    pivot = aux;
                                    aux = aux.derecho;
                                    mark = true;
                                }
                                root.valor = aux.valor;
                                toDeleteNode = aux;
                                if (mark == true)
                                {
                                    pivot.derecho = aux.izquierdo;
                                }
                                else
                                {
                                    root.izquierdo = aux.izquierdo;
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
        int right = 0;
        int left = 0;
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
            if (_actual.CompareTo(_nuevo.valor) < 0)
            {
                if (_actual.derecho == null)
                {
                    _actual.derecho = _nuevo;
                    right++;
                }
                else
                {
                    InsercionInterna(_actual.derecho, _nuevo);
                }
            }
            else if (_actual.CompareTo(_nuevo.valor) > 0) {
                if (_actual.izquierdo == null)
                {
                    _actual.izquierdo = _nuevo;
                    left++;
                }
                else 
                {
                    InsercionInterna(_actual.izquierdo, _nuevo);
                }
            }
        } //Fin de inserción interna.
        public bool Balanceado()
        {
            bool TOrF = false;
            if ((left-right)==0)
            {
                TOrF = true;
            }
            else
            {
                TOrF = false;
            }
            return TOrF;

        }
        private void RecorridoEnOrdenInterno(RecorridoDelegate<T> _recorrido, Nodo<T> _actual) {    
            if (_actual != null) {
                RecorridoEnOrdenInterno(_recorrido, _actual.izquierdo);

                _recorrido(_actual);

                RecorridoEnOrdenInterno(_recorrido, _actual.derecho);
            }
        }

        private void RecorridoPostOrdenInterno(RecorridoDelegate<T> _recorrido, Nodo<T> _actual) {
            if (_actual != null) {
                RecorridoEnOrdenInterno(_recorrido, _actual.izquierdo);

                RecorridoEnOrdenInterno(_recorrido, _actual.derecho);

                _recorrido(_actual);
            }
        }

        private void RecorridoPreOrdenInterno(RecorridoDelegate<T> _recorrido, Nodo<T> _actual)
        {
            if (_actual != null)
            {
                _recorrido(_actual);

                RecorridoEnOrdenInterno(_recorrido, _actual.izquierdo);

                RecorridoEnOrdenInterno(_recorrido, _actual.derecho);
            }
        }
        public static int LH = 0 ;
        public static int RH = 0;
        public  int FB = RH - LH;
        public bool EsDegenerado(Nodo<T> pivot)
        {
            if (pivot.izquierdo != null && pivot.derecho != null)
            {
                return false;
            }
            else if (pivot.izquierdo != null || pivot.derecho != null)
            {
                if (pivot.izquierdo != null)
                    EsDegenerado(pivot.izquierdo);
                else
                    EsDegenerado(pivot.derecho);
            }
            else
            {
                return true;
            }
            return true;

        }

       public List<T> PreList = new List<T>();
        public void Pre(Nodo<T> pivot)
        {
           
            if(pivot!= null)
            {
                PreList.Add(pivot.valor);
                Pre(pivot.izquierdo);
                LH++;
                Pre(pivot.derecho);
                RH++;
                
            }
         
                
           
        }
        
        public List<T> InList = new List<T>();
        public void In(Nodo<T>pivot)
        {
            if( pivot!= null)
            {
                In(pivot.izquierdo);
                InList.Add(pivot.valor);
                In(pivot.derecho);
               
            }
           
        }
        public List<T> PostList = new List<T>();
        public void Post(Nodo<T> pivot)
        {
            if (pivot!= null )
            {
                 Post(pivot.izquierdo);
                 Post(pivot.derecho);
                 PostList.Add(pivot.valor);
            }
           
        }
      
    }
}
