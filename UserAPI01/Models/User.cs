using System.ComponentModel.DataAnnotations;

namespace UserAPI01.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }

        public DateTime Created { get { return DateTime.Now; } }
    }
}
