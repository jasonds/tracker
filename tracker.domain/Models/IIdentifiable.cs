namespace tracker.domain.Models
{
    public interface IIdentifiable<out T>
    {
        T Id { get; }
    }
}
