using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using Dominio.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico;

public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
{
    private readonly IServicoProduto servicoProduto;
         
    public ServicoAplicacaoProduto(IServicoProduto _servicoProduto)
    {
        servicoProduto = _servicoProduto;
    }

    public void Cadastrar(ProdutoViewModel model)
    {
        Produto entidade = new Produto()
        {
            Codigo= model.Codigo,
            Descricao= model.Descricao,    
            Quantidade= model.Quantidade,
            Valor = model.Valor,
            CodigoCategoria= model.CodigoCategoria,
        };
        servicoProduto.Cadastrar(entidade);
    }
    public ProdutoViewModel CarregarRegistro(int? id)
    {
        if (id == null) return new ProdutoViewModel();
        var item = servicoProduto.CarregarRegistro(id);

        ProdutoViewModel entidade = new ProdutoViewModel()
        {
            Codigo = item.Codigo,
            Descricao = item.Descricao,
            Quantidade = item.Quantidade,
            Valor = item.Valor,
            CodigoCategoria = item.CodigoCategoria,
        };
        return entidade;
    }

    public IEnumerable<ProdutoViewModel> Listagem()
    {
        var lista = servicoProduto.Listagem();
        List<ProdutoViewModel> listaT = new List<ProdutoViewModel>();
        foreach (var item in lista)
        {
            ProdutoViewModel entidade = new ProdutoViewModel()
            {
                Codigo = item.Codigo,
                Descricao = item.Descricao,
                Quantidade = item.Quantidade,
                Valor = item.Valor,
                CodigoCategoria = item.CodigoCategoria,
                DescricaoCategoria = item.Categoria.Descricao,
            };
            listaT.Add(entidade);
        }
        return listaT;
    }
    IEnumerable<SelectListItem> IServicoAplicacaoProduto.ListaProdutos()
    {
        List<SelectListItem> retorno = new List<SelectListItem>();
        var lista = this.Listagem();

        foreach (var item in lista)
        {
            SelectListItem produtos = new SelectListItem()
            {
                Value = item.Codigo.ToString(),
                Text = item.Descricao,
            };
            retorno.Add(produtos);
        }
        return retorno;
    }

    public void Excluir(int id)
    {
        servicoProduto.Excluir(id);
    }
}
