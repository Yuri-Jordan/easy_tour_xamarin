using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using EasyTourYuriHugo.Models;

namespace EasyTourYuriHugo.BD
{
    public class UsuarioDAO
    {
        readonly SQLiteAsyncConnection conexao;

        public UsuarioDAO(String caminhoBD)
        {
            conexao = new SQLiteAsyncConnection(caminhoBD);

            //conexao.DropTableAsync<Usuario>().Wait();
            conexao.CreateTableAsync<Usuario>().Wait();

        }

        public Task<int> cadastrarUsuario(Usuario usuario)
        {
            if (usuario.id != 0)
                return conexao.UpdateAsync(usuario);
            else
                return conexao.InsertAsync(usuario);
        }

        public async Task<Usuario> buscarUsuario(String nome)
        {
            return await conexao.Table<Usuario>().Where(usuario => usuario.nome.Equals(nome)).FirstAsync();

        }

        public Task<List<Usuario>> buscarUsuarios()
        {
            return conexao.Table<Usuario>().ToListAsync();
        }
    }
}
