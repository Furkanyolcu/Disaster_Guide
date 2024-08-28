using Disaster_Guide.Context;
using Disaster_Guide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace Disaster_Guide.Context
{
    public class DBcontext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FURKAN; database=DisasterGuideDB; integrated security=true; TrustServerCertificate=true");
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YELIS\\SQLEXPRESS; database=DisasterGuideDB; integrated security=true; TrustServerCertificate=true");
        }
        public DbSet<TBLuser> users { get; set; }
    }

}

public class UserService
{
    private readonly DBcontext _context;

    public UserService(DBcontext context)
    {
        _context = context;
    }

    public void AddUser(string username, string email, string password)
    {
        var parameters = new[]
        {
            new SqlParameter("@Username", SqlDbType.NVarChar) { Value = username },
            new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email },
            new SqlParameter("@Password", SqlDbType.NVarChar) { Value = password }
        };

        // Stored procedure çağrısını güncelle
        _context.Database.ExecuteSqlRaw("EXEC AddUser @Username, @Email, @Password", parameters);
    }
}

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Register(string username, string email, string password)
    {
        // Basit doğrulama (örneğin, boş değerleri kontrol et)
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            return BadRequest("Tüm alanlar doldurulmalıdır.");
        }

        try
        {
            _userService.AddUser(username, email, password);
            return Ok("Kullanıcı başarıyla eklendi.");
        }
        catch (Exception ex)
        {
            // Hata yönetimi
            return StatusCode(500, $"Sunucu hatası: {ex.Message}");
        }
    }
}
