using PontoFidelidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PontoFidelidade.Persistence
{
    public class PontoFidelidadeSeed
    {
        private readonly Dictionary<int, Loja> Lojas = new Dictionary<int, Loja>();
        private readonly Dictionary<int, Cliente> Clientes = new Dictionary<int, Cliente>();
        private readonly Dictionary<int, ClienteMovimentacao> ClientesMovimentacoes = new Dictionary<int, ClienteMovimentacao>();
        private readonly Dictionary<int, ClientePontoFidelidade> ClientesPontoFidelidade = new Dictionary<int, ClientePontoFidelidade>();

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

            var clients = SeedClients(context);
            var Lojas = SeedLojas(context);
        }
        
        public Loja[] SeedLojas(PontoFidelidadeContexto context)
        {
            var Lojas = new[]
            {
                new Loja { LojaId = Guid.NewGuid(), Descricao = "Minhas roupas na moda!", DataCadastro = DateTime.ParseExact("2011-11-01", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Loja { LojaId = Guid.NewGuid(), Descricao = "Hamburguers top",  DataCadastro = DateTime.ParseExact("2002-02-27", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Loja { LojaId = Guid.NewGuid(), Descricao = "Comida Cazeira da Maria",  DataCadastro = DateTime.ParseExact("2019-02-11", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Loja { LojaId = Guid.NewGuid(), Descricao = "Loja da Vittoria",  DataCadastro = DateTime.ParseExact("2018-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Loja { LojaId = Guid.NewGuid(), Descricao = "Periféricos .Com",  DataCadastro = DateTime.ParseExact("2018-05-30", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Loja { LojaId = Guid.NewGuid(), Descricao = "Posto MeuAmigo", DataCadastro = DateTime.ParseExact("2015-10-10", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
            };

            context.Loja.AddRange(Lojas);
            context.SaveChanges();

            return Lojas;
        }
        public Cliente[] SeedClients(PontoFidelidadeContexto context)
        {
            var clients = new[]
            {
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Maria Anders", DataCadastro = DateTime.ParseExact("1979-11-01", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Ana Trujillo",  DataCadastro = DateTime.ParseExact("1993-02-27", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Antonio Moreno",  DataCadastro = DateTime.ParseExact("1995-12-11", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Thomas Hardy",  DataCadastro = DateTime.ParseExact("1990-05-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture) },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Christina Berglund",  DataCadastro = DateTime.ParseExact("1980-05-30", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Hanna Moos", DataCadastro = DateTime.ParseExact("1982-10-10", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture),  },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Frédérique Citeaux", DataCadastro = DateTime.ParseExact("1999-06-20", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
                new Cliente { ClienteId = Guid.NewGuid(), Nome = "Martín Sommer", DataCadastro = DateTime.ParseExact("1971-01-08", "yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture)  },
            };

            context.Cliente.AddRange(clients);
            context.SaveChanges();

            return clients;
        }

    }
}
