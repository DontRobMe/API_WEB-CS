using System.Threading.RateLimiting;
using Microsoft.EntityFrameworkCore;
using TP_CS.Business.Services;
using TP_CS.Business.IServices;
using TP_CS.Business.IRepositories;
using TP_CS.Data.Context;
using TP_CS.Data.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite("Data Source=pool.db"));
builder.Services.AddScoped<IUtilisateursService , UtilisateurService>();
builder.Services.AddScoped<ITacheService , TacheService>();
builder.Services.AddScoped<ITagService , TagService>();
builder.Services.AddScoped<ITeamService , TeamService>();
builder.Services.AddScoped<IProjectService , ProjectService>();
builder.Services.AddScoped<IUserRepository , DatabaseUserRepository>();
builder.Services.AddScoped<ITaskRepository , DatabaseTaskRepository>();
builder.Services.AddScoped<IProjectRepository , DatabaseProjectRepository>();
builder.Services.AddScoped<ITagRepository , DatabaseTagRepository>();
builder.Services.AddScoped<ITeamRepository , DatabaseTeamRepository>();


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