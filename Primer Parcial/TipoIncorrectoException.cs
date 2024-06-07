using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_Parcial
{
    public class TipoIncorrectoException : Exception
    {
        string nombreClase;
        string nombreMetodo;

        public string NombreClase
        {
            get { return nombreClase; }

        }
        public string NombreMetodo
        {
            get { return nombreMetodo; }
        }
        public TipoIncorrectoException(string mensaje,string nombreClase,string nombreMetodo):base (mensaje)
        {
            this.nombreMetodo = nombreMetodo;
            this.nombreClase = nombreClase;

        }

        public TipoIncorrectoException(string mensaje, string nombreClase, string nombreMetodo,Exception innerException):base(mensaje,innerException)
        {
            this.nombreMetodo = nombreMetodo;
            this.nombreClase = nombreClase;  
        }

        public override string ToString()
        {
            StringBuilder txt = new StringBuilder();
            txt.AppendLine($"Excepcion en el metodo {this.nombreMetodo} de la clase {this.nombreClase}");
            txt.AppendLine("Algo salió mal, revisa los detalles.");
            if (this.InnerException != null)
            {
                txt.AppendLine($"Detalles:{this.InnerException}");
            }
            return txt.ToString();
        }
    }
}
