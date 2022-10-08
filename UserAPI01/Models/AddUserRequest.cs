using System.ComponentModel.DataAnnotations;

namespace UserAPI01.Models
{
    public class AddUserRequest
    {
        public string Name { get; set; }

        public string Department { get; set; }
    }
}
