using Microsoft.EntityFrameworkCore;
using MiniAPI;
using MiniAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextHero>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SuperHeroDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

async Task<List<Branch>> GetBranches (DbContextHero context) => 
    await context.branchs.ToListAsync();

async Task<List<SuperHero>> GetSuperHeros(DbContextHero context) =>
    await context.superheroes.ToListAsync();


app.MapGet("/", () => "Hello my fellow friends");

app.MapGet("/superhero", async (DbContextHero context) => 
    await context.superheroes.ToListAsync());

app.MapGet("/superhero/{id}", async (DbContextHero context, int id) => 
    await context.superheroes.FindAsync(id) is SuperHero hero ? Results.Ok(hero) : Results.NotFound($"Hero with {id} is not found."));

app.MapGet("/branch/{id}", async (DbContextHero context, int id) =>
    await context.branchs.FindAsync(id) is Branch br ? Results.Ok(br) : Results.NotFound($"Branch with {id} is not found."));

app.MapPost("/branch", async (DbContextHero context, Branch br) =>
{
    context.branchs.Add(br);
    await context.SaveChangesAsync();
    return Results.Ok(await GetBranches(context));
});

app.MapPost("/superhero", async (DbContextHero context, SuperHero hero) =>
{
    var x = new SuperHero
    {
        BranchId = hero.BranchId
    };
    context.superheroes.Add(x);
    await context.SaveChangesAsync();
    return Results.Ok(await GetSuperHeros(context));
});

app.Run();
