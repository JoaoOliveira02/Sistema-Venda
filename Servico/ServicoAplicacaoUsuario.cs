using Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using Dominio.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico;

public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
{
    private readonly IServicoUsuario ServicoUsuario;

    public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
    {
        ServicoUsuario = servicoUsuario;
    }

    public Usuario RetornarDados(string email, string senha)
    {
        // Adicione logs para depuração
        Console.WriteLine($"Buscando usuário com Email: {email} e Senha: {senha}");

        var usuario = ServicoUsuario.Listagem()
            .Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper())
            .FirstOrDefault();

        if (usuario == null)
        {
            Console.WriteLine("Nenhum usuário encontrado com os dados fornecidos.");
        }
        else
        {
            Console.WriteLine($"Usuário encontrado: {usuario.Nome}");
        }

        return usuario;
    }


    public bool ValidarLogin(string email, string senha)
    {
        return ServicoUsuario.ValidarLogin(email, senha);
    }
}
