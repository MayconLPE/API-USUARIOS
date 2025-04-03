using API_USUARIOS.Models;
using Microsoft.EntityFrameworkCore;

namespace API_USUARIOS.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) {}
  
        public DbSet<UserModel> Users { get; set; }
        
    }
}