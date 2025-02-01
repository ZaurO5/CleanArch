using CleanArch.Application.MappingProfiles;
using CleanArch.Application.UnitOfWork;
using CleanArch.Domain.Repositories;
using CleanArch.Presistence.Contexts;
using CleanArch.Presistence.Repositories;
using CleanArch.Presistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using CleanArch.Application.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x => 
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CleanArchAPI"
    });

    //x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "CleanArch.xml"));
});

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("CleanArch.Presistence")));

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<ProductMappingProfile>();
});

#region Repositories

builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

#endregion

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddApplicationExtensions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

    app.Run();
