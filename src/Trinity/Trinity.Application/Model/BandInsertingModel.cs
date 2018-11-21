using System;
using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class BandInsertingModel
    {
        public string Name { get; set; }

        public short FoundationYear { get; set; }

        public static explicit operator Band(BandInsertingModel model)
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
