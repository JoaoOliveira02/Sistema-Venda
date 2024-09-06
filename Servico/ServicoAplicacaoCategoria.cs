using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using Dominio.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico;

public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
{
    private readonly IServicoCategoria ServicoCategoria;
         
    public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
    {
        ServicoCategoria = servicoCategoria;
    }

    public void Cadastrar(CategoriaViewModel model)
    {
        Categoria categoria = new Categoria()
        {
            Codigo= model.Codigo,
            Descricao= model.Descricao,           
        };
        ServicoCategoria.Cadastrar(categoria);
    }
    public CategoriaViewModel CarregarRegistro(int? id)
    {
        if (id == null) return new CategoriaViewModel();
        var registro = ServicoCategoria.CarregarRegistro(id);

        CategoriaViewModel categoria = new CategoriaViewModel()
        {
            Codigo = registro.Codigo,
            Descricao = registro.Descricao,
        };
        return categoria;
    }

    public IEnumerable<CategoriaViewModel> Listagem()
    {
        var lista = ServicoCategoria.Listagem();
        List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();
        foreach (var item in lista)
        {
            CategoriaViewModel categoria = new CategoriaViewModel()
            {
                Codigo = item.Codigo,
                Descricao = item.Descricao,
            };
            listaCategoria.Add(categoria);
        }
        return listaCategoria;
    }
    public IEnumerable<SelectListItem> ListaCategoria()
    {
        List<SelectListItem> retorno = new List<SelectListItem>();
        var lista = this.Listagem();

        foreach (var item in lista)
        {
            SelectListItem categoria = new SelectListItem()
            {
                Value = item.Codigo.ToString(),
                Text = item.Descricao,
            };
            retorno.Add(categoria);
        }
        return retorno;
    } 


    public void Excluir(int id)
    {
        ServicoCategoria.Excluir(id);
    }

}
