using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers;

public class ClienteController : Controller
{
    readonly IServicoAplicacaoCliente _context;

    public ClienteController(IServicoAplicacaoCliente context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
       return View(_context.Listagem());
    }

    [HttpGet]
    public IActionResult Cadastro(int? id)
    {
        ClienteViewModel viewModel = new ClienteViewModel();
        if (id != null)
        {
            viewModel = _context.CarregarRegistro(id);
        }
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Cadastro(ClienteViewModel entidade)
    {
        if (ModelState.IsValid)
        {
            _context.Cadastrar(entidade);
        }
        else
        {
            return View(entidade);
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        _context.Excluir(id);
        return RedirectToAction("Index");
    }

}
