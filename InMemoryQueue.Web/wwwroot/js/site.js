// Haber verirken kullanacağımız Toast komponentinin kaç saniye görüneceğini global olarak burada tanımlıyoruz.
var toastTimeout;

// Server üzerindeki hub'a bağlanarak gelecek mesajları anında yakalayıp kullanıcıya gösteriyoruz.
$(document).ready(function () {
    const connection = new window.signalR.HubConnectionBuilder().withUrl("/excelHub").build();

    connection.start().then(() => { console.log("Bağlantı sağlandı.") })

    connection.on("CompletedFileCreate", (downloadPath) => {
        // İlk işlemde kullanıcıya gösterdiğimiz toast süresini burada sonlandırıyoruz.
        clearTimeout(toastTimeout);

        // Yeni mesajımızı Toast komponentine ekliyoruz.
        $(".toast-body").html(`<p>Excel oluşturma işlemi tamamlanmıştır. Aşağıdaki link ile excel dosyasını indirebilirsiniz.<p>
        <a href="${downloadPath}">indir</a>
        `);

        // Toast komponentini çalıştırıyoruz.
        $("#liveToast").show();
    })
})