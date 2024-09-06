using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.DTO;
using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces;

public interface IServicoAplicacaoVenda
{
    IEnumerable<VendaViewModel> Listagem();
    void Cadastrar(VendaViewModel model);
    VendaViewModel CarregarRegistro(int? id);
    void Excluir(int id);
    IEnumerable<GraficoViemModel>ListaGraficos();

}
