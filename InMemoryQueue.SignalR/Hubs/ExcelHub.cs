using Microsoft.AspNetCore.SignalR;

namespace InMemoryQueue.SignalR.Hubs;

/// <summary>Dosya oluşturma işlemi bittikten sonra Server tarafı Client üzerine mesaj gönderecek.
/// Client tarafının tetiklemesini gerektirecek bir durum yok. Bu yüzden Hub içerisinde tetiklenecek bir metot yazmıyoruz.</summary>
public class ExcelHub : Hub<IExcelHub>
{
}