using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Models
{
  
    public class ApplicationUser : IdentityUser
    {
        //  public bool Active { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
