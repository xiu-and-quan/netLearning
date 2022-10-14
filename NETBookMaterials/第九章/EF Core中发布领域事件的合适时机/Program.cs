using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using �����¼�������ʱ��1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.Load("EF Core�з��������¼��ĺ���ʱ��"));
builder.Services.AddDbContext<UserDbContext>(opt => {
    string connStr = "Data Source=.;Initial Catalog=domainEvent1;Integrated Security=true";
    opt.UseSqlServer(connStr);
});
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
