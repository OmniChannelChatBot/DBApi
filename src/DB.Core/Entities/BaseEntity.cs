using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// For known users stored in database
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// For channel users
        /// </summary>
        [Required]
        public Guid Guid { get; set; }
    }
}
