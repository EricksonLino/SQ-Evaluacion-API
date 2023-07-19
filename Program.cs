using Microsoft.EntityFrameworkCore;
using SQ_Evaluacion_API;
using SQ_Evaluacion_API.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(cfg => cfg.UseSqlServer
                (builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<DapperDbContext>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(c => c.AddPolicy("GeneralPolicy", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("GeneralPolicy");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
