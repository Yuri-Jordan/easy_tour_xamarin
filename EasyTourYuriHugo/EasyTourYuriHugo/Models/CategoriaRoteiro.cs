using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTourYuriHugo.Models
{
    public class CategoriaRoteiro
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String criadaEm { get; set; }
        public String atualizadaEm { get; set; }

        public CategoriaRoteiro(int i, String n, String c, String a)
        {
            this.id = i;
            this.nome = n;
            this.criadaEm = c;
            this.atualizadaEm = a;
        }
    }
}
