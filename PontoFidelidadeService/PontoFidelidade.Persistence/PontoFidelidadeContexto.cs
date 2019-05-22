using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PontoFidelidade.Domain.Models;

namespace PontoFidelidade.Persistence
{
    public class PontoFidelidadeContexto : IdentityDbContext<Usuario, Role, int,
                    IdentityUserClaim<int>, UsuarioRole,
                    IdentityUserLogin<int>,
                    IdentityRoleClaim<int>,
                    IdentityUserToken<int>>
    {
        public PontoFidelidadeContexto(DbContextOptions<PontoFidelidadeContexto> options)
                : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteMovimentacao> ClienteMovimentacao { get; set; }
        public DbSet<ClientePontoFidelidade> ClientePontoFidelidade { get; set; }
        public DbSet<Loja> Loja { get; set; }

        public DbSet<Domain.Models.Fotografia.MovimentacaoFotografia> MovimentacaoFotografia { get; set; }
        public DbSet<Domain.Models.Fotografia.ClienteMovimentacaoFotografia> ClienteMovimentacaoFotografia { get; set; }
        public DbSet<Domain.Models.Fotografia.PontoFidelidadeFotografia> PontoFidelidadeFotografia { get; set; }
        public DbSet<Domain.Models.Fotografia.ClientePontoFidelidadeFotografia> ClientePontoFidelidadeFotografia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UsuarioRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();
                userRole.HasOne(ur => ur.Usuario)
                        .WithMany(r => r.UsuarioRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });

            modelBuilder.Entity<Cliente>()
                .Ignore(c => c.SaldoAtual)
                .Ignore(c => c.PontosAtual);
        }
    }
}