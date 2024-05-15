using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using quan_li_app.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Sử dụng camel case cho tên thuộc tính trong JSON (tùy chọn)
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        // Sử dụng string enums trong JSON (tùy chọn)
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


// Add OpenAPI/Swagger document
builder.Services.AddOpenApiDocument(); // registers a OpenAPI v3.0 document with the name "v1" (default)
                                       // services.AddSwaggerDocument(); // registers a Swagger v2.0 document with the name "v1" (default)

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"));
});

builder.Services.AddDbContext<SystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SystemConnection"));
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:4200", "https://localhost:7777", "https://system-srouce.infinityfreeapp.com", "https://www.system-srouce.infinityfreeapp.com",
                              "https://58ca-2402-800-63e2-8816-44b5-67e2-1378-19b.ngrok-free.app",
                              "https://quan-tri-doanh-nghiep.click").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                      });
});



builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Quản lý",
        Description = "Phần mềm quản lý đa nền tảng",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Liên hệ 1",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Giấy phép",
            Url = new Uri("https://example.com/license")
        }
    });
});



var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}


// Thêm thư mục lưu trữ tệp vào cấu hình
var fileUploadDirectory = Path.Combine(AppContext.BaseDirectory, "Upload", "Files");
if (!Directory.Exists(fileUploadDirectory))
{
    Directory.CreateDirectory(fileUploadDirectory);
}

app.UseStaticFiles(); // Đảm bảo ứng dụng có thể phục vụ các tệp tĩnh từ thư mục lưu trữ
app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(fileUploadDirectory),
    RequestPath = "/Upload/Files" // Đường dẫn mà các tệp có thể truy cập từ bên ngoài
});


app.UseHttpsRedirection();
app.UseOpenApi();
app.UseAuthorization();
app.MapControllers();

app.Run();
