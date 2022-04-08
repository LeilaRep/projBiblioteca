using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class EmprestimoService 
    {
        public void Inserir(Emprestimo e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Emprestimos.Add(e);
                bc.SaveChanges();
            }
        }

        public void Atualizar(Emprestimo e)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                Emprestimo emprestimo = bc.Emprestimos.Find(e.Id);
                emprestimo.NomeUsuario = e.NomeUsuario;
                emprestimo.Telefone = e.Telefone;
                emprestimo.LivroId = e.LivroId;
                emprestimo.DataEmprestimo = e.DataEmprestimo;
                emprestimo.DataDevolucao = e.DataDevolucao;

                bc.SaveChanges();
            }
        }

        public ICollection<Emprestimo> ListarTodos(int page, int size, FiltrosEmprestimos filtro)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                int pular = (page - 1) * size;
                IQueryable<Emprestimo> query;

                if(filtro != null)
                {
                    bc.Emprestimos.OrderByDescending(e => e.DataDevolucao).Include(e => e.Livro).ToList();

                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "Usuario":
                            query = bc.Emprestimos.Where(e => e.NomeUsuario.Contains(filtro.Filtro));
                        break;

                        case "Livro":
                            query = bc.Emprestimos.Where(e => e.Livro.Titulo.Contains(filtro.Filtro));
                        break;

                        default:
                            query = bc.Emprestimos;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Emprestimos;
                }

                return query.OrderByDescending(e => e.DataDevolucao).Include(e => e.Livro).Skip(pular).Take(size).ToList();
            }
        }

        public int CountEmprestimos()
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Emprestimos.Count();
            }
        }

        public Emprestimo ObterPorId(int id)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Emprestimos.Find(id);
            }
        }
    }
}