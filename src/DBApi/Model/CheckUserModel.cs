using System;
using System.ComponentModel.DataAnnotations;

namespace DBApi.Model
{
    public class CheckUserModel
    {
        [Required]
        public string Username { get; set; }
    }
}
