using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EasyTourYuriHugo.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Unique]
        [MaxLength(100)]
        public String nome { get; set; }

        [MaxLength(50)]
        public String senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(String nome, String senha)
        {
            this.nome = nome;
            this.senha = senha;
        }
    }
}
