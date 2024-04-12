var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(action =>
{
    action.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7020").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

// Channel ekliyoruz.
builder.Services.AddSingleton(Channel.CreateUnbounded<List<ProductDto>>());

// Dosya iþlemlerinde kullanacaðýmýz servisleri ekliyoruz.
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IMessageService, MessageService>();

builder.Services.AddHostedService<ExcelBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();