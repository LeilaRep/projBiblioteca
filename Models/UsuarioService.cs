using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void Inserir(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }

        public void Editar(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(u.Id);
                usuario.nomeUsuario = u.nomeUsuario;
                usuario.login = u.login;
                usuario.senha = u.senha;
                usuario.tipo = u.tipo;

                bc.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.ToList();
            }
        }

        public Usuario Listar(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }

        public void Deletar(int id)
        {
            using (var bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Find(id);
                bc.Usuarios.Remove(usuario);
                bc.SaveChanges();
            }
        }

        public Usuario GetUsuarioDetail(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                Usuario usuario = bc.Usuarios.Where(p => p.Id == id).SingleOrDefault();
                return usuario;
            }
        }

        public Usuario ObterPorId(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Usuarios.Find(id);
            }
        }
    }
}