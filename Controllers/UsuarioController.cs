using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
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

        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            Usuario u = new UsuarioService().Listar(id);
            return View(u);
        }

        [HttpPost]

        public IActionResult Cadastro(Usuario u)
        {

            u.senha = Criptografo.TextoCriptografado(u.senha);
            new UsuarioService().Inserir(u);

            return RedirectToAction("CadastroSucesso");
        }

        public IActionResult Listar()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            UsuarioService us = new UsuarioService();
            return View(us.Listar());
        }

        public IActionResult EditarUsuario(Usuario u)
        {
            u.senha = Criptografo.TextoCriptografado(u.senha);

            new UsuarioService().Editar(u);
            return RedirectToAction("Listagem");

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

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NeedAdmin()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult CadastroSucesso()
        {
            Autenticacao.CheckLogin(this);
            return View();
        }
    }
}