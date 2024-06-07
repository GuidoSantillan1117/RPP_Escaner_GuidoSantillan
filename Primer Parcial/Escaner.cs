using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Primer_Parcial
{
    public class Escaner
    {
        List<Documento> listaDocumentos;
        string marca;
        TipoDoc tipo;
        Departamento locacion = Departamento.nulo;

        public enum Departamento
        {
            nulo,
            mapateca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }

        public List<Documento> ListaDocumentos
        {
            get { return this.listaDocumentos; }
        }

        public Departamento Locacion
        {
            get { return locacion; }
        }

        public string Marca
        {
            get { return this.marca; }
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.locacion = (this.tipo == TipoDoc.mapa) ? Departamento.mapateca : Departamento.procesosTecnicos;
            this.listaDocumentos = new List<Documento>();
        }

        public static bool operator ==(Escaner e, Documento d)
        {
            if ((e.locacion == Departamento.mapateca && d is not Mapa)||( e.locacion == Departamento.procesosTecnicos && d is not Libro))
            {
                throw new TipoIncorrectoException("Este escáner no acepta este tipo de documento", "Clase Escaner.cs", "Operador ==");
            }
            foreach (var documento in e.listaDocumentos)
            {
                if (documento is not null)
                {
                    if (documento is Libro && d is Libro)  
                    {
                        if ((Libro)documento == (Libro)d)
                        {
                        return true;       
                        }
                    }
                    if (documento is Mapa && d is Mapa)
                    {
                        if ((Mapa)documento == (Mapa)d)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }
        public static bool operator +(Escaner e, Documento d)
        {
            try
            {
                if (e != d)
                {
                    if (d.Estado == Documento.Paso.Inicio)
                    {
                        {
                            d.AvanzarEstado();
                            e.ListaDocumentos.Add(d);
                            return true;
                        }
                    }
                }
            }
            catch (TipoIncorrectoException exc)
            {
                throw new TipoIncorrectoException("El documento no se puede agregar a la lista.","Clase Escaner.cs", "Operador +", exc);
            }
            return false;
        }
        public bool CambiarEstadoDocumento(Documento d)
        {
            foreach (Documento item in this.listaDocumentos)
            {
                if (item.Equals(d))
                {
                    d.AvanzarEstado();
                    return true;
                }
            } 
            return false;
        }

    }
}
