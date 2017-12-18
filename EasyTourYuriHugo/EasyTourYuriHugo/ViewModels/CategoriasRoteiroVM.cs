using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTourYuriHugo.Models;
using EasyTourYuriHugo.Services;

namespace EasyTourYuriHugo.ViewModels
{
    public class CategoriasRoteiroVM
    {
        public List<CategoriaRoteiro> listaCatRoteiros { get; set; }

        public CategoriasRoteiroVM()
        {
            inicializarChamadaAsincrona();
        }

        public async Task inicializarChamadaAsincrona()
        {
            listaCatRoteiros =  await new CategoriasRoteiroService().buscarCategoriasRoteirosAsync();

            System.Diagnostics.Debug.WriteLine("LISTA :" + listaCatRoteiros[1].nome);
        }
    }
}
