using System;

namespace Trinity.Domain.Core.Model
{
    public class Entity : IEntity
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
