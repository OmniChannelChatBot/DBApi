using System.ComponentModel.DataAnnotations;

namespace DBApi.Model
{
    public class CheckUserModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
