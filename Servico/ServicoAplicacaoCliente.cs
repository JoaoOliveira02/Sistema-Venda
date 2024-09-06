using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using Dominio.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico;

public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
{
    private readonly IServicoCliente ServicoCliente;
         
    public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
    {
        ServicoCliente = servicoCliente;
    }
    public void Cadastrar(ClienteViewModel model)
    {
        Cliente categoria = new Cliente()
        {
            Codigo= model.Codigo,
            Nome = model.Nome,
            CNPJ_CPF = model.CNPJ_CPF,
            Email = model.Email,
            Celular = model.Celular
        };
        ServicoCliente.Cadastrar(categoria);
    }

    public ClienteViewModel CarregarRegistro(int? id)
    {      
        var registro = ServicoCliente.CarregarRegistro(id);

        ClienteViewModel entidade = new ClienteViewModel()
        {
            Codigo = registro.Codigo,
            Nome = registro.Nome,
            CNPJ_CPF = registro.CNPJ_CPF,
            Email = registro.Email,
            Celular = registro.Celular
        };
        return entidade;
    }

    public IEnumerable<ClienteViewModel> Listagem()
    {
        var lista = ServicoCliente.Listagem();
        List<ClienteViewModel> listaT = new List<ClienteViewModel>();
        foreach (var item in lista)
        {
            ClienteViewModel cliente = new ClienteViewModel()
            {
                Codigo = item.Codigo,
                Nome = item.Nome,
                CNPJ_CPF = item.CNPJ_CPF,
                Email = item.Email,
                Celular = item.Celular
            };
            listaT.Add(cliente);
        }
        return listaT;
    }
    IEnumerable<SelectListItem> IServicoAplicacaoCliente.ListaClientes()
    {
        List<SelectListItem> retorno = new List<SelectListItem>();
        var lista = this.Listagem();

        foreach (var item in lista)
        {
            SelectListItem clientes = new SelectListItem()
            {
                Value = item.Codigo.ToString(),
                Text = item.Nome,
            };
            retorno.Add(clientes);
        }
        return retorno;
    }

    public void Excluir(int id)
    {
        ServicoCliente.Excluir(id);
    }

}
