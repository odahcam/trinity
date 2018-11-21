using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class MusicDisplayingModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public BandDisplayingModel Band { get; set; }

        public AlbumDisplayingModel Album { get; set; }

        public static explicit operator MusicDisplayingModel(Music entity)
        {
            return new MusicDisplayingModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Duration = TimeSpan.FromTicks(entity.Duration),
                Album = entity.Album != null ? (AlbumDisplayingModel)entity.Album : null,
                Band = (BandDisplayingModel)entity.Band
            };
        }
    }
}
