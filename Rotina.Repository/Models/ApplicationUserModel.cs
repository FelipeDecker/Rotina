using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Rotina.Repository.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
