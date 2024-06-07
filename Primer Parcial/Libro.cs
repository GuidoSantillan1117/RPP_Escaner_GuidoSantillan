using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Primer_Parcial
{
    public class Libro : Documento
    {
        int numPaginas;

        public int NumPaginas
        {
            get { return numPaginas; }
        }

        public string ISBN
        {
            get { return this.NumNormalizado; } 
        }

        public Libro(string titulo, string autor, int anio, string numNormalizado, string barcode, int numPaginas)
            : base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.numPaginas = numPaginas;
        }

        public static bool operator ==(Libro l1, Libro l2)
        {
            if (l1 is null || l2 is null) return false;

            else
            {
                if (l1.GetType() == l2.GetType())
                {
                    return l1.Barcode == l2.Barcode || l1.ISBN == l2.ISBN || l1.Titulo == l2.Titulo && l1.Autor == l2.Autor;
                }
                return false;

            }
        }

        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(base.ToString());
            text.AppendLine($"Número de paginas: {this.numPaginas}");
            return text.ToString();
        }
    }
}

