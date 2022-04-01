using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Cadastro()
        {
            return View();
        }    
        
        public IActionResult Editar(int id)
        {
            UsuarioService service = new UsuarioService();
            Usuario usuario = service.GetUsuarioDetail(id);

            return View("Cadastro", usuario);
        }

        public IActionResult Excluir(int id)
        {
            UsuarioService service = new UsuarioService();
            Usuario usuario = service.GetUsuarioDetail(id);

            return View(usuario);
        }

        [HttpPost]

        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService usuarioService = new UsuarioService();

            if(u.Id == 0)
            {
                usuarioService.Inserir(u);
            }
            else
            {
                usuarioService.Atualizar(u);
            }

            return RedirectToAction("Listar");
        }

        public IActionResult Listar()
        {
            UsuarioService us = new UsuarioService();
            return View(us.Listar());
        }

        public IActionResult Atualizar(int id)
        {
            UsuarioService us = new UsuarioService();
            Usuario u = us.ObterPorId(id);
            return View(u);
        }

        public IActionResult Deletar(int id, string decisao)
        {
            if(decisao == "s")
            {
                UsuarioService service = new UsuarioService();
                service.Deletar(id);
            }

            return RedirectToAction("Listar");
        }
    }
}