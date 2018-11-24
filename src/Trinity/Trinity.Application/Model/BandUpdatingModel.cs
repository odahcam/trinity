using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class BandUpdatingModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public short FoundationYear { get; set; }

        public static implicit operator Band(BandUpdatingModel model)
        {
            return new Band
            {
                Name = model.Name,
                FoundationYear = model.FoundationYear,
                CreationDate = DateTime.Now
            };
        }
    }
}
