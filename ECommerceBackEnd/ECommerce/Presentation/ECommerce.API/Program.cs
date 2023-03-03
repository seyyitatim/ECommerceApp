﻿using ECommerce.Application.Validators.Products;
using ECommerce.Infrastructure.Filters;
using ECommerce.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices();
// CORS ayarı
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

// eklediğimiz validator kurallarını uygulamamıza tanıttığımız kısım. RegisterValidatorsFromAssemblyContaining methodu ile verdiğimiz bir tane class ile o classın bulunduğu assemblydeki tüm validatorları bularak uygulamamıza tanıtmamıza yarıyor.
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter = true); // validator kontrolünün yazacağımız customer filter ile yapılacağınından dolayı default filterı kaldırıyoruz.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
