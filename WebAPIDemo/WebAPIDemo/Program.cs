using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPIDemo.data;
using WebAPIDemo.Filters.OperationFilter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ShirtStoreManagement"));
    }
);

builder.Services.AddControllers();
builder.Services.AddApiVersioning(
    options =>
    {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
      //options.ApiVersionReader = new HeaderApiVersionReader("X-API_Version");
    });

builder.Services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
builder.Services.AddSwaggerGen(c =>
{

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Web API v1", Version = "version 1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My Web API v2", Version = "version 2" });

    c.OperationFilter<AuthorizationHeaderOperationFilter>();

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });
});

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebAPI v2");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

