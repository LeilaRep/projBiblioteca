using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.nomeUsuario = u.nomeUsuario;
                usuario.login = u.login;
                usuario.senha = u.senha;
                usuario.dataNascimento = u.dataNascimento;

                bc.SaveChanges();
            }
        }

        public ICollection<Usuario> Listar()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Usuario> query;
                query = bc.Usuarios;
           
                return query.OrderBy(u => u.Id).ToList();
            }
        }

        public void Deletar(int id)
        {
            using(var bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(id);
                bc.Usuarios.Remove(usuario);
                bc.SaveChanges();
            }
        }

        public Usuario GetUsuarioDetail(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Where(p => p.Id == id).SingleOrDefault();
                return usuario;
            }
        }

        public Usuario ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
    }
}