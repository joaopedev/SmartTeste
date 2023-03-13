using Microsoft.EntityFrameworkCore;
using SmartTeste.Data;
using SmartTeste.Model;
using SmartTeste.Repositorio.Interface;

namespace SmartTeste.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaCadastroDBcontext _dbContext;
        public UsuarioRepositorio(SistemaCadastroDBcontext sistemaTarefasDBContex) 
        {
            _dbContext = sistemaTarefasDBContex;
        }
        public async Task<Usuario> BuscarPorId(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException("Id nao encontrado");
            }
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID:{id} nao foi encontrado.");
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Telefone = usuario.Telefone;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id) ?? throw new Exception($"Usuario para o ID:{id} nao foi encontrado.");
            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
