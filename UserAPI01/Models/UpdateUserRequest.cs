using System.ComponentModel.DataAnnotations;

namespace UserAPI01.Models
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }

        public string Department { get; set; }
    }
}
