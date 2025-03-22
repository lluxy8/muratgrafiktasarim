# Proje Analizi

## Genel Yapı
Proje, Clean Architecture prensiplerine uygun olarak tasarlanmış bir .NET 8.0 uygulamasıdır. Katmanlı mimari kullanılarak geliştirilmiştir.

### Katmanlar
1. **Core** - Temel katman
2. **Application** - İş mantığı katmanı
3. **Infrastructure** - Altyapı katmanı
4. **Web** - Sunum katmanı
5. **ApplicationTests** - Test katmanı

## Core Katmanı
Temel yapı taşlarını içeren katmandır.

### Klasör Yapısı
- **Entities/** - Veritabanı entity'leri
- **Interfaces/** - Temel interface'ler
- **Models/** - Model sınıfları
- **DTOs/** - Data Transfer Objects

### Önemli Bileşenler
- `IGenericRepository<T>` - Generic repository interface'i
  - CRUD operasyonları
  - Koşullu sorgulama metodları
  - Asenkron operasyonlar

## Application Katmanı
İş mantığının yürütüldüğü katmandır.

### Klasör Yapısı
- **Commands/** - CQRS Command'ları
  - **Req/** - Request modelleri
  - **Res/** - Response modelleri
- **Queries/** - CQRS Query'leri
- **Handlers/** - Command ve Query handler'ları
- **Validators/** - Validasyon sınıfları
- **Common/** - Ortak kullanılan sınıflar
- **Behaviors/** - MediatR davranışları

### Özellikler
- CQRS pattern'i kullanılmış
- MediatR ile command/query yönetimi
- FluentValidation ile validasyon
- Her modül için ayrı klasör yapısı (Admin, Project, Category, WebProfile)

## Infrastructure Katmanı
Veritabanı ve dış servis entegrasyonlarının yapıldığı katmandır.

### Klasör Yapısı
- **Repositories/** - Repository implementasyonları
- **Configurations/** - Entity konfigürasyonları
- **Migrations/** - Veritabanı migration'ları

### Önemli Bileşenler
- `GenericRepository<T>` - Generic repository implementasyonu
  - Entity Framework Core kullanımı
  - Asenkron operasyonlar
  - CRUD metodları
- `UnitOfWork` - Transaction yönetimi
- `AppDbContext` - Entity Framework context

## Test Katmanı
Unit testlerin yazıldığı katmandır.

### Özellikler
- xUnit test framework'ü
- Moq ile mock'lama
- FluentAssertions ile assertion'lar
- Her modül için ayrı test sınıfları

## Kod Stili ve Konvansiyonlar
1. **Namespace Yapısı**
   - Her katman kendi namespace'ini kullanır
   - Alt klasörler namespace'e dahil edilir

2. **Dosya İsimlendirme**
   - PascalCase kullanılır
   - Interface'ler "I" prefix'i ile başlar
   - Handler'lar "Handler" suffix'i ile biter

3. **Klasör Yapısı**
   - Her modül kendi klasöründe
   - Request/Response modelleri ayrı klasörlerde
   - Testler ilgili modül klasöründe

4. **CQRS Yapısı**
   - Command'lar: Create, Update, Delete işlemleri
   - Query'ler: Read işlemleri
   - Her command/query için ayrı handler

5. **Repository Pattern**
   - Generic repository base class
   - Entity-specific repository'ler
   - UnitOfWork ile transaction yönetimi

## Teknolojiler ve Paketler
- .NET 8.0
- Entity Framework Core
- MediatR
- FluentValidation
- xUnit
- Moq
- FluentAssertions

## Güvenlik ve Performans
- Asenkron operasyonlar
- CancellationToken kullanımı
- Generic repository ile kod tekrarını önleme
- CQRS ile okuma/yazma operasyonlarının ayrılması 