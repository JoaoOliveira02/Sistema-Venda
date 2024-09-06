using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositorio.Contexto;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers;

public class ProdutoController : Controller
{
    readonly IServicoAplicacaoProduto _context;
    readonly IServicoAplicacaoCategoria _categoria;

    public ProdutoController(IServicoAplicacaoProduto context, IServicoAplicacaoCategoria categoria)
    {
        _context = context;
        _categoria = categoria;
    }

    public IActionResult Index()
    {
        return View(_context.Listagem());
    }

    [HttpGet]
    public IActionResult Cadastro(int? id)
    {
        ProdutoViewModel viewModel = new ProdutoViewModel();
        if (id != null)
        {
            viewModel = _context.CarregarRegistro(id);
        }
        viewModel.ListaCategorias = _categoria.ListaCategoria();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Cadastro(ProdutoViewModel entidade)
    {
        if (ModelState.IsValid)
        {
            _context.Cadastrar(entidade);
        }
        else
        {
            entidade.ListaCategorias = _categoria.ListaCategoria();
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
