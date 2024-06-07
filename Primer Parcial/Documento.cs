using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Primer_Parcial
{
    public abstract class Documento
    {
        int anio;
        string autor;
        string barcode;
        Paso estado = Paso.Inicio; // REVISAR
        string numNormalizado;
        string titulo;

        public enum Paso
        {
           Inicio,
           Distribuido,
           EnEscaner,
           EnRevision,
           Terminado
        }

        public int Anio
        {
            get { return this.anio; }
        }
        public string Autor
        {
            get { return this.autor; }
        }

        public string Barcode
        {
            get { return this.barcode; }
        }
        public Paso Estado
        {
            get { return this.estado;
        }
    }
        protected string NumNormalizado
        {
            get { return this.numNormalizado; }
        }
        public string Titulo
        {
            get { return this.titulo; }
        }

        public Documento(string titulo, string autor,int anio,string numNormalizado,string barcode)
        {
            this.anio = anio;
            this.autor = autor;
            this.barcode = barcode;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
        }
        public bool AvanzarEstado()
        {
            if (this.estado != Paso.Terminado)
            {
                this.estado = (Paso)(int)(this.estado + 1);
                return true;
            }
            return false;
        }
    public override string ToString()
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine($"Titulo: {this.titulo}");
        text.AppendLine($"Autor: { this.autor}");
        text.AppendLine($"Año: {this.anio}");
        if(this is Libro)
        {
            text.AppendLine($"ISBN: {this.numNormalizado}");
        }
        text.AppendLine($"Cód. de barras: {this.barcode}");

        return text.ToString();
    }

    }
}
