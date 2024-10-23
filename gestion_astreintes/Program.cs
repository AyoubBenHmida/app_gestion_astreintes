using gestion_astreintes.Data;
using gestion_astreintes.Repositories.Implementation;
using gestion_astreintes.Repositories.Interfaces;
using gestion_astreintes.Services.Implementation;
using gestion_astreintes.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITeamRepository, TeamRepository>();

builder.Services.AddTransient<ITeamService , TeamService>();

builder.Services.AddTransient<ITeamMemberRepository, TeamMemberRepository>();

builder.Services.AddTransient<ITeamMemberService, TeamMemberService>();

builder.Services.AddTransient<IAstreinteRepository, AstreinteRepository>();

builder.Services.AddTransient<IAstreinteService, AstreinteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ) );

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<DataContext>(); 


var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowReactApp");

app.UseRouting();

app.MapControllers();

app.Run();
