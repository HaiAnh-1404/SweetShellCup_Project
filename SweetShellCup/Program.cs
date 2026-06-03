using Microsoft.EntityFrameworkCore;
using SweetShellCup.Models;
using SweetShellCup.Interfaces;
using SweetShellCup.Repositories;
using SweetShellCup.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    })
    .AddCookie("External")
    .AddGoogle(options =>
    {
        options.SignInScheme = "External";
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "PLACEHOLDER_CLIENT_ID";
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? "PLACEHOLDER_CLIENT_SECRET";
    });

// Database
//builder.Services.AddDbContext<SweetShellCupDbContext>(opt =>
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

// Đảm bảo có dòng dùng chuỗi kết nối từ appsettings
var connectionString = builder.Configuration.GetConnectionString("MyCnn");

// Tự động sử dụng biến môi trường DATABASE_URL nếu có trên Render
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
if (!string.IsNullOrEmpty(databaseUrl))
{
    connectionString = ConvertDatabaseUrlToConnectionString(databaseUrl);
}

// Cấu hình DbContext chuyển sang sử dụng Npgsql (PostgreSQL)
builder.Services.AddDbContext<SweetShellCupDbContext>(options =>
    options.UseNpgsql(connectionString));



// Clean Architecture - Repositories (Dependency Injection)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddHttpClient<IAIChatService, AIChatService>(client =>
{
    var timeout = builder.Configuration.GetValue<int>("AI:TimeoutSeconds", 30);
    client.Timeout = TimeSpan.FromSeconds(timeout);
});

// Session (for cart - demo user)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

// Helper method to convert postgres:// URL to Npgsql connection string
string ConvertDatabaseUrlToConnectionString(string dbUrl)
{
    var uri = new Uri(dbUrl);
    var userInfo = uri.UserInfo.Split(':');
    var username = userInfo[0];
    var password = userInfo.Length > 1 ? userInfo[1] : "";

    var dbBuilder = new NpgsqlConnectionStringBuilder
    {
        Host = uri.Host,
        Port = uri.Port > 0 ? uri.Port : 5432,
        Username = username,
        Password = password,
        Database = uri.AbsolutePath.TrimStart('/'),
        SslMode = SslMode.Require
    };

    return dbBuilder.ConnectionString;
}