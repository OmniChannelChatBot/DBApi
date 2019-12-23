using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// For known users stored in database
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// For channel users
        /// </summary>
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public DateTimeOffset CreateDate { get; set; }

        [Required]
        public DateTimeOffset UpdateDate { get; set; }
    }
}
