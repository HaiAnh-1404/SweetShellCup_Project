using Microsoft.EntityFrameworkCore;
using SweetShellCup.Models;
using SweetShellCup.Interfaces;
using SweetShellCup.Repositories;
using SweetShellCup.Services;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

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

// Tự động sử dụng các biến môi trường MySQL của Railway nếu có
var mysqlHost = Environment.GetEnvironmentVariable("MYSQLHOST");
if (!string.IsNullOrEmpty(mysqlHost))
{
    var mysqlPort = Environment.GetEnvironmentVariable("MYSQLPORT") ?? "3306";
    var mysqlUser = Environment.GetEnvironmentVariable("MYSQLUSER") ?? "root";
    var mysqlPass = Environment.GetEnvironmentVariable("MYSQLPASSWORD") ?? "";
    var mysqlDb = Environment.GetEnvironmentVariable("MYSQLDATABASE") ?? "SweetShellCupDB";
    connectionString = $"Server={mysqlHost};Port={mysqlPort};Database={mysqlDb};Uid={mysqlUser};Pwd={mysqlPass};";
}
else
{
    // Hỗ trợ biến MYSQL_URL hoặc DATABASE_URL định dạng mysql://
    var mysqlUrl = Environment.GetEnvironmentVariable("MYSQL_URL") ?? Environment.GetEnvironmentVariable("DATABASE_URL");
    if (!string.IsNullOrEmpty(mysqlUrl) && mysqlUrl.StartsWith("mysql://", StringComparison.OrdinalIgnoreCase))
    {
        connectionString = ConvertMysqlUrlToConnectionString(mysqlUrl);
    }
}

// Cấu hình DbContext chuyển sang sử dụng Pomelo (MySQL)
var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
builder.Services.AddDbContext<SweetShellCupDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));



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

// Tự động chạy migrations để tạo/cập nhật cấu trúc database MySQL
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SweetShellCupDbContext>();
    try
    {
        // Đảm bảo các cột cần thiết tồn tại (phòng trường hợp migration bị kẹt)
        try { db.Database.ExecuteSqlRaw("ALTER TABLE products ADD COLUMN Ingredients text NULL;"); } catch {}
        try { db.Database.ExecuteSqlRaw("ALTER TABLE reviews ADD COLUMN ImageUrl varchar(255) NULL;"); } catch {}

        try
        {
            db.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Migration skipped/failed: {ex.Message}");
        }

        var debugInfo = new List<string>();

        // Get Databases
        debugInfo.Add("--- DATABASES ---");
        using (var command = db.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SHOW DATABASES;";
            db.Database.OpenConnection();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    debugInfo.Add(reader.GetString(0));
                }
            }
        }

        // Get Tables in current database
        debugInfo.Add("--- TABLES ---");
        using (var command = db.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SHOW TABLES;";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    debugInfo.Add(reader.GetString(0));
                }
            }
        }

        // Debug query to dump products
        debugInfo.Add("--- PRODUCTS ---");
        var products = db.Products.ToList();
        foreach (var p in products)
        {
            debugInfo.Add($"ID: {p.ProductId} | Name: {p.ProductName} | ImageUrl: {p.ImageUrl} | Price: {p.Price} | CategoryId: {p.CategoryId}");
        }

        System.IO.File.WriteAllLines("../db_products_debug.txt", debugInfo);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error running debug dump: {ex.Message}");
        System.IO.File.WriteAllText("../db_products_debug.txt", $"Error: {ex.Message}\n{ex.StackTrace}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

// Helper method to convert mysql:// URL to MySQL connection string
string ConvertMysqlUrlToConnectionString(string dbUrl)
{
    var uri = new Uri(dbUrl);
    var userInfo = uri.UserInfo.Split(':');
    var username = userInfo[0];
    var password = userInfo.Length > 1 ? userInfo[1] : "";

    return $"Server={uri.Host};Port={(uri.Port > 0 ? uri.Port : 3306)};Database={uri.AbsolutePath.TrimStart('/')};Uid={username};Pwd={password};";
}