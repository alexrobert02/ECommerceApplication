using Microsoft.AspNetCore.Identity;

namespace ECommerceApplication.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
