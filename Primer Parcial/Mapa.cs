using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primer_Parcial
{
    public class Mapa:Documento
    {
        int alto;
        int ancho;

        public int Alto
        {
            get { return alto; }
        }
        public int Ancho
        {
            get { return ancho; }
        }
        public int Superficie
        {
            get { return alto * ancho; }
        }

        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barcode, int ancho,int alto)
            :base(titulo, autor, anio, numNormalizado, barcode)
        {
            this.alto = alto;
            this.ancho = ancho;
        }
        public static bool operator == (Mapa m1,Mapa m2)
        {

            if(m1 is null || m2 is null) return false;

            else
            {
                if (m1.GetType() == m2.GetType())
                {
                    return m1.Barcode == m2.Barcode || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);

                }
                return false;
            }

     
        }
        public static bool operator != (Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.Append(base.ToString());
            text.AppendLine($"Superficie: {this.ancho} * {this.alto} = {this.Superficie}cm2.");
            return text.ToString();
        }
    }
}
