using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Helpers;
using SistemaVenda.Models;
using Microsoft.AspNetCore.Http;
using Repositorio.Contexto;
using Aplicacao.Servico.Interfaces;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        readonly IServicoAplicacaoUsuario _context;
        protected IHttpContextAccessor HttpContextAccessor;

        public LoginController(IServicoAplicacaoUsuario context, IHttpContextAccessor httpContext)
        {
            _context = context;
            HttpContextAccessor = httpContext;

        }
        public IActionResult Index(int? id)
        {
            //ISSO VAI LIMPAR A SESSAO QUANDO O USUARIO FAZER LOGOOF, NAO CONSEGUINDO ACESSAR MAIS SEM FAZER O LOGIN NOVAMENTE
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContextAccessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            ViewData["ErroLogin"] = string.Empty;
            if (ModelState.IsValid)
            {
                // CRIA UMA VARIAVEL PARA A SENHA, PARA ELA SER CRIPTOGRAFADA E DEPOIS SER COMPARADA COM O BANCO
                var Senha = Criptografia.GetHash(model.Senha);

                bool login = _context.ValidarLogin(model.Email, Senha);

                var usuario = _context.RetornarDados(model.Email, Senha);

                if (login)
                {
                    HttpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    HttpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, usuario.Codigo);
                    HttpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ErroLogin"] = "O Email ou senha informado(a) não existe no sistema !";
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }


        }
    }
}
