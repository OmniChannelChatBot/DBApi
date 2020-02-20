using DB.Core.Entities.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities.Company
{
    public class CompanyEntity : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; }

        public List<UserEntity> CompanyUsers { get; set; }
    }
}
