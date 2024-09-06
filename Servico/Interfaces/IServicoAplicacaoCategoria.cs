using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces;

public interface IServicoAplicacaoCategoria
{
    IEnumerable<SelectListItem> ListaCategoria();
    IEnumerable<CategoriaViewModel> Listagem();
    void Cadastrar(CategoriaViewModel model);
    CategoriaViewModel CarregarRegistro(int? id);
    void Excluir(int id);

}
