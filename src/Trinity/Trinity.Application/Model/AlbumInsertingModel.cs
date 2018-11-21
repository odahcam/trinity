using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class AlbumInsertingModel
    {
        public string Title { get; set; }

        public static explicit operator Album(AlbumInsertingModel model)
        {
            return new Album
            {
                Title = model.Title,
                CreationDate = DateTime.Now
            };
        }
    }
}
