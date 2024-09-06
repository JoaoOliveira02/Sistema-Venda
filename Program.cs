using Microsoft.EntityFrameworkCore;
using Aplicacao.Servico.Interfaces;
using Aplicacao.Servico;
using Dominio.Interfaces;
using Dominio.Servicos;
using Repositorio.Entidades;
using Dominio.Repositorio;
using Repositorio.Contexto;

var builder = WebApplication.CreateBuilder(args);

//CONEX�O STRING COM O BANCO
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//CONEX�O STRING COM O BANCO
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

//Servi�os Aplica��es
builder.Services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();
builder.Services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();
builder.Services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
builder.Services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();
builder.Services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();


//Servi�os Dominios
builder.Services.AddScoped<IServicoCategoria, ServicoCategoria>();
builder.Services.AddScoped<IServicoCliente, ServicoCliente>();
builder.Services.AddScoped<IServicoProduto, ServicoProduto>();
builder.Services.AddScoped<IServicoVenda, ServicoVenda>();
builder.Services.AddScoped<IServicoUsuario, ServicoUsuario>();


//Repositorios
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
builder.Services.AddScoped<IRepositorioVenda, RepositorioVenda>();
builder.Services.AddScoped<IRepositorioVendaProdutos, RepositorioVendaProdutos>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();





builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

