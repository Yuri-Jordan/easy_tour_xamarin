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
        public List<CategoriaRoteiro> listaJson { get; set; }
        public List<CategoriaRoteiro> listaCatRoteiros { get; set; }

        public CategoriasRoteiroVM()
        {
            inicializarChamadaAsincrona();
        }

        public async Task inicializarChamadaAsincrona()
        {
            listaJson =  await new  CategoriasRoteiroService().buscarCategoriasRoteirosAsync();

            foreach (CategoriaRoteiro c in listaJson) {
                listaCatRoteiros.Add(new CategoriaRoteiro((int)c.id, c.nome, c.criadaEm));
                System.Diagnostics.Debug.WriteLine("LISTA " + c.id + "\t" + c.nome + "\t" + c.criadaEm);
            }
        }
    }
}
