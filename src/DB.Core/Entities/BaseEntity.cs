using System;

namespace DB.Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// For known users stored in database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// For channel users
        /// </summary>
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
