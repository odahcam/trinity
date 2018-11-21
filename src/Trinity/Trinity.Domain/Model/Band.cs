using System.Collections.Generic;
using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Model
{
    public class Band : Entity
    {
        public string Name { get; set; }

        public short FoundationYear { get; set; }

        public virtual ICollection<Music> Musics { get; set; }

        public Band FromValue(Band value)
        {
            Name = value.Name;
            FoundationYear = value.FoundationYear;
            return this;
        }
    }
}
