using System;
using System.ComponentModel.DataAnnotations;

namespace DBApi.Model
{
    public class CheckUserNameModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
