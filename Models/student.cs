using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class student
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
            public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string department { get; set; }
        [Required]

     
        public DateTime  date { get; set; }




    }
}
