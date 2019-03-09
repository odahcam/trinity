namespace Trinity.Domain.Core.Model
{
    public interface IEntity : IEntity<long> { }

    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
