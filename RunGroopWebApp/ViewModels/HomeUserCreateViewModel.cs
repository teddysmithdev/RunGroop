using System.ComponentModel.DataAnnotations;

namespace RunGroopWebApp.ViewModels
{
    public class HomeUserCreateViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int? ZipCode { get; set; }
    }
}
