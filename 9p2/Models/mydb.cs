using Microsoft.EntityFrameworkCore;

namespace _9p2.Models
{
    public class mydb:DbContext
    {
        public mydb(DbContextOptions<mydb> options) :base(options) 
        {
        }
        public DbSet<tbl_login> logins
        {
        get; set; }
        public DbSet<category> categories
        {
        get; set; }
        public DbSet<product> products
        {
        get; set; }
    }
}
