using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoFidelidade.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LojaId = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Loja",
                columns: table => new
                {
                    LojaId = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 999999, nullable: true),
                    ChaveIntegracao = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loja", x => x.LojaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientePontoFidelidade",
                columns: table => new
                {
                    ClientePontoFidelidadeId = table.Column<Guid>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false),
                    IdLoja = table.Column<Guid>(nullable: false),
                    Pontos = table.Column<long>(nullable: false),
                    SaldoAtual = table.Column<long>(nullable: false),
                    Operacao = table.Column<int>(nullable: false),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePontoFidelidade", x => x.ClientePontoFidelidadeId);
                    table.ForeignKey(
                        name: "FK_ClientePontoFidelidade_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoFotografia",
                columns: table => new
                {
                    MovimentacaoFotografiaId = table.Column<Guid>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false),
                    SaldoInicial = table.Column<decimal>(nullable: false),
                    SaldoFinal = table.Column<decimal>(nullable: false),
                    DataInicialFotografia = table.Column<DateTime>(nullable: false),
                    DataFinalFotografia = table.Column<DateTime>(nullable: false),
                    QuantidadeOperacoes = table.Column<int>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoFotografia", x => x.MovimentacaoFotografiaId);
                    table.ForeignKey(
                        name: "FK_MovimentacaoFotografia_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontoFidelidadeFotografia",
                columns: table => new
                {
                    PontoFidelidadeFotografiaId = table.Column<Guid>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false),
                    SaldoInicial = table.Column<long>(nullable: false),
                    SaldoFinal = table.Column<long>(nullable: false),
                    DataInicialFotografia = table.Column<DateTime>(nullable: false),
                    DataFinalFotografia = table.Column<DateTime>(nullable: false),
                    QuantidadeOperacoes = table.Column<int>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoFidelidadeFotografia", x => x.PontoFidelidadeFotografiaId);
                    table.ForeignKey(
                        name: "FK_PontoFidelidadeFotografia_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMovimentacao",
                columns: table => new
                {
                    ClienteMovimentacaoId = table.Column<Guid>(nullable: false),
                    IdCliente = table.Column<Guid>(nullable: false),
                    IdLoja = table.Column<Guid>(nullable: false),
                    Valor = table.Column<long>(nullable: false),
                    SaldoAtual = table.Column<long>(nullable: false),
                    Operacao = table.Column<int>(nullable: false),
                    DataOperacao = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true),
                    LojaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMovimentacao", x => x.ClienteMovimentacaoId);
                    table.ForeignKey(
                        name: "FK_ClienteMovimentacao_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClienteMovimentacao_Loja_LojaId",
                        column: x => x.LojaId,
                        principalTable: "Loja",
                        principalColumn: "LojaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMovimentacaoFotografia",
                columns: table => new
                {
                    ClienteMovimentacaoFotografiaId = table.Column<Guid>(nullable: false),
                    IdMovimentacaoFotografia = table.Column<Guid>(nullable: false),
                    FotografiaMovimentacaoFotografiaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMovimentacaoFotografia", x => x.ClienteMovimentacaoFotografiaId);
                    table.ForeignKey(
                        name: "FK_ClienteMovimentacaoFotografia_MovimentacaoFotografia_FotografiaMovimentacaoFotografiaId",
                        column: x => x.FotografiaMovimentacaoFotografiaId,
                        principalTable: "MovimentacaoFotografia",
                        principalColumn: "MovimentacaoFotografiaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientePontoFidelidadeFotografia",
                columns: table => new
                {
                    ClientePontoFidelidadeFotografiaId = table.Column<Guid>(nullable: false),
                    IdPontoFidelidadeFotografia = table.Column<Guid>(nullable: false),
                    FotografiaPontoFidelidadeFotografiaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientePontoFidelidadeFotografia", x => x.ClientePontoFidelidadeFotografiaId);
                    table.ForeignKey(
                        name: "FK_ClientePontoFidelidadeFotografia_PontoFidelidadeFotografia_FotografiaPontoFidelidadeFotografiaId",
                        column: x => x.FotografiaPontoFidelidadeFotografiaId,
                        principalTable: "PontoFidelidadeFotografia",
                        principalColumn: "PontoFidelidadeFotografiaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMovimentacao_ClienteId",
                table: "ClienteMovimentacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMovimentacao_LojaId",
                table: "ClienteMovimentacao",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMovimentacaoFotografia_FotografiaMovimentacaoFotografiaId",
                table: "ClienteMovimentacaoFotografia",
                column: "FotografiaMovimentacaoFotografiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePontoFidelidade_ClienteId",
                table: "ClientePontoFidelidade",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientePontoFidelidadeFotografia_FotografiaPontoFidelidadeFotografiaId",
                table: "ClientePontoFidelidadeFotografia",
                column: "FotografiaPontoFidelidadeFotografiaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoFotografia_ClienteId",
                table: "MovimentacaoFotografia",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoFidelidadeFotografia_ClienteId",
                table: "PontoFidelidadeFotografia",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClienteMovimentacao");

            migrationBuilder.DropTable(
                name: "ClienteMovimentacaoFotografia");

            migrationBuilder.DropTable(
                name: "ClientePontoFidelidade");

            migrationBuilder.DropTable(
                name: "ClientePontoFidelidadeFotografia");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Loja");

            migrationBuilder.DropTable(
                name: "MovimentacaoFotografia");

            migrationBuilder.DropTable(
                name: "PontoFidelidadeFotografia");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
