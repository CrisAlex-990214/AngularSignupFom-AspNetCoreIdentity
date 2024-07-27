using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignupIdentity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddCors();

var app = builder.Build();

app.MapPost("/", async ([FromBody] RegisterUserDto dto, UserManager<User> userManager) =>
{
    User user = new() { Email = dto.Email, UserName = dto.UserName };
    var result = await userManager.CreateAsync(user, dto.Password);

    return result.Succeeded ? Results.Ok(user.Id) : Results.BadRequest(result.Errors);
});

app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
