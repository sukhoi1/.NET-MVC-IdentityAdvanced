using System.ComponentModel.DataAnnotations;

namespace IdentityAdvanced.Models
{
	public class CreateModel
	{
        public string Id { get; set; }

        [Required]
	    public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}