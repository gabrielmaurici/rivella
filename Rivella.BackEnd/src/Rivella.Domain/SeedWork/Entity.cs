namespace Rivella.Domain.SeedWork;

public class Entity<T>(T id)
{
    public T Id { get; private set; } = id;
}