Bu proje ne yapıyor?

ASP.NET Core 8 Web API + EF Core (Code First)

Veritabanı: SQL Server LocalDB → StudentCoursesDb

Tablolar: Students, Courses, Enrollments (öğrenci–ders ilişkisi)

Hızlı Başlangıç (Visual Studio)

NuGet paketlerini kur:
Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools 

appsettings.json içinde bağlantı:
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\MSSQLLocalDB;Database=StudentCoursesDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}

DbContext kayıt (Program.cs’de hazır):
builder.Services.AddDbContext<SchoolDbContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:Default"]))

Migration & DB oluştur (Package Manager Console → PM>):
Add-Migration InitialCreate -Context SchoolDbContext
Update-Database -Verbose

Çalıştır (F5/Ctrl+F5) → Swagger otomatik açılır:
https://localhost:<port>/swagger

