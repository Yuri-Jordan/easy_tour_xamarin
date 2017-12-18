using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTourYuriHugo.Models;

namespace EasyTourYuriHugo.BD
{
    public class FotoDAO
    {
        readonly SQLiteAsyncConnection conexao;

        public FotoDAO(String caminhoBD)
        {
            conexao = new SQLiteAsyncConnection(caminhoBD);

            conexao.DropTableAsync<Usuario>().Wait();
            conexao.CreateTableAsync<Foto>().Wait();

        }

        public Task<int> salvarFoto(Foto foto)
        {
            if (foto.id != 0)
                return conexao.UpdateAsync(foto);
            else
                return conexao.InsertAsync(foto);
        }

        public async Task<Foto> buscarFoto(String titulo)
        {
            var retornado = await conexao.Table<Foto>().Where(foto => foto.titulo.Equals(titulo)).FirstAsync();
            System.Diagnostics.Debug.WriteLine("RETORNADO :" + retornado.titulo);

            return retornado;
        }
    }
}
