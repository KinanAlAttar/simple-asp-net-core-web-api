using System;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using todoApi.Models;
using Microsoft.OpenApi.Models;

namespace todoApi
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
            _ = services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            _ = services.AddControllers();
            _ = services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo
                  {
                      Version = "v1",
                      Title = "Todo API",
                      Description = "A simple example ASP.NER Core Web API",
                      TermsOfService = new Uri("https://example.com/terms"),
                      Contact = new OpenApiContact
                      {
                          Name = "Kinan AlAttar",
                          Email = string.Empty,
                          Url = new Uri("https://Github.com/KinanAlAttar"),
                      },
                      License = new OpenApiLicense
                      {
                          Name = "Use Under LICX",
                          Url = new Uri("https://example.com/license")
                      }
                  });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  c.IncludeXmlComments(xmlPath);
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "todoApi v1"));
            }

            _ = app.UseDefaultFiles();
            _ = app.UseStaticFiles();

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapControllers();
              });
        }
    }
}
