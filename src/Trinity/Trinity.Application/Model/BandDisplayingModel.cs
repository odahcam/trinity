using Trinity.Domain.Model;

namespace Trinity.Application.Model
{
    public class BandDisplayingModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public short FoundationYear { get; set; }

        public static implicit operator BandDisplayingModel(Band entity)
        {
            return new BandDisplayingModel
            {
                Id = entity.Id,
                FoundationYear = entity.FoundationYear,
                Name = entity.Name
            };
        }
    }
}
