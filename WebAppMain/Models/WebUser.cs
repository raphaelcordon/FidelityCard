using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAppMain.Models
{
	public class WebUser : IdentityUser
	{
		[Required]
		bool IsAdmin { get; set; } = false;
		[Required]
		bool IsCompany { get; set; } = false;
	}
}
