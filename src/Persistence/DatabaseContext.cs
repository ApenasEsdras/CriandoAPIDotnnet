// Integração com o banco de dados

using Microsoft.EntityFrameworkCore;
// para essa integração funcione temos que chamar um comndo ja feito no caso>
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{

    // construtor logico
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    // Contexto  de banco de dados; aramzenamento dos dados
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }
    // Modulo de seguranlça
    protected void OnModelCreating(ModelBuilder builder){
        
    }
}