using Microsoft.EntityFrameworkCore;
using Sports.Application.DI;
using Sports.Infastructure.DapperORM;
using Sports.Infastructure.DataContext;
using Sports.Infastructure.DI;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfastructureStrapping();
builder.Services.ApplicationStrapping();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        ).AddRazorRuntimeCompilation();
DapperORM.ConnectionString = builder.Configuration.GetConnectionString("connectionstring");

builder.Services.AddDbContext<SportsDbContext>(
            options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connectionstring"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            }
            , ServiceLifetime.Scoped);
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
