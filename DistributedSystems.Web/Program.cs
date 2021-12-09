using DistributedSystems.Entities.Extensions;
using DistributedSystems.Web.Database;
using DistributedSystems.Web.Extensions;
using DistributedSystems.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
       .AddAmqp()
       .AddDbContext<AppDbContext>((ctx, options) =>
           options.UseNpgsql(ctx.GetRequiredService<IConfiguration>()
                                .GetConnectionString("PostgreSQL")))
       .AddSingleton<InternalAuthService>()
       .AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();
app.MapControllers();

app.RunMigrations()
   .DeclareExchanges()
   .Run();