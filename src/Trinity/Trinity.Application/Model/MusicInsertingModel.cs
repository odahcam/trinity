using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class MusicInsertingModel
    {
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public long? AlbumId { get; set; }

        public long BandId { get; set; }

        public static implicit operator Music(MusicInsertingModel model)
        {
            return new Music
            {
                Title = model.Title,
                Duration = model.Duration.Ticks,
                CreationDate = DateTime.Now,
                AlbumId = model.AlbumId,
                BandId = model.BandId
            };
        }
    }
}
