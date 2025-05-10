using MinimalApi.BestPractices.Api.Routes___Practice1;
using MinimalApi.BestPractices.Api.Routes___Practice2;
using MinimalApi.BestPractices.Api.Routes___Practice4;
using MinimalApi.BestPractices.Application.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi("v1", o =>
{
    o.ShouldInclude = (apiDescription) => apiDescription.RelativePath!.Contains("v1");
});

builder.Services.AddOpenApi("v2", o =>
{
    o.ShouldInclude = (apiDescription) => apiDescription.RelativePath!.Contains("v2");
});

builder.Services.AddOpenApi("practice2", o =>
{
    o.ShouldInclude = (apiDescription) => apiDescription.RelativePath!.Contains("Post");
});

builder.Services.AddOpenApi("practice4", o =>
{
    o.ShouldInclude = (apiDescription) => apiDescription.RelativePath!.Contains("Sales");
});


builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IVideoService, VideoService>();


// Add Swagger/OpenAPI services
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();

}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();



app.MapBlogPosts();
app.MapSales();

app.Run();

