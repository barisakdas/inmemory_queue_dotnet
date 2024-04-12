using InMemoryQueue.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Channel ekliyoruz.
builder.Services.AddSingleton(Channel.CreateUnbounded<List<ProductDto>>());

// Dosya iþlemlerinde kullanacaðýmýz servisleri ekliyoruz.
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IMessageService, MessageService>();

builder.Services.AddHostedService<ExcelBackgroundService>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Dosya oluþturma iþlemi bittikten sonra Server tarafý Client üzerine mesaj gönderecek.
app.MapHub<ExcelHub>("/excelHub");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();