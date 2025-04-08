using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace WebApplication1.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public MobileContext(DbContextOptions<MobileContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }
    }

}
