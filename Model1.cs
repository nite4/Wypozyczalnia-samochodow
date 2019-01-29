using System;
using System.Data.Entity;
using System.Linq;

namespace Wypożyczalnia_Samochodów
{
    ///<summary>
    /// Klasa jest odpowiedzialna za zapis danych do bazy danych.
    ///</summary>
    
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Wypożyczalnia_Samochodów.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Klient> KlientS { get; set; }
        public virtual DbSet<Samochód> Samochóds { get; set; }
        public virtual DbSet<Wypożyczenie> Wypożyczenies { get; set; }
        

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}