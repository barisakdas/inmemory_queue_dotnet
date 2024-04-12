# IN MEMORY QUEUE .NET 8.0

Bu proje, .NET ortamında in-memory kuyruk sistemi kullanarak veri işleme ve raporlama işlemlerini gerçekleştirmek için tasarlanmıştır. 
Veriler ilgili tetiklemeler sonrasında Channel üzerine eklenmiş ve daha sonrasında consume edilerek işlenmeye hazır hale getirilmiştir.
Consume edilen veriler önce ClosedXml kütüphanesi yardımıyla excel dosyalarına dönüştürülmüş ve bu işlemin nihayi SignalR ile client tarafına bildirilmiştir.

## Katmanlar
Proje toplamda 6 katmandan oluşmaktadır.
* Api Katmanı: Api katmanı .Net 8.0 frameworkü ile projenin içindeki servis ve metotların swagger üzerinden dışarıya açtığımız ve ön yüz kullanmadan işlem yapmamızı sağlayacak şekilde dizayn edilmiştir.
* Web Katmanı: Web katmanı MVC design patter yardımıyla .Net 8.0 frameworkü üzerinde son kullanıcının ekranda listeleri ve butonları görebilmesini sağlayan görsel komponentler kullanılarak dizayn edilmiştir.
* Core Katmanı: Entity, dto ve mapper gibi çekirdek işlemlerin bulunduğu katmandır.
* Application Katmanı: Core katmanında hazırlanan entity'ler için CRUD işlemlerini yapacak servis ve araçları içerir.
* Background Katmanı: Background katmanı uçlardan ya da client'lardan gelen isteklere göre arka planda çalışacak ve excel oluşturma, clientlara gerçek zamanlı mesaj gönderme, kuyruk yönetimi gibi süreçleri yönetecek şekilde hazırlanan katmandır.
* SignalR Katmanı: Proje içerisindeki haberleşme yapılarını(Hub vs) yönetecek katmandır.

## Tekonolojiler
Proje içerisinde şu teknolojiler kullanılmıştır.
* .Net 8.0
* .Net In Memory Kuyruk Yapısı (System.Threading.Channels)
* Canlı Haberleşme (Microsoft.AspNetCore.SignalR.Core)
* Dosya Yönetimi (Microsoft.Extensions.FileProviders)
* Excel İşlemleri (ClosedXML.Excel)
* Web Projesi (Microsoft.AspNetCore.Mvc)
* Bootstrap

## Özellikler
- **Channel API**: Verileri asenkron olarak kuyruk sistemine gönderme.
- **ClosedXML**: Kuyruktan okunan verileri kullanarak Excel raporları oluşturma.
- **SignalR**: İşlemlerin tamamlanmasını takiben, client'a toast komponenti üzerinden bildirim gönderme.

## Nasıl Çalışır?

1. **Veri Gönderimi**: Uygulama, Channel API üzerinden verileri kuyruk sistemine gönderir.
2. **Veri İşleme**: Kuyruktan veriler okunur ve işlenir.
3. **Excel Raporu Oluşturma**: ClosedXML kullanılarak okunan verilerden Excel raporları oluşturulur.
4. **Bildirim Gönderimi**: SignalR aracılığıyla, client'a işlemin tamamlandığına dair bir toast bildirimi gönderilir.

## Kurulum

Projeyi lokal ortamınızda çalıştırmak için aşağıdaki adımları takip edin:
Proje hem Api katmanından hemde Web katmanından ayağa kaldırılabilir. 
Bunun için proje başlamadan başlangıç projesini seçmeniz önemlidir. Tüm config ve ayarlar iki proje içinde ayrı olarak tasarlandığı için bir bağımlılık bulunmamaktadır.

```bash
git clone https://github.com/your-repository/inmemory_queue_dotnet.git
cd inmemory_queue_dotnet
dotnet restore
dotnet build
dotnet run
```

Bu README dosyası, projenizin temel bileşenlerini ve nasıl çalıştığını açıklar. Ayrıca, projeyi nasıl kurup çalıştırabileceğinizi ve katkıda bulunma yönergelerini içerir. Projeye özgü detayları, kendi GitHub repository URL'niz ve lisans bilgileriniz ile güncellemeniz gerekecektir.