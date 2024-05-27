using System.ComponentModel.DataAnnotations;

namespace StudentBlazorApp.Model
{
    public class Students
    {
        
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; } =false;
    }
}
