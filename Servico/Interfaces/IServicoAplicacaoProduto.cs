using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces;

public interface IServicoAplicacaoProduto
{
    IEnumerable<SelectListItem> ListaProdutos();
    IEnumerable<ProdutoViewModel> Listagem();
    void Cadastrar(ProdutoViewModel model);
    ProdutoViewModel CarregarRegistro(int? id);
    void Excluir(int id);

}
