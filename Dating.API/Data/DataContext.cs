using Dating.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    //make every class public
    public class DataContext:DbContext
    {
        //do your code
        public DataContext(DbContextOptions<DataContext> option) :base (option){}
        public DbSet<Value> Values { get; set; }
        public DbSet <User> Users { get; set; }
    }
}