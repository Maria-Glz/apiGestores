using apiGestores.Models;
using Microsoft.EntityFrameworkCore;

namespace apiGestores.Context
{
    public class AppDbContext: DbContext
    {
        //se manda a llamar al modelo 
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }
        //representacion de la tabla 

        public DbSet<Gestores_bd> gestores_db { get; set; }

    }
}
