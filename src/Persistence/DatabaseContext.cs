// Integração com o banco de dados

using Microsoft.EntityFrameworkCore;
// para essa integração funcione temos que chamar um comndo ja feito no caso>
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{

    // construtor logico
    public DatabaseContext
    (
        DbContextOptions<DatabaseContext> options
    ) : base(options)
    {
        
    }

    // Contexto  de banco de dados; aramzenamento dos dados
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }

    // Modulo de seguranlça 
    protected override void OnModelCreating(ModelBuilder builder){
        // this.Pessoas.Remove
        // model create para tabelas executaveis
        // 
        //  construir uma entidade aprtir de pessoa
        builder.Entity<Pessoa>(tabela =>{
            tabela.HasKey(e => e.Id);
             tabela
            //tebela para pessuas com muitos contratos
                .HasMany(e => e.contratos)
                .WithOne()
                // Chave estrangeira
                .HasForeignKey(c => c.PessoaId);
        });
        // construir uma entidade aprtir do Controto
        builder.Entity<Contrato>(tabela =>{
             tabela.HasKey(e => e.Id);
        });
    }
}