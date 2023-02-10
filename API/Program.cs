using Aplicacao.Usuarios.Profiles;
using Aplicacao.Usuarios.Servicos;
using Aplicacao.Usuarios.Servicos.Interfaces;
using Dominio.Interfaces;
using Dominio.Usuarios.Interfaces;
using Dominio.Usuarios.Servicos;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infra.Mapeamentos;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(UsuariosProfiles));

builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x =>
    {

        x.FluentMappings.AddFromAssemblyOf<UsuariosMap>();



    }).BuildSessionFactory();
});


builder.Services.AddSingleton<ISession>(factory =>
{
    return factory.GetService<ISessionFactory>()!.OpenSession();
});

builder.Services.AddSingleton<IUsuariosRepositorio, UsuariosRepositorio>();
builder.Services.AddSingleton<IUsuariosAppServico, UsuariosAppServico>();
builder.Services.AddSingleton<IUsuarioServico, UsuarioServico>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    
    app.UseSwaggerUI();

    app.UseCors(c=>{
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();