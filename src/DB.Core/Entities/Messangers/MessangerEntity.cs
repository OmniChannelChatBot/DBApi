using DB.Core.Entities.Company;
using DB.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Core.Entities.Messangers
{
    public class MessangerEntity : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string Token { get; set; }

        [Required]
        public short Type { get; set; }

        /// <summary>
        /// CompanyId or UserId should by not null
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// CompanyId or UserId should by not null
        /// </summary>
        public int? UserId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public CompanyEntity Company { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}
