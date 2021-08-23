using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Api.Data
{
    public class MeuDbContext : DbContext
    {

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EmpresaEntity> Empresas { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<VendaEntity> Vendas { get; set; }
        public DbSet<VendaItemEntity> VendasItens { get; set; }


        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpresaEntity>().HasData(
                new EmpresaEntity
                {
                    Id = 1,
                    Nome = "Posto de Gasolina Cidade",
                    Email = "postocidade@mail.com",
                    Foto = "",
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<CategoriaEntity>().HasData(
                new CategoriaEntity
                {
                    Id = 1,
                    Descricao = "Combustivel",
                    CreatedAt = DateTime.UtcNow
                },
                new CategoriaEntity
                {
                    Id = 2,
                    Descricao = "Lubrificantes",
                    CreatedAt = DateTime.UtcNow
                },
                new CategoriaEntity
                {
                    Id = 3,
                    Descricao = "Diversos",
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<ProdutoEntity>().HasData(
                new ProdutoEntity
                {
                    Id = 1,
                    Descricao = "Gasolina Aditivada",
                    Ean = "9789563530701",
                    Preco = 5.50m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new ProdutoEntity
                {
                    Id = 2,
                    Descricao = "Gasolina Comum",
                    Ean = "9789563530702",
                    Preco = 5.10m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new ProdutoEntity
                {
                    Id = 3,
                    Descricao = "Alcool Comum",
                    Ean = "9789563530703",
                    Preco = 4.00m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new ProdutoEntity
                {
                    Id = 4,
                    Descricao = "Alcool Aditivado",
                    Ean = "9789563530704",
                    Preco = 4.15m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new ProdutoEntity
                {
                    Id = 5,
                    Descricao = "Diesel",
                    Ean = "9789563530705",
                    Preco = 3.98m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 1
                },
                new ProdutoEntity
                {
                    Id = 6,
                    Descricao = "Óleo Lubrificante Motor 20w",
                    Ean = "9789563530710",
                    Preco = 20.00m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 2
                },
                new ProdutoEntity
                {
                    Id = 7,
                    Descricao = "Óleo Lubrificante Motor 40w",
                    Ean = "9789563530711",
                    Preco = 21.00m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 2
                },
                new ProdutoEntity
                {
                    Id = 8,
                    Descricao = "Água sem Gás",
                    Ean = "9789563530720",
                    Preco = 2.00m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 3
                },
                new ProdutoEntity
                {
                    Id = 9,
                    Descricao = "Água com Gás",
                    Ean = "9789563530721",
                    Preco = 2.10m,
                    CreatedAt = DateTime.UtcNow,
                    CategoriaId = 3
                }
            );

            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity
                {
                    Id = 1,
                    Nome = "Fernando Silva",
                    Email = "fernandosilva@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new UsuarioEntity
                {
                    Id = 2,
                    Nome = "Marcos",
                    Email = "marcos@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new UsuarioEntity
                {
                    Id = 3,
                    Nome = "Ellena",
                    Email = "ellena@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new UsuarioEntity
                {
                    Id = 4,
                    Nome = "Rafaela",
                    Email = "Rafaela@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new UsuarioEntity
                {
                    Id = 5,
                    Nome = "Heloisa",
                    Email = "heloisa@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new UsuarioEntity
                {
                    Id = 6,
                    Nome = "Manuella",
                    Email = "manuella@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new UsuarioEntity
                {
                    Id = 7,
                    Nome = "Luan",
                    Email = "luan@mail.com",
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<ClienteEntity>().HasData(
                new ClienteEntity
                {
                    Id = 1,
                    Nome = "Sofia Marli Porto",
                    Email = "sofia@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new ClienteEntity
                {
                    Id = 2,
                    Nome = "Raimunda Isis Olivia Vieira",
                    Email = "raimunda@mail.com",
                    CreatedAt = DateTime.UtcNow
                },
                new ClienteEntity
                {
                    Id = 3,
                    Nome = "Oliver Arthur da Mota",
                    Email = "oliver@mail.com",
                    CreatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<VendaEntity>().HasData(
                new VendaEntity
                {
                    Id = 1,
                    ClienteId = 2,
                    DataVenda = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    TotalVenda = 100.00m,
                },
                new VendaEntity
                {
                    Id = 2,
                    ClienteId = 3,
                    DataVenda = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    TotalVenda = 75.00m,
                },
                new VendaEntity
                {
                    Id = 3,
                    ClienteId = 1,
                    DataVenda = DateTime.UtcNow.AddDays(2),
                    CreatedAt = DateTime.UtcNow.AddDays(2),
                    TotalVenda = 200.00m,
                }
            );

            modelBuilder.Entity<VendaItemEntity>().HasData(
                new VendaItemEntity
                {
                    Id = 1,
                    ProdutoId = 2,
                    VendaId = 1,
                    Quantidade = 18.18m,
                    ValorProduto = 5.50m,
                    TotalProduto = 100.00m
                },
                new VendaItemEntity
                {
                    Id = 2,
                    ProdutoId = 1,
                    VendaId = 2,
                    Quantidade = 9.80m,
                    ValorProduto = 5.10m,
                    TotalProduto = 50.00m
                },
                new VendaItemEntity
                {
                    Id = 3,
                    ProdutoId = 9,
                    VendaId = 2,
                    Quantidade = 12m,
                    ValorProduto = 2.10m,
                    TotalProduto = 25.00m
                },
                new VendaItemEntity
                {
                    Id = 4,
                    ProdutoId = 5,
                    VendaId = 3,
                    Quantidade = 50.24m,
                    ValorProduto = 3.98m,
                    TotalProduto = 200.00m
                }
            );

        }

    }
}
