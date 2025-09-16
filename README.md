# Picker3D Clone

Picker3D Clone, Unity ile geliştirilen bir arcade oyun projesidir. Oyunda, oyuncu bir picker (toplayıcı) ile nesneleri toplar ve seviyeleri tamamlamaya çalışır. Bu proje, modern yazılım geliştirme prensipleri ve mimari yaklaşımlar kullanılarak yapılandırılmıştır.

## Proje Mimarisi

Proje, **Command Pattern** ve **Event-Driven Architecture** gibi yazılım mimarileri kullanılarak modüler ve genişletilebilir şekilde tasarlanmıştır. Örneğin, seviye yönetimi için komutlar (`OnLevelDestroyerCommand` gibi) kullanılmıştır. Her bir oyun işlevi, kendi sorumluluk alanına sahip sınıflar ile ayrıştırılmıştır.

### Klasör Yapısı

- `Assets/Scripts/Runtime/Commands/Level`: Seviye ile ilgili komut sınıfları.
- `Assets/Scripts/Runtime/Managers`: Oyun yönetimi ve kontrol sınıfları.
- `Assets/Scripts/Runtime/Controllers`: Oyun içi nesne ve karakter kontrolü.
- `Assets/Scripts/Runtime/Events`: Oyun içi olay yönetimi.

## Kullanılan Yazım Teknikleri

- **Encapsulation (Kapsülleme):** Sınıfların iç durumları dışarıdan erişime kapalı tutulur, sadece gerekli fonksiyonlar dışarıya açılır.
- **Command Pattern:** Oyun içi işlemler (ör. seviye silme) komut nesneleri ile yönetilir.
- **Event System:** Oyun içi olaylar, event handler'lar ile dinamik olarak yönetilir.
- **Dependency Injection:** Sınıflar arası bağımlılıklar, constructor üzerinden enjekte edilir.

## SOLID Prensipleri

Proje, SOLID prensiplerine uygun olarak geliştirilmiştir:

- **Single Responsibility Principle:** Her sınıf yalnızca kendi sorumluluğundaki işlemleri gerçekleştirir. Örneğin, `OnLevelDestroyerCommand` sadece seviye silme işlemini yönetir.
- **Open/Closed Principle:** Sınıflar, yeni özellikler eklenmeye açık, değiştirilmeye kapalıdır. Yeni komutlar eklenebilir, mevcut kod bozulmaz.
- **Liskov Substitution Principle:** Türetilmiş sınıflar, taban sınıfların yerine sorunsuzca kullanılabilir.
- **Interface Segregation Principle:** Sınıflar, kullanmadıkları arayüzleri implement etmezler.
- **Dependency Inversion Principle:** Sınıflar, somut bağımlılıklar yerine soyutlamalar üzerinden çalışır.

## Katkı Sağlama

Projeye katkı sağlamak için pull request gönderebilir veya issue açabilirsin.

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır.
