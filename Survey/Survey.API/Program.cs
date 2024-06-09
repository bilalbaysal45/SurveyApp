using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Survey.Business.Abstract;
using Survey.Business.Concrete;
using Survey.Data.Abstract;
using Survey.Data.Concrete.EfCore.Contexts;
using Survey.Data.Concrete.EfCore.Repository;
using Survey.Entity.Concrete;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISurveyRepository, EfCoreSurveyRepository>();
builder.Services.AddScoped<ISurveyService, SurveyManager>();
builder.Services.AddScoped<IQuestionRepository, EfCoreQuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
