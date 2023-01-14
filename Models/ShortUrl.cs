using System.ComponentModel.DataAnnotations;


namespace Short.Models
{
	public class ShortUrl
	{
		public int Id { get; set; }

		[Required]
		public string OriginalUrl { get; set; }
	}
}