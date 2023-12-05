using Exam.Business.Services.Implementations;
using Exam.Business.Services.Interfaces;
using Exam.Core.Repostories;
using Exam.Data.DAL;
using Exam.Data.Repostories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();

builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlServer("Server=DESKTOP-0HH3DC0\\SQLEXPRESS;Database=MyBizz;Trusted_Connection=True");

});


var app = builder.Build();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=home}/{Action=index}");

app.UseStaticFiles();

app.Run();

