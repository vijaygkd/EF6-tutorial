using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Books.Entities;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public BooksDb() 
            : base("DefaultConnection")         // Use default local db
        {
            Database.Log = (sql => Debug.Write(sql));
        }



        // DbSet property maps to a table in DB.
        // In this case Books table will be created by Code first

        // We can query the DbSet property with Linq query which are converted to SQL queries by EF.
        // We can also use this property to insert and deleted objects from the DB.
        public DbSet<Book> Books { get; set; }
    }
}