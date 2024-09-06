using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers;

public class VendaController : Controller
{
    readonly IServicoAplicacaoVenda _context;
    readonly IServicoAplicacaoCliente _cliente;
    readonly IServicoAplicacaoProduto _produto;
    public VendaController(IServicoAplicacaoVenda context, IServicoAplicacaoProduto produto, IServicoAplicacaoCliente cliente)
    {
        _context = context;
        _produto = produto;
        _cliente = cliente;
    }

    public IActionResult Index()
    {
        return View(_context.Listagem());
    }

    // este método está apenas lendo dados do banco de dados e os exibindo na view Cadastro
    [HttpGet]
    public IActionResult Cadastro(int? id)
    {
        VendaViewModel viewModel = new()
        {
            Data = DateTime.Now.ToLocalTime(),
        };

        if (id != null)
        {
            //carrega a lista que deseja
            viewModel = _context.CarregarRegistro(id);
        }
        viewModel.ListaClientes = _cliente.ListaClientes();
        viewModel.ListaProdutos = _produto.ListaProdutos();

        return View(viewModel);
    }


    //esse método trata os dados do formulário de cadastro de produtos, valida-os, salva as alterações no banco de dados e redireciona o usuário para a página principal de produtos.
    [HttpPost]
    public IActionResult Cadastro(VendaViewModel entidade)
    {
        if (ModelState.IsValid)
        {
            _context.Cadastrar(entidade);
        }
        else
        {
            entidade.ListaClientes = _cliente.ListaClientes();
            entidade.ListaProdutos = _produto.ListaProdutos();
            return View(entidade);
        }
        return RedirectToAction("Index");
    }

    //esse método apaga o produto selecionado no formulario
    [HttpGet]
    public IActionResult Excluir(int id)
    {
        _context.Excluir(id);
        return RedirectToAction("Index");
    }

    //Ira retornar o valor do produto, puxando pelo codigo do produto
    [HttpGet("LerValorProduto/{CodigoProduto}")]
    public decimal LerValorProduto(int CodigoProduto)
    {
        return _produto.CarregarRegistro(CodigoProduto).Valor;
    }

}