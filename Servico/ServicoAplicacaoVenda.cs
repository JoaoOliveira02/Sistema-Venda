using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using Dominio.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using Newtonsoft.Json;
using SistemaVenda.Dominio.DTO;
using Dominio.Servicos;

namespace Aplicacao.Servico;

public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
{
    private readonly IServicoVenda _context;

    public ServicoAplicacaoVenda(IServicoVenda context)
    {
        _context = context;
    }

    public void Cadastrar(VendaViewModel model)
    {
        Venda entidade = new Venda()
        {
            Codigo = model.Codigo,
            Data = model.Data.Date.ToLocalTime(),
            CodigoCliente = model.CodigoCliente,
            Total = model.Total,
            Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(model.JsonProdutos),
        };
        _context.Cadastrar(entidade);
    }
    public VendaViewModel CarregarRegistro(int? id)
    {
      var item = _context.CarregarRegistro(id);

        VendaViewModel entidade = new VendaViewModel()
        {
            Codigo = item.Codigo,
            Data = item.Data.Date.ToLocalTime(),
            CodigoCliente = item.CodigoCliente,
            Total = item.Total,
        };
        return entidade;
    }

    public IEnumerable<VendaViewModel> Listagem()
    {
        var lista = _context.Listagem();
        List<VendaViewModel> listaT = new List<VendaViewModel>();
        foreach (var item in lista)
        {
            VendaViewModel entidade = new VendaViewModel()
            {
                Codigo = item.Codigo,
                Data = item.Data.ToLocalTime(),
                CodigoCliente = item.CodigoCliente,
                Total = item.Total,
            };
            listaT.Add(entidade);
        }
        return listaT;
    }


    public void Excluir(int id)
    {
        _context.Excluir(id);
    }

    public IEnumerable<GraficoViemModel> ListaGraficos()
    {
        return _context.ListaGraficos();
    }
}
