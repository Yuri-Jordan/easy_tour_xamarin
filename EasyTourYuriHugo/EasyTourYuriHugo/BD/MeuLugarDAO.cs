using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTourYuriHugo.Models;

namespace EasyTourYuriHugo.BD
{
    public class MeuLugarDAO
    {
        readonly SQLiteAsyncConnection conexao;

        public MeuLugarDAO(String caminhoBD)
        {
            conexao = new SQLiteAsyncConnection(caminhoBD);

            //conexao.DropTableAsync<MeuLugar>().Wait();
            conexao.CreateTableAsync<MeuLugar>().Wait();

        }

        public Task<int> salvarMeuLugar(MeuLugar meuLugar)
        {
            if (meuLugar.id != 0)
                return conexao.UpdateAsync(meuLugar);
            else
                return conexao.InsertAsync(meuLugar);
        }

        public async Task<MeuLugar> buscarMeuLugar(String titulo)
        {
            var retornado = await conexao.Table<MeuLugar>().Where(meuLugar => meuLugar.titulo.Equals(titulo)).FirstAsync();
            System.Diagnostics.Debug.WriteLine("RETORNADO :" + retornado.titulo);

            return retornado;
        }

        public Task<List<MeuLugar>> buscarMeusLugares()
        {
            return conexao.Table<MeuLugar>().ToListAsync();
        }
    }
}
