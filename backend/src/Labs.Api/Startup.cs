using System;
using System.Collections.Generic;
using Labs.Domain.Exames.Repositories;
using Labs.Domain.Medicos.Repositories;
using Labs.Domain.OrdensServico.Handlers;
using Labs.Domain.OrdensServico.Repositories;
using Labs.Domain.Pacientes.Repositories;
using Labs.Domain.PostosColeta.Repositories;
using Labs.Domain.Transactions;
using Labs.Infra.Contexts;
using Labs.Infra.Repositories;
using Labs.Infra.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Labs.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddEntityFrameworkNpgsql()
        .AddDbContext<LabsContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("LabsContext")));

      services.AddTransient<IExameRepository, ExameRepository>();
      services.AddTransient<IMedicoRepository, MedicoRepository>();
      services.AddTransient<IOrdemServicoRepository, OrdemServicoRepository>();
      services.AddTransient<IPacienteRepository, PacienteRepository>();
      services.AddTransient<IPostoColetaRepository, PostoColetaRepository>();
      services.AddTransient<IUoW, UoW>();
      services.AddTransient<OrdemServicoHandler, OrdemServicoHandler>();

      services.AddCors();
      services.AddControllers()
        .AddNewtonsoftJson(o =>
        {
          o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
          o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

      services.AddResponseCompression();

      services.AddSwaggerGen(c =>
        {
          c.SwaggerDoc(
              "v1",
              new OpenApiInfo
              {
                Title = "Clinical Labs API",
                Version = "v1",
                Description = "Especificações das API do Clinical Labs.",
                Contact = new OpenApiContact
                {
                  Email = "smuriano@gmail.com",
                  Name = "Sidney Muriano",
                  Url = new Uri("https://github.com/smuriano"),
                },
                License = new OpenApiLicense
                {
                  Name = "MIT License",
                  Url = new Uri("https://opensource.org/licenses/MIT"),
                }
              });

          c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
          {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            Description = "Inserir o Bearer token para acessar está API",
          });

          c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
            {
             new OpenApiSecurityScheme
             {
                Reference = new OpenApiReference
                {
                 Type = ReferenceType.SecurityScheme,
                 Id = "bearer",
                }
             },
             new List<string>()
            },
          });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      }

      app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinical Labs API vV1");
        c.RoutePrefix = string.Empty;
      });

      app.UseResponseCompression();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
