using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//Migrations ------ 数据迁移 ------- 合理的记录变化 -----自动apply 到 不同环境中去
//指的是当数据库结构发生变化的时候 ------User table ------ Add Column ----- IsVIP
builder.Services.AddControllers().AddJsonOptions(x=> 
x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<PaintStoreDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("PaintStoreDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
