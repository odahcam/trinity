using System.Collections.Generic;
using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Model
{
    public class Album : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<Music> Musics { get; set; }

        public Album FromValue(Album value)
        {
            Title = value.Title;
            return this;
        }
    }
}
