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
        private const String url = "http://easy-tour-brasil-api.herokuapp.com/categorias";

        public async Task<List<CategoriaRoteiro>> buscarCategoriasRoteirosAsync() {

            RestClient<CategoriaRoteiro> restClient = new RestClient<CategoriaRoteiro>(url);

            return await restClient.buscarCategoriasRoteiro();
        }

    }
}
