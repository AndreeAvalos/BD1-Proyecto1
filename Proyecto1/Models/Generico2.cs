using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Generico2
    {
        private List<Generico> lst;

        public Generico2()
        {
            lst = new List<Generico>();
        }

        public List<Generico> Lst { get => lst; set => lst = value; }
    }
}
