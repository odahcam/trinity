using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Model
{
    public class Music : Entity
    {
        public string Title { get; set; }

        public long Duration { get; set; }

        public long? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public long BandId { get; set; }
        public virtual Band Band { get; set; }

        public Music FromValue(Music value)
        {
            Id = value.Id;
            Title = value.Title ?? Title;
            Duration = value.Duration;
            AlbumId = value.AlbumId ?? AlbumId;
            Band = value.Band;
            return this;
        }
    }
}
