using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EasyTourYuriHugo.Models
{
    public class Foto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [Unique]
        [MaxLength(100)]
        public String titulo { get; set; }

        [MaxLength(300)]
        public String caminho { get; set; }

        [MaxLength(20)]
        public String latitude { get; set; }

        [MaxLength(20)]
        public String longitude { get; set; }

        public Foto()
        {

        }

        public Foto(String titulo, String caminho, String latitude, String longitude)
        {
            this.titulo = titulo;
            this.caminho = caminho;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
