using System.Collections.Generic;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;
using AppTacOSFinal.Models.Cedis;
using Xamarin.Forms;

namespace AppTacOSFinal.Data
{
    public class FicDBContext : DbContext
    {
        private string FicDataBasePath;

        public FicDBContext(string FicPaDataBasePath)
        {
            FicDataBasePath = FicPaDataBasePath;
            FicMetCrearDB();
        }

        public FicDBContext(DbContextOptions<FicDBContext> ficOptions) : base(ficOptions)
        {

        }

        public async void FicMetCrearDB()
        {
            try
            {
                //FIC: SE crea la base de datos en base al esquema
                await Database.EnsureCreatedAsync();
            }
            catch (Exception err)
            {
                await new Page().DisplayAlert("ALERTA", err.Message.ToString(), "OK");
            }
        }//ESTE METODO CREA LA BASE DE DATOS

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionBuilder)
        {
            try
            {
                FicPaOptionBuilder.UseSqlite($"Filename={FicDataBasePath}");
                FicPaOptionBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception err)
            {
                await new Page().DisplayAlert("ALERTA", err.Message.ToString(), "OK");
            }
        }//CONFIGURACION DE LA CONECXION

        //GESTION DE INVENTARIOS
        public DbSet<CediAlmModel> CediAlmModel { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //EVA_CAT_EDIFICIOS
                modelBuilder.Entity<CediAlmModel>().HasKey(pk => new { pk.IdCedi });


            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//AL CREAR EL MODELO

    }
}
