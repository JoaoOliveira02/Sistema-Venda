using Aplicacao.Servico.Interfaces;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Contexto;

namespace SistemaVenda.Controllers;

public class RelatorioController : Controller
{
    readonly IServicoAplicacaoVenda _context;

    public RelatorioController(IServicoAplicacaoVenda context)
    {
        _context = context;
    }

    public IActionResult Grafico()
    {
        //Isso vai pegar os dados listados, e somar para dar o total vendido de cada produto
        var lista = _context.ListaGraficos().ToList();


        //iremos criar as array agora para inserir no grafico
        string valores = string.Empty;
        string labels = string.Empty;
        string cores = string.Empty;

        var random = new Random();

        for (int i = 0; i < lista.Count; i++)
        {
            valores += "'" + lista[i].TotalVendido.ToString() + "',";
            labels += "'" + lista[i].Descricao.ToString() + "',";
            cores += "'" + String.Format("#{0:X6}",random.Next(0x1000000)) + "',";
        }

        ViewBag.Valores = valores;
        ViewBag.Labels = labels;
        ViewBag.Cores = cores;

        return View();
    }
}
