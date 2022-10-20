using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Siemens_WEBAPI.Models;

namespace Siemens_WEBAPI.Data
{
    public class DataContext : DbContext
    {
     public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cidade> Cidade { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cidade>()
                .HasData(new List<Cidade>(){
                    new Cidade(1, "Curitiba", "PR"),
                    new Cidade(2, "Sao Paulo", "SP"),
                    new Cidade(3, "Rio de Janeiro", "RJ"),
                    new Cidade(4, "Belo Horizonte", "MG"),
                    new Cidade(5, "Porto Alegre", "RS"),
                });
            
            builder.Entity<Cliente>()
                .HasData(new List<Cliente>{
                    new Cliente(1, "Paulo", "Masculino", "29-12-1994", 28, 1),
                    new Cliente(2, "Henrique", "Masculino", "21-02-1990", 32, 1),
                    new Cliente(3, "Guilherme", "Masculino", "12-04-1980", 42, 2),
                    new Cliente(4, "Paula", "Feminino", "10-07-1996", 26, 3),
                    new Cliente(5, "Mariana", "Feminino", "09-10-1992", 30, 4),
                    new Cliente(6, "Francisca", "Feminino", "15-03-1989", 33, 5)

                });
        }
    }
}
