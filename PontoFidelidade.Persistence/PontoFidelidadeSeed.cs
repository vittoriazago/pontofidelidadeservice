using PontoFidelidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PontoFidelidade.Persistence
{
    public class PontoFidelidadeSeed
    {
        private readonly Dictionary<int, Loja> Lojas = new Dictionary<int, Loja>();
        private readonly Dictionary<int, Cliente> Clientes = new Dictionary<int, Cliente>();
        private readonly Dictionary<int, Usuario> Usuarios = new Dictionary<int, Usuario>();

        public static void Initialize(PontoFidelidadeContexto context)
        {
            var initializer = new PontoFidelidadeSeed();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(PontoFidelidadeContexto context)
        {
            context.Database.EnsureCreated();

            if (context.Loja.Any())
            {
                return; // Db has been seeded
            }

            var lojas = SeedLojas(context);
            var clients = SeedClients(context, lojas.First().LojaId);
        }

        public Loja[] SeedLojas(PontoFidelidadeContexto context)
        {
            var Lojas = new[]
            {
                LojaNovo("Loja da Vittoria",  "2018-05-08", "93984583000113", new Guid("4B335B6F-9C4D-47F7-B798-C46FFBC4881A"), "1"),
                LojaNovo("Minhas roupas na moda!", "2011-11-01", "62297611000109"),
                LojaNovo("Hamburguers top",  "2002-02-27", "15655888000178"),
                LojaNovo("Comida Cazeira da Maria",  "2019-02-11", "02649929000171"),
                LojaNovo("Periféricos PontoCom",  "2018-05-30", "06936230000143"),
                LojaNovo("Posto MeuAmigo", "2015-10-10", "30519970000169"),
            };

            context.Loja.AddRange(Lojas);
            context.SaveChanges();

            return Lojas;
        }
        public Cliente[] SeedClients(PontoFidelidadeContexto context, Guid idLoja)
        {
            var clients = new[]
            {
                ClienteNovo(idLoja, "Maria Anders","1979-11-01", "67845803030"),
                ClienteNovo(idLoja, "Ana Trujillo", "1993-02-27", "71734065010", 10M, 20),
                ClienteNovo(idLoja, "Antonio Moreno", "1995-12-11", "81244982024", 2M, 50),
                ClienteNovo(idLoja, "Thomas Hardy", "1990-05-08", "73793266001", 5M, 200) ,
                ClienteNovo(idLoja, "Christina Berglund", "1980-05-30", "11972287052", 10M, 100),
            };

            context.Cliente.AddRange(clients);
            context.SaveChanges();

            return clients;
        }

        private Loja LojaNovo(
            string descricao,
            string dataAbertura = null,
            string cnpj = null,
            Guid? chaveIntegracao = null,
            string codigo = null
            )
        {
            var id = Guid.NewGuid();
            return new Loja
            {
                LojaId = Guid.NewGuid(),
                Ativo = true,
                Descricao = descricao,
                DataCadastro = DateTime.Now,
                DataAbertura = DateTime.ParseExact(dataAbertura, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                ChaveIntegracao = chaveIntegracao ?? Guid.NewGuid(),
                CNPJ = cnpj,
                Codigo = codigo ?? (Guid.NewGuid().ToString()).Substring(0,3),
            };
        }
        private Cliente ClienteNovo(
           Guid idLoja,
           string nome,
           string dataNascimento = null,
           string cnpj = null,
           decimal? valorCredito = 5M,
           long? pontos = 100
           )
        {
            var id = Guid.NewGuid();
            return new Cliente
            {
                ClienteId = id,
                Nome = nome,
                DataCadastro = DateTime.Now,
                DataNascimento = !string.IsNullOrEmpty(dataNascimento) ?
                    DateTime.ParseExact(dataNascimento, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue,
                MovimentacoesDinheiro = new List<ClienteMovimentacao>()
                {
                    new ClienteMovimentacao()
                    {
                        SaldoAtual = valorCredito ?? 5M,
                        Valor = valorCredito ?? 5M,
                        DataOperacao = DateTime.Today,
                        Operacao = Domain.Models.Enums.Operacao.Credito,
                        IdCliente = id,
                        ClienteMovimentacaoId = Guid.NewGuid(),
                        IdLoja = idLoja
                    }
                },
                MovimentacoesPontoFidelidade = new List<ClientePontoFidelidade>()
                {
                    new ClientePontoFidelidade()
                    {
                        SaldoAtual = pontos ?? 100,
                        Pontos = pontos ?? 100,
                        DataOperacao = DateTime.Today,
                        Operacao = Domain.Models.Enums.Operacao.Credito,
                        IdCliente = id,
                        ClientePontoFidelidadeId = Guid.NewGuid(),
                        IdLoja = idLoja
                    }
                }
            };
        }

    }
}