﻿using System;
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
        public CategoriasRoteiroVM()
        {
        }

        public async Task<List<CategoriaRoteiro>> buscarRoteiros()
        {
            return await new CategoriasRoteiroService().buscarCategoriasRoteirosAsync();
        }
    }
}
