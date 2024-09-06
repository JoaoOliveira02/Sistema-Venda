using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;

namespace Aplicacao.Servico.Interfaces;

public interface IServicoAplicacaoUsuario
{
    bool ValidarLogin(string email, string senha);

    Usuario RetornarDados(string email, string senha);
}
