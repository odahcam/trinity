using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class AlbumDisplayingModel
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public static explicit operator AlbumDisplayingModel(Album entity)
        {
            return new AlbumDisplayingModel
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }
    }
}
