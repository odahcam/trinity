using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class MusicUpdatingModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public long? AlbumId { get; set; }

        public long BandId { get; set; }

        public static explicit operator Music(MusicUpdatingModel model)
        {
            return new Music
            {
                Title = model.Title,
                UpdateDate = DateTime.Now,
                AlbumId = model.AlbumId
            };
        }
    }
}
