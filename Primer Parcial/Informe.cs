using Primer_Parcial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static Primer_Parcial.Documento;

namespace Primer_Parcial
{
    public static class Informes
    {
        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";
            Type tipoDocumento = (e.Locacion == Escaner.Departamento.mapateca) ? typeof(Mapa) : typeof(Libro);

            foreach (var doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    if (tipoDocumento == typeof(Mapa))
                    {
                        Mapa mapa = (Mapa)doc;
                        extension += mapa.Superficie;
                        resumen += mapa.ToString();

                    }
                    else if (tipoDocumento == typeof (Libro))
                    {
                        Libro libro = (Libro)doc;
                        extension += libro.NumPaginas;
                        resumen += libro.ToString();
                    }

                    cantidad += 1;
                }
            }
        }

        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            Informes.MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }

    }
}
