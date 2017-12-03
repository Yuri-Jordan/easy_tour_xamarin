using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTourYuriHugo.Models;

namespace EasyTourYuriHugo.Services
{
    public class CategoriasRoteiroService
    {
        public List<CategoriaRoteiro> getCategoriasRoteiro()
        {
            var lista = new List<CategoriaRoteiro>();
            for (int i = 0; i < 30; i++) {
                lista.Add(new CategoriaRoteiro(i, "Categoria "+ i, "12/3/2017", "Atualizada Em"));
            }

            return lista;
        }

    }
}
