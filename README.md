# Story Blog

ASP.NET MVC 5 ve Entity Framework ile geliştirilmiş çok kullanıcılı blog platformu.

---

## Özellikler

- Blog yazısı oluşturma, listeleme ve detay görüntüleme
- Yorum sistemi (yazar — blog ilişkisi)
- Rol bazlı kullanıcı sistemi (Admin / Author)
- EF Code First ile veritabanı yönetimi

---

## Mimari

```
Story_Blog/
├── Controllers/
│   └── ServerController/    # Blog, Author, Comment controller'ları
├── Models/
│   ├── Blog.cs              # Başlık, içerik, kapak görseli, tarih
│   ├── Author.cs            # Kullanıcı bilgisi + Rol (Admin/Author)
│   └── Comment.cs           # Yorum — yazar ve blog ilişkisi
├── Views/
│   ├── Blog/ · Author/ · Comment/ · Home/
│   └── Shared/
└── Migrations/              # EF Code First migration'ları
```

---

## Teknoloji

| | |
|---|---|
| Framework | ASP.NET MVC 5 |
| ORM | Entity Framework (Code First) |
| Veritabanı | MSSQL / LocalDB |
| Frontend | Bootstrap, jQuery |

---

## Kurulum

**Gereksinimler:** Visual Studio, MSSQL / LocalDB

```bash
git clone https://github.com/ridvancomez/Story_Blog.git
```

`Web.config` dosyasındaki connection string'i güncelle, ardından Package Manager Console'da:

```powershell
Update-Database
```

Projeyi Visual Studio'da çalıştır (F5).
