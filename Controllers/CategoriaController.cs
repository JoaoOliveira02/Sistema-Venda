using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers;

public class CategoriaController : Controller
{
    readonly IServicoAplicacaoCategoria _context;

    public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
    {
        _context = servicoAplicacaoCategoria;
    }

    public IActionResult Index()
    {
        return View(_context.Listagem());
    }

    [HttpGet]
    public IActionResult Cadastro(int? id)
    {
        CategoriaViewModel viewModel = new CategoriaViewModel();
        if (id != null) 
        { 
            viewModel = _context.CarregarRegistro(id);     
        }   
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Cadastro(CategoriaViewModel entidade)
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
