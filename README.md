# ShopsRUs Case Study



Uygulamayı Docker Compose  kullanarak çalıştırmak için 
Proje ana dizininde (docker-compose.yml) dosyasının olduğu dizinde  terminal açarak  

"docker compose up"
 komutu ile  gerekli tüm uygulamalar kurularak çalışmaya hazır hale gelecektir

 http://localhost:8090/swagger/index.html

 adresinde open api olarak erişilebilir olmalıdır.

 ayrıca ana dizinde bulunan 
"shopsruscase.api.postman_collection.json"
postman collection dosyası ile postman üzerindende erişilebilir 

Uygulama Başlatıldığında Otomatik olarak migrationları çalıştırıp  veritabanı ve varsayılan verileri oluşturacaktır.

veritabanında Case senaryolarını test edebilmek adına 
3 Adet Fatura  kaydı yapılmış olarak açılmaktadır 

ApplyDiscountInvoice metodu parametre olarak 
Fatura Numarası ve Fatura Toplam Turarını almaktadır ,
input model:
{
  "invoiceNo": "I00000002",
  "totalAmount": 1000
}


Faturalar  gerekli senaryolara göre kurgulanmıştır.
I00000001 - Mağazaya bağlı Müşteri örneği için
I00000002 - Personel inidirimi senaryosu için
I00000003 - diğer tip müşteriler ve 2 yıldan eski senaryosu için oluşturuldu

"totalAmount" 
parametresi  son case için  dip toplamın her 100 usd için 5 usd indir yapılamsını test için kurğulandı

ApplyDiscountInvoice metodu girilen  fatura numarası ve tutara göre fatura kalemlerinde ve net tutarda gerekli hesaplama ve indirimleri uygulayıp geriye 
fatura verisini dödürür.

/HealthCheck:
metodu Servisin çalışır durumda olduğunu teyit için kullanılabilir






