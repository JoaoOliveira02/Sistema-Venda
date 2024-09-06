using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces;

public interface IServicoAplicacaoCliente
{
    IEnumerable<SelectListItem> ListaClientes();
    IEnumerable<ClienteViewModel> Listagem();
    void Cadastrar(ClienteViewModel model);
    ClienteViewModel CarregarRegistro(int? id);
    void Excluir(int id);

}
