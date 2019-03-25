using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Generico
    {
        private string titulo;
        private object parametro;
        private int tipo;

        public Generico(string titulo, object parametro)
        {
            this.titulo = titulo;
            this.parametro = parametro;
        }

        public Generico(string titulo, object parametro, int tipo) : this(titulo, parametro)
        {
            this.tipo = tipo;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public object Parametro { get => parametro; set => parametro = value; }
        public int Tipo { get => tipo; set => tipo = value; }
    }
}
