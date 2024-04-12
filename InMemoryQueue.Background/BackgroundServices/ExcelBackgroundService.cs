using InMemoryQueue.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace InMemoryQueue.Background.BackgroundServices;

/// <summary>Ürün listelerini alıp Excel dosyaları oluşturan arka plan servisi.</summary>
/// <param name="_channel">Ürün listelerinin alındığı kanal.</param>
/// <param name="_fileProvider">Dosya sağlayıcı.</param>
public class ExcelBackgroundService(Channel<List<ProductDto>> _channel, IFileService _fileService, IServiceProvider serviceProvider) : BackgroundService
{
    /// <summary>Arka plan görevinin asenkron yürütme metodu. Bu metot proje çalıştığında sadece 1 kez çalışacak.
    /// O yüzden sonsuz bir dönü yaratarak kuyruk üzerindeki verileri dinliyoruz.</summary>
    /// <param name="stoppingToken">İptal tokenı.</param>
    /// <returns>Task nesnesi.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Kanalda okunacak veri olduğu sürece döngü devam eder.
        while (await _channel.Reader.WaitToReadAsync(stoppingToken))
        {
            // Kanaldan bir ürün listesi oku.
            var products = await _channel.Reader.ReadAsync(stoppingToken);

            // Okunan ürün listesi ile bir Excel dosyası oluştur.
            await CreateExcel("Product List", products);

            // Dosya oluşturulduktan hemen sonra Client tarafına bilgi mesajı vermemiz gerekecek. Bunu da SignalR kullanarak yapıyoruz.
            // Burada Hub alırken dikkat etmemiz gerek. Çünkü Background servisler Singleton yaşam döngüsüne sahiptir.
            // Ancak Hub eklenirken Scoped olarak eklenir. Bu yüzden direkt olarak burada Hub'ı DI konteynır içerisine ekleyemeyiz.
            // Bunun yerine IServiceProvider nesnesi üzerinden erişim sağlayabiliriz.

            using (var scope = serviceProvider.CreateScope())
            {
                var excelHub = scope.ServiceProvider.GetRequiredService<IHubContext<ExcelHub>>();

                // Hub üzerinden clientları bilgilendiriyoruz.
                await excelHub.Clients.All.SendAsync("CompletedFileCreate", await _fileService.CreatePath(), stoppingToken);
            }
        }
    }

    /// <summary>Verilen ürün listesinden bir DataTable oluşturur.</summary>
    /// <param name="tableName">Oluşturulacak DataTable'ın adı.</param>
    /// <param name="products">Ürünlerin listesi.</param>
    /// <returns>Ürün bilgilerini içeren DataTable.</returns>
    private DataTable GetDataTable(string tableName, List<ProductDto> products)
    {
        // Yeni bir DataTable nesnesi oluştur ve tablo adını ayarla.
        var table = new DataTable { TableName = tableName };

        // Product sınıfının tüm özelliklerini döngüye al.
        foreach (var item in typeof(Product).GetProperties())
        {
            // Her özellik için bir sütun ekle.
            // Sütun adı olarak özellik adını, sütun tipi olarak özellik tipini kullan.
            table.Columns.Add(item.Name, item.PropertyType);
        }

        // Her bir ürün için bir satır ekle.
        products.ForEach(x =>
        {
            // Ürünün özelliklerini kullanarak yeni bir satır oluştur ve tabloya ekle.
            table.Rows.Add(x.Id, x.Name, x.Category, x.Stock, x.Price);
        });

        // Oluşturulan DataTable'ı döndür.
        return table;
    }

    /// <summary>Verilen ürün listesini kullanarak bir Excel dosyası oluşturur ve kaydeder.</summary>
    /// <param name="tableName">Excel'de kullanılacak tablo adı.</param>
    /// <param name="products">Ürünlerin listesi.</param>
    /// <returns>Task nesnesi.</returns>
    private async Task CreateExcel(string tableName, List<ProductDto> products)
    {
        // Yeni bir Excel çalışma kitabı oluştur.
        var workbook = new XLWorkbook();

        // Yeni bir DataSet nesnesi oluştur.
        var dataSet = new DataSet();

        // DataSet'e, GetDataTable metodundan dönen DataTable'ı ekle.
        dataSet.Tables.Add(GetDataTable(tableName, products));

        // Çalışma kitabına DataSet'i ekle.
        workbook.Worksheets.Add(dataSet);

        // Excel dosyasını kaydetmek için bir FileStream oluştur.
        await using var excelFileStream = new FileStream(await _fileService.CreatePath(), FileMode.Create);

        // Çalışma kitabını FileStream üzerinden kaydet.
        workbook.SaveAs(excelFileStream);
    }
}