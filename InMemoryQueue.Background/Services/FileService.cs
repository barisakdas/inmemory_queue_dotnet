namespace InMemoryQueue.Background.Services;

public class FileService(IFileProvider _fileProvider) : IFileService
{
    /// <summary>Yeni bir Excel dosyası için yol oluşturur.</summary>
    /// <returns>Yeni oluşturulan Excel dosyasının adı.</returns>
    public async Task<string> CreatePath()
    {
        // "Files" klasöründeki içerikleri al.
        var folder = _fileProvider.GetDirectoryContents("Files");

        // "Excels" adlı klasörü bul.
        var excelFiles = folder.Single(x => x.Name == "Excels");

        // Yeni bir Excel dosyası adı oluştur.
        var newExcelFileName = $"product-list-{Guid.NewGuid()}.xlsx";

        // Yeni Excel dosyasının tam yolunu oluştur.
        var newExcelFilePath = Path.Combine(excelFiles.PhysicalPath, newExcelFileName);

        // Yeni Excel dosyasının adını döndür.
        return newExcelFilePath;
    }
}