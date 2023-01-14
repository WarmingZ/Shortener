using Microsoft.EntityFrameworkCore;
using Short.Models;

namespace Short.Data
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions options) : base(options)
        {
					
        }
		   	public DbSet<ShortUrl> ShortUrls { get; set; }
    }
		
}