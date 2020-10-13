using Financitos.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financitos.Models
{
    public class Financistoconex: DbContext
    {
        //Esto se repite por cada tabla de base de datos
        public DbSet<Account> Accounts { get; set; }

        public Financistoconex(DbContextOptions<Financistoconex> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Esto se repite por cada tabla de base de datos
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}
