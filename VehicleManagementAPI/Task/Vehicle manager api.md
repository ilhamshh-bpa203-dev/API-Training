# Task: Nəqliyyat Şirkəti üçün Vehicle Management API

Texnologiyalar: C#, ASP.NET Core Web API, Entity Framework Core, PostgreSQL, Swagger

Məqsəd: Nəqliyyat şirkəti üçün avtomobilləri, motosikletləri və yük maşınlarını idarə edən RESTful API hazırlamalısınız. Sistem nəqliyyat vasitələrini əlavə etməli, məlumatlarını yeniləməli, silməli, yanacaq xərclərini hesablamalı, yük idarəetməsini və statistikaları təmin etməlidir.

Layihəni OOP prinsiplərindən istifadə edərək qurun. API sorğuları və cavabları JSON formatında olmalıdır.

## 1. Entity-lər və OOP strukturu

Sistemdə aşağıdakı siniflər olmalıdır:

- `Vehicle` — əsas abstract sinif
- `Car` — `Vehicle` sinfindən miras alır
- `Motorcycle` — `Vehicle` sinfindən miras alır
- `Truck` — `Vehicle` sinfindən miras alır

### Vehicle sinfi (Base Class)

Properties:

- `Id` — unikal identifikator (`int`)
- `Brand` — marka (`string`)
- `Model` — model (`string`)
- `Year` — istehsal ili (`int`)
- `PlateNumber` — qeydiyyat nömrəsi (`string`)
- `FuelLevel` — yanacaq səviyyəsi (`double`, 0–100 arası)
- `CreatedAt` — yaradılma tarixi (`DateTime`)

Metodlar:

- `GetVehicleInfo()` — nəqliyyat vasitəsinin məlumatlarını birləşdirib qaytarır. `abstract` metod olmalıdır.
- `ShowBasicInfo()` — əsas məlumatları qaytarır və ya təqdim edir. `virtual` metod olmalıdır.

Qaydalar:

- Parametrli constructor yaradın.
- `this` keyword-dən istifadə edin.
- `FuelLevel` default olaraq `100` olmalıdır.
- `PlateNumber` unikal olmalıdır.
- `Year` gələcək il ola bilməz.
- `FuelLevel` 0-dan aşağı və ya 100-dən yuxarı ola bilməz.

### Car sinfi

`Vehicle` sinfindən miras alır.

Əlavə properties:

- `DoorsCount` — qapı sayı (`int`)
- `TrunkCapacity` — baqaj tutumu (`int`, litr)
- `IsAutomatic` — avtomat sürət qutusu (`bool`)
- `MaxSpeed` — maksimum sürət (`int`)

Metodlar:

- `ShowCarInfo()` — avtomobilin məlumatlarını qaytarır.
- `CalculateFuelCost(double distance)` — yanacaq xərcini hesablayır.

Yanacaq hesablaması:

- Sərfiyyat: 8 litr / 100 km
- 1 litr yanacaq: 1.50 AZN

Formula:

\\[ (distance / 100) \times 8 \times 1.50 \\]

### Motorcycle sinfi

`Vehicle` sinfindən miras alır.

Əlavə properties:

- `EngineCapacity` — mühərrik həcmi (`int`, cc)
- `HasSidecar` — əlavə yan oturacaq olub-olmaması (`bool`)
- `MaxSpeed` — maksimum sürət (`int`)
- `Type` — növ (`string`: Sport, Cruiser, Touring)

Metodlar:

- `ShowMotorcycleInfo()` — motosikletin məlumatlarını qaytarır.
- `CalculateFuelCost(double distance)` — yanacaq xərcini hesablayır.

Yanacaq hesablaması:

- Sərfiyyat: 4 litr / 100 km
- 1 litr yanacaq: 1.50 AZN

Formula:

\\[ (distance / 100) \times 4 \times 1.50 \\]

### Truck sinfi

`Vehicle` sinfindən miras alır.

Əlavə properties:

- `CargoCapacity` — maksimum yük tutumu (`double`, ton)
- `AxleCount` — ox sayı (`int`)
- `CurrentLoad` — hazırkı yük (`double`, ton)
- `MaxSpeed` — maksimum sürət (`int`)

Metodlar:

- `ShowTruckInfo()` — yük maşınının məlumatlarını qaytarır.
- `LoadCargo(double weight)` — yük əlavə edir. Yük tutumunu yoxlamalıdır.
- `CalculateFuelCost(double distance)` — yanacaq xərcini hesablayır.

Yanacaq hesablaması:

- Əsas sərfiyyat: 25 litr / 100 km
- Hər ton yük üçün əlavə sərfiyyat: 2 litr / 100 km
- 1 litr yanacaq: 1.80 AZN

Formula:

\\[ (distance / 100) \times (25 + CurrentLoad \times 2) \times 1.80 \\]

Qaydalar:

- `weight` sıfırdan böyük olmalıdır.
- `CurrentLoad + weight` maksimum tutumu keçməməlidir.
- Yük əlavə etmək mümkün olmadıqda uyğun xəta cavabı qaytarılmalıdır.

## 2. DTO-lar və validasiya

API-də birbaşa entity-ləri qəbul və ya qaytarmaq əvəzinə DTO-lardan istifadə edin.

Aşağıdakı DTO-ları yaradın:

- `CreateCarDto`
- `CreateMotorcycleDto`
- `CreateTruckDto`
- `UpdateVehicleDto`
- `VehicleResponseDto`
- `LoadCargoDto`
- `FuelCostResponseDto`
- `VehicleStatisticsDto`

Validasiya qaydaları:

- `Brand`, `Model` və `PlateNumber` boş ola bilməz.
- `Year` etibarlı istehsal ili olmalıdır.
- `FuelLevel` 0–100 aralığında olmalıdır.
- `DoorsCount` müsbət olmalıdır.
- `TrunkCapacity` mənfi ola bilməz.
- `EngineCapacity` müsbət olmalıdır.
- `Type` yalnız `Sport`, `Cruiser`, `Touring` dəyərlərindən biri olmalıdır.
- `CargoCapacity` müsbət olmalıdır.
- `AxleCount` müsbət olmalıdır.
- `CurrentLoad` mənfi ola bilməz və `CargoCapacity`-ni keçməməlidir.
- `MaxSpeed` müsbət olmalıdır.
- `distance` sıfırdan böyük olmalıdır.

Yanlış məlumat göndərildikdə `400 Bad Request` qaytarılmalıdır.

## 3. Database və Entity Framework Core

PostgreSQL verilənlər bazası yaradın və Entity Framework Core vasitəsilə əlaqələndirin.

Tələblər:

- `AppDbContext` yaradın.
- `DbSet<Vehicle>` istifadə edin.
- Inheritance üçün TPH (Table-per-Hierarchy) strategiyasından istifadə edin.
- Hər bir nəqliyyat vasitəsinin növünü ayırd etmək üçün discriminator konfiqurasiya edin.
- `PlateNumber` üçün unikal indeks yaradın.
- Bütün CRUD əməliyyatlarında verilənlər bazasından istifadə edin.
- Məlumatlar tətbiq yenidən başladıqdan sonra da saxlanmalıdır.
- Database əməliyyatlarında async metodlardan istifadə edin.

## 4. API Controller-ləri və endpoint-lər

API-ni aşağıdakı endpoint-lərlə qurun.

### VehicleController

| HTTP Method | Endpoint                                    | Təsvir                                |
| ----------- | ------------------------------------------- | ------------------------------------- |
| GET         | `/api/vehicles`                             | Bütün nəqliyyat vasitələrini gətirir  |
| GET         | `/api/vehicles/{id}`                        | ID-yə görə nəqliyyat vasitəsini tapır |
| PUT         | `/api/vehicles/{id}`                        | Nəqliyyat məlumatlarını yeniləyir     |
| DELETE      | `/api/vehicles/{id}`                        | Nəqliyyat vasitəsini silir            |
| GET         | `/api/vehicles/search?brand=BMW`            | Marka üzrə axtarış                    |
| GET         | `/api/vehicles/type/car`                    | Növə görə filtr                       |
| GET         | `/api/vehicles/{id}/fuel-cost?distance=500` | Yanacaq xərcini hesablayır            |
| GET         | `/api/vehicles/statistics`                  | Ümumi statistikanı qaytarır           |

### CarController

| HTTP Method | Endpoint    | Təsvir                      |
| ----------- | ----------- | --------------------------- |
| POST        | `/api/cars` | Yeni avtomobil əlavə edir   |
| GET         | `/api/cars` | Bütün avtomobilləri gətirir |

### MotorcycleController

| HTTP Method | Endpoint           | Təsvir                       |
| ----------- | ------------------ | ---------------------------- |
| POST        | `/api/motorcycles` | Yeni motosiklet əlavə edir   |
| GET         | `/api/motorcycles` | Bütün motosikletləri gətirir |

### TruckController

| HTTP Method | Endpoint                | Təsvir                        |
| ----------- | ----------------------- | ----------------------------- |
| POST        | `/api/trucks`           | Yeni yük maşını əlavə edir    |
| GET         | `/api/trucks`           | Bütün yük maşınlarını gətirir |
| POST        | `/api/trucks/{id}/load` | Yük maşınına yük əlavə edir   |

Qaydalar:

- Uğurlu GET sorğuları `200 OK` qaytarmalıdır.
- Uğurlu POST sorğuları `201 Created` qaytarmalıdır.
- Uğurlu PUT və DELETE sorğuları uyğun olaraq `200 OK` və ya `204 No Content` qaytara bilər.
- Mövcud olmayan ID üçün `404 Not Found` qaytarılmalıdır.
- Yanlış sorğular üçün `400 Bad Request` qaytarılmalıdır.
- Eyni qeydiyyat nömrəsi ilə ikinci nəqliyyat vasitəsi əlavə etmək mümkün olmamalıdır.

## 5. Service Layer

Controller-lərin içində biznes məntiqi yazmayın.

Aşağıdakı service-ləri yaradın:

- `IVehicleService` və `VehicleService`
- `ICarService` və `CarService`
- `IMotorcycleService` və `MotorcycleService`
- `ITruckService` və `TruckService`

Service-lərin məsuliyyətləri:

- Verilənlər bazası ilə işləmək.
- Nəqliyyat vasitələrini əlavə etmək, yeniləmək, silmək və axtarmaq.
- Yanacaq xərclərini hesablamaq.
- Yük əlavə etmək və tutum limitini yoxlamaq.
- Statistikaları hesablamaq.
- Mövcud olmayan obyektlər üçün uyğun nəticə qaytarmaq.

Dependency Injection vasitəsilə service-ləri `Program.cs`-də qeydiyyatdan keçirin.

## 6. Yanacaq xərclərinin hesablanması

Hər bir nəqliyyat vasitəsi üçün yanacaq xərclərini API vasitəsilə hesablayın.

Nümunələr:

- Avtomobil üçün 500 km.
- Motosiklet üçün 300 km.
- Yük maşını üçün 800 km.

`GET /api/vehicles/{id}/fuel-cost?distance=500` sorğusu aşağıdakı kimi JSON cavabı qaytarmalıdır:

```
{
  "vehicleId": 1,
  "brand": "Mercedes",
  "model": "E200",
  "distance": 500,
  "fuelConsumption": 8,
  "fuelPrice": 1.5,
  "totalCost": 60
}
```

Yük maşını üçün sərfiyyat cari yükə uyğun hesablanmalıdır.

## 7. Yük idarəetməsi

Yük maşınına əlavə yük göndərmək üçün aşağıdakı endpoint-i yaradın:

`POST /api/trucks/{id}/load`

Request body:

```
{
  "weight": 5
}
```

Tələblər:

- Yük maşınının mövcud olub-olmadığını yoxlayın.
- Yükün müsbət olduğunu yoxlayın.
- Maksimum tutumun aşılıb-aşılmadığını yoxlayın.
- Uğurlu əməliyyatdan sonra `CurrentLoad` yenilənməlidir.
- Yenilənmiş məlumatı response olaraq qaytarın.

Birinci yük maşınına 5 ton əlavə etdikdən sonra onun yükü 17 ton olmalıdır.

## 8. Statistika

`GET /api/vehicles/statistics` endpoint-i yaradın.

Aşağıdakı məlumatları qaytarın:

- Ümumi nəqliyyat sayı.
- Avtomobillərin sayı.
- Motosikletlərin sayı.
- Yük maşınlarının sayı.
- Bütün nəqliyyat vasitələrinin orta maksimum sürəti.
- Ən yüksək maksimum sürətə malik nəqliyyat vasitəsi.
- 100 km üçün ən yüksək yanacaq xərci olan nəqliyyat vasitəsi.
- Bütün nəqliyyat vasitələrinin ümumi cari yükü.

Response nümunəsi:

```
{
  "totalVehicles": 7,
  "carsCount": 3,
  "motorcyclesCount": 2,
  "trucksCount": 2,
  "averageMaxSpeed": 196.14,
  "fastestVehicle": "Yamaha R1",
  "mostExpensiveFuelVehicle": "MAN TGX",
  "totalCurrentLoad": 30
}
```

Statistika real verilənlər bazasındakı məlumatlara əsaslanmalıdır. Nümunədəki rəqəmlər yalnız formatı göstərir.

## 9. Pagination, filtering və sorting

Bütün nəqliyyat vasitələrini qaytaran GET endpoint-inə əlavə imkanlar daxil edin.

Endpoint:

`GET /api/vehicles`

Query parametrləri:

- `page` — səhifə nömrəsi.
- `pageSize` — hər səhifədəki element sayı.
- `brand` — marka üzrə filtr.
- `year` — istehsal ilinə görə filtr.
- `minSpeed` — minimum sürət.
- `maxSpeed` — maksimum sürət.
- `sortBy` — sıralama sahəsi.
- `descending` — azalan sıra.

Nümunə:

`GET /api/vehicles?page=1&pageSize=5&brand=BMW&sortBy=year&descending=true`

Tələblər:

- Default olaraq birinci səhifə və 10 element qaytarılmalıdır.
- `page` və `pageSize` üçün etibarlı limitlər qoyulmalıdır.
- Filtrləmə və sıralama verilənlər bazasında icra olunmalıdır.
- Cavabda ümumi element sayı, səhifə nömrəsi və səhifə ölçüsü də göstərilməlidir.

## 10. Proqramın ilkin məlumatları (Seed Data)

Proqram başladıqda verilənlər bazasında heç bir nəqliyyat vasitəsi yoxdursa, aşağıdakı məlumatları əlavə edin.

### Avtomobillər

| Marka    | Model | İl   | Qapı | Baqaj | Avtomat | Maksimum sürət |
| -------- | ----- | ---- | ---- | ----- | ------- | -------------- |
| Mercedes | E200  | 2023 | 4    | 500   | Bəli    | 220            |
| BMW      | 320i  | 2022 | 4    | 480   | Bəli    | 235            |
| Toyota   | Camry | 2021 | 4    | 524   | Bəli    | 210            |

### Motosikletlər

| Marka           | Model   | İl   | Mühərrik | Növ     | Sidecar | Maksimum sürət |
| --------------- | ------- | ---- | -------- | ------- | ------- | -------------- |
| Yamaha          | R1      | 2023 | 998      | Sport   | Xeyr    | 299            |
| Harley-Davidson | Cruiser | 2022 | 1868     | Cruiser | Bəli    | 180            |

### Yük maşınları

| Marka | Model | İl   | Tutum | Ox sayı | Cari yük | Maksimum sürət |
| ----- | ----- | ---- | ----- | ------- | -------- | -------------- |
| MAN   | TGX   | 2020 | 18    | 3       | 12       | 120            |
| Volvo | FH16  | 2021 | 25    | 4       | 18       | 110            |

Bütün nəqliyyat vasitələrinin ilkin yanacaq səviyyəsi `100` olmalıdır.

Seed Data yalnız ilk dəfə, baza boş olduqda əlavə edilməlidir. Hər dəfə proqram işə düşəndə məlumatlar təkrar yaradılmamalıdır.

## 11. Swagger və test

Bütün endpoint-ləri Swagger vasitəsilə test edin.

Aşağıdakı ssenariləri yoxlayın:

1. Bütün nəqliyyat vasitələrini əldə edin.
2. Yeni avtomobil əlavə edin.
3. Eyni qeydiyyat nömrəsi ilə ikinci avtomobil əlavə etməyə çalışın.
4. Mövcud olmayan ID ilə məlumat əldə etməyə çalışın.
5. Avtomobilin məlumatlarını yeniləyin.
6. Avtomobili silin.
7. 500 km məsafə üçün avtomobilin yanacaq xərcini hesablayın.
8. Motosikletin yanacaq xərcini hesablayın.
9. Yük maşınına 5 ton əlavə edin.
10. Tutumdan artıq yük əlavə etməyə çalışın.
11. Statistika endpoint-ini yoxlayın.
12. Pagination, filtering və sorting əməliyyatlarını test edin.

Əlavə olaraq, ən azı bir neçə service və controller əməliyyatı üçün unit test yazın.

## 12. Layihə strukturu

Layihəni aşağıdakı kimi təşkil edin:

```
VehicleManagementAPI/
│
├── Controllers/
│   ├── VehiclesController.cs
│   ├── CarsController.cs
│   ├── MotorcyclesController.cs
│   └── TrucksController.cs
│
├── Data/
│   ├── AppDbContext.cs
│   └── DbSeeder.cs
│
├── DTOs/
│   ├── Cars/
│   ├── Motorcycles/
│   ├── Trucks/
│   └── Vehicles/
│
├── Models/
│   ├── Vehicle.cs
│   ├── Car.cs
│   ├── Motorcycle.cs
│   └── Truck.cs
│
├── Services/
│   ├── Interfaces/
│   ├── VehicleService.cs
│   ├── CarService.cs
│   ├── MotorcycleService.cs
│   └── TruckService.cs
│
├── Migrations/
│
├── Program.cs
└── appsettings.json
```

## Yekun məqsəd

Layihəni tamamladıqdan sonra aşağıdakı bacarıqlara sahib olmalısınız:

- OOP və inheritance prinsiplərini API daxilində tətbiq etmək.
- RESTful endpoint-lər qurmaq.
- DTO və validasiyadan istifadə etmək.
- EF Core və PostgreSQL ilə işləmək.
- Service Layer və Dependency Injection qurmaq.
- HTTP status kodlarını düzgün seçmək.
- Pagination, filtering və sorting yazmaq.
- Biznes məntiqini controller-lərdən ayırmaq.
- Swagger və unit test vasitəsilə API-ni yoxlamaq.

Mentor qeydi: Bu, artıq sadə başlanğıc tapşırığı deyil, kiçik bir backend layihəsidir. Hamısını bir gündə etməyə çalışma. Əvvəlcə entity-ləri və CRUD-u tamamla, sonra DTO, service, database, statistika və digər funksiyaları mərhələli əlavə et. Hər mərhələdə kodu özün yazmağa çalış; ilişdiyin yerdə konkret sual ver.