using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class AlbumUpdatingModel
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public static explicit operator Album(AlbumUpdatingModel model)
        {
            return new Album
            {
                Id = model.Id,
                Title = model.Title,
                UpdateDate = DateTime.Now
            };
        }
    }
}
