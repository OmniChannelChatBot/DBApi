using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Api.Application.Models
{
    public class CheckUserNameModel
    {
        [Required]
        public string UserName { get; set; }
    }
}
