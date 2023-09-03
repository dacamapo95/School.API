using Microsoft.EntityFrameworkCore;
using School.API;
using School.Domain.Repositories;
using School.Infrastructure.Database;
using School.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var startUp = new Startup(builder.Configuration);

startUp.ConfigureServices(builder.Services);

var app = builder.Build();

startUp.Configure(app, app.Environment);

app.Run();
