using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Book_Store
{
    public class DataContext : DbContext
    {
        public DbSet<UserClass> Users { get; set; }
        public DbSet<BooksClass> Books { get; set; }
        public DataContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Visual Studio ШАГ\\C#\\Book_Store\\GeneralDatabase.mdf\";Integrated Security=True");
        }
    }
}
